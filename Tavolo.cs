using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzoCarteClassLibrary
{
    public class Tavolo
    {
        private readonly Mazzo _mazzo;
        private Carta _briscola;
        private readonly Player _p1;
        private readonly Player _p2;
        public List<Carta> Piatto { get; set; }

        public Tavolo(Player player1, Player player2, Mazzo mazzo)
        {
            _p1 = player1;
            _p2 = player2;
            Piatto = new List<Carta>();
            _mazzo = mazzo;

        }

        public void GetPiatto()
        {
            Piatto.Clear();
            if (_p1.FirstToPlay)
            {
                Console.WriteLine("- p1 starts: ");
                Piatto.Add(_p1.Play());
                Piatto.Add(_p2.Play());
            }
            else
            {
                Console.WriteLine("- p2 starts: ");
                Piatto.Add(_p2.Play());
                Piatto.Add(_p1.Play());
            }

        }
        public void PiattoWinner()
        {
            var firstToPlay = _p1.FirstToPlay ? _p1 : _p2;
            var secondToPlay = _p1.FirstToPlay ? _p2 : _p1;
            //assegna valore carta
            var carta1 = Piatto[0];
            int value1 = carta1.Value == 1 ? carta1.Value + 100 : (carta1.Value == 3 ? carta1.Value + 50 : carta1.Value);
            var carta2 = Piatto[1];
            int value2 = carta2.Value == 1 ? carta2.Value + 100 : (carta2.Value == 3 ? carta2.Value + 50 : carta2.Value);
            if (carta1.Seme == _briscola.Seme) value1 += 10;
            if (carta2.Seme == _briscola.Seme) value2 += 10;
            //controllo briscole
            if (carta1.Seme == _briscola.Seme && carta2.Seme != _briscola.Seme) firstToPlay.Mazzetto.AddRange(Piatto);
            else if (carta1.Seme != _briscola.Seme && carta2.Seme == _briscola.Seme)
            {
                secondToPlay.Mazzetto.AddRange(Piatto);
                secondToPlay.FirstToPlay = true;
                firstToPlay.FirstToPlay = false;
            }
            else if (carta1.Seme == _briscola.Seme && carta2.Seme == _briscola.Seme)
            {
                if (value1 > value2) firstToPlay.Mazzetto.AddRange(Piatto);
                else
                {
                    secondToPlay.Mazzetto.AddRange(Piatto);
                    secondToPlay.FirstToPlay = true;
                    firstToPlay.FirstToPlay = false;
                }
            }
            //Caso non briscola in gioco
            else if (carta2.Seme != carta1.Seme) firstToPlay.Mazzetto.AddRange(Piatto);
            else if (carta2.Seme == carta1.Seme)
            {
                if (value1 > value2) firstToPlay.Mazzetto.AddRange(Piatto);
                else
                {
                    secondToPlay.Mazzetto.AddRange(Piatto);
                    secondToPlay.FirstToPlay = true;
                    firstToPlay.FirstToPlay = false;
                }
            }

        }
        public void ShowBriscola()
        {
            Console.WriteLine("\n\nBriscola: " + _briscola.ToString());
            Console.WriteLine();
        }
        public void SetBriscola()
        {
            _briscola = _mazzo.GetBriscola();
        }
    }
}
