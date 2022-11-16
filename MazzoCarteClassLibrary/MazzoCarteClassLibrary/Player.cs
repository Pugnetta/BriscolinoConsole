using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzoCarteClassLibrary
{
    public class Player
    {
        private readonly List<Carta> _mano;
        public List<Carta> Mazzetto { get; set; }
        public IEnumerable<Carta> Mano { get { return _mano; } }
        public bool FirstToPlay { get; set; }
        public Player()
        {
            _mano = new List<Carta>();
            Mazzetto = new List<Carta>();
        }
        public void Draw(Mazzo mazzo)
        {
            var carta = mazzo.GetCarta();
            if (carta != null) _mano.Add(carta);

        }
        public void Draw(Mazzo mazzo, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var carta = mazzo.GetCarta();
                if (carta != null) _mano.Add(carta);
            }
        }
        public void Discard()
        {
            int n = -1;

            while (n > _mano.Count || n < 0)
            {
                n = Game.GetIntInput();
            }

            _mano.Remove(_mano[n]);
        }
        public Carta Play()
        {
            int n = -1;

            while (n >= _mano.Count || n < 0)
            {
                n = Game.GetIntInput();
            }
            Carta temp = _mano[n];
            _mano.Remove(_mano[n]);

            return temp;
        }
        public int GetFinalScore()
        {
            int totScore = 0;
            foreach (var carta in Mazzetto)
            {
                switch (carta.Value)
                {
                    case 1: totScore += 11; break;
                    case 3: totScore += 10; break;
                    case 8: totScore += 2; break;
                    case 9: totScore += 3; break;
                    case 10: totScore += 4; break;
                    default: break;
                }
            }
            return totScore;
        }



    }
}
