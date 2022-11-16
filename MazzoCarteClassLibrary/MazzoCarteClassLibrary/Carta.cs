using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzoCarteClassLibrary
{
    public enum Seme
    {
        cuori,
        mattoni,
        fiori,
        picche
    };
    public class Carta
    {
        public Seme Seme { get; private set; }
        public int Value { get; private set; }
        

        public Carta(int value, Seme seme)
        {
            Value = value;
            Seme = seme;
           
        }

        public override string ToString()
        {
            return $"{Value} {Seme}";
        }


    }
}
