using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzoCarteClassLibrary
{
    public class Mazzo
    {
        private const int numeroCarte = 40;
        private readonly List<Carta> _carte;
        public List<Carta> Carte { get { return _carte; } }

        public Mazzo()
        {
            _carte = new List<Carta>();
            int tempCarte = numeroCarte;
            Seme tempSeme = 0;
            while (tempCarte > 0)
            {
                for (int i = 1; i < 11; i++)
                {
                    _carte.Add(new Carta(i, tempSeme));
                    tempCarte--;
                }
                tempSeme++;
            }

        }
        public void MescolaMazzo()
        {
            Random random = new Random();

            int n = _carte.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                (_carte[n], _carte[k]) = (_carte[k], _carte[n]);
            }
        }

        public Carta? GetCarta()
        {
            if (_carte.Count > 0)
            {
                var temp = _carte[0];
                _carte.Remove(_carte[0]);
                return temp;
            }
            else return null;

        }
        public void DealCards(Player p1, Player p2, int nOfCardsForPlayer)
        {
            int cardsToDeal = nOfCardsForPlayer * 2 > _carte.Count ? _carte.Count : nOfCardsForPlayer * 2;
            for (int i = 0; i < cardsToDeal; i++)
            {
                if (i % 2 == 0) p1.Draw(this);
                else p2.Draw(this);
              
            }
        }
        public Carta GetBriscola()
        {
            return _carte[_carte.Count - 1];
        }

    }
}
