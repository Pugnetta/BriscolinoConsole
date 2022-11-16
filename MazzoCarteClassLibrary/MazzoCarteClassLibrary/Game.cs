using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzoCarteClassLibrary
{
    public static class Game
    {
       
        public static int GetIntInput()
        {
            var temp = 0;
            Console.WriteLine("select card: ");
            var tryParse = false;
            while(tryParse == false)
            {
                tryParse = int.TryParse(Console.ReadLine(), out temp);
            }
            return temp;
        }

        public static void DisplayHand(Player p1, Player p2)
        {
            Console.WriteLine("*p1 hand:");
            foreach (var carta in p1.Mano)
            {               
                Console.Write(carta.ToString() +"   ");
            }
            Console.WriteLine("\n\n*p2 hand:");
            foreach (var carta in p2.Mano)
            {
                Console.Write(carta.ToString() + "   ");
            }
        }
        public static void DisplayBriscola(Tavolo tavolo)
        {
            tavolo.ShowBriscola();
        }


    }
}
