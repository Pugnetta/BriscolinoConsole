using MazzoCarteClassLibrary;
using System;

internal class Program
{
    private static void Main(string[] args)
    {

        // start game
        Random random = new Random();
        Player p1 = new Player();
        Player p2 = new Player();        
        var mazzo = new Mazzo();
        Tavolo tavolo = new Tavolo(p1, p2, mazzo);        
        for (int i = 0; i < 100; i++)
        {
            mazzo.MescolaMazzo();
        }
        tavolo.SetBriscola();
        int dice = random.Next(20);
        if (dice % 2 == 0) p1.FirstToPlay = true;
        else p2.FirstToPlay = true;

        mazzo.DealCards(p1, p2, 3);

        // game flow
        while (p1.Mano.Count() > 0)
        {

            Console.Clear();
            if (mazzo.Carte.Count == 2) Console.WriteLine("Next is the Last Hand!======================================================");
            Game.DisplayHand(p1, p2);
            Game.DisplayBriscola(tavolo);
            tavolo.GetPiatto();
            tavolo.PiattoWinner();
            if (mazzo.Carte.Count > 0)
            {
                if (p1.FirstToPlay)
                {
                    p1.Draw(mazzo);
                    p2.Draw(mazzo);
                }
                else
                {
                    p2.Draw(mazzo);
                    p1.Draw(mazzo);
                }
            }
            
        }

        Console.WriteLine($"p1 score:{p1.GetFinalScore()}\t p2 score:{p2.GetFinalScore()}");
        Console.ReadKey();




    }
}