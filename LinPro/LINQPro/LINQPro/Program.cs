using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPro
{
    class Player
        {
            public string DeckColor { get; set; }
            public string Name { get; set; }
            public int Win { get; set; }
            public int Lost { get; set; }
        }
    class Program
    {
        
        static void Main(string[] args)
        {
            int pick;
            Player[] playerArray =
            {
                new Player() {Name = "Will", DeckColor = "Blue", Win = 6, Lost = 5 },
                new Player() {Name = "Sam", DeckColor = "Red", Win = 2, Lost = 4 },
                new Player() {Name = "Amy", DeckColor = "Black", Win = 34, Lost = 25 },
                new Player() {Name = "Carl", DeckColor = "White", Win = 23, Lost = 22 },
                new Player() {Name = "Geige", DeckColor = "Green", Win = 16, Lost = 1 },
                new Player() {Name = "Henary", DeckColor = "Black", Win = 11, Lost = 3 },
                new Player() {Name = "Tim", DeckColor = "Black", Win = 12, Lost = 4 },
                new Player() {Name = "Tom", DeckColor = "White", Win = 14, Lost = 10 },
                new Player() {Name = "Anthony", DeckColor = "Green", Win = 12, Lost = 14 },
                new Player() {Name = "Duncen", DeckColor = "Blue", Win = 35, Lost = 0 },
                new Player() {Name = "Frank", DeckColor = "Green", Win = 8, Lost = 12 },
                new Player() {Name = "Fin", DeckColor = "Green", Win = 9, Lost = 12 },
                new Player() {Name = "Derick", DeckColor = "Red", Win = 1, Lost = 22 },
                new Player() {Name = "Nick", DeckColor = "Red", Win = 17, Lost = 11 },
                new Player() {Name = "Eric", DeckColor = "White", Win = 8, Lost = 15 },
                new Player() {Name = "Ethan", DeckColor = "Black", Win = 0, Lost = 35 },
            };

            var Color = from c in playerArray
                        orderby c.DeckColor ascending
                        select c;
            var Wins = from w in playerArray
                       where w.Win > -1 && w.Win < 40
                       orderby w.Win descending
                       select w;
            var Loses = from l in playerArray
                        where l.Lost > -1 && l.Lost < 40
                        orderby l.Lost ascending
                        select l;
            var group1 = from gw in playerArray
                         where gw.Win > 20 && gw.Win < 40
                         orderby gw.Win descending
                         group gw by gw.Win;
            var group2 = from gw in playerArray
                         where gw.Lost > 20 && gw.Win < 40
                         orderby gw.Lost descending
                         group gw by gw.Lost;


            Console.WriteLine("Pick a number from 1-5");
            pick = Convert.ToInt32(Console.ReadLine());
            while(pick > 5)
            {
                Console.WriteLine("enter 1 - 5");
                pick = Convert.ToInt32(Console.ReadLine());
            }
            if (pick == 1)
            {
                foreach (Player p in Wins)
                {
                    Console.WriteLine("Player Name: {0}", p.Name);
                    Console.WriteLine("Wins: {0}", p.Win);
                    Console.WriteLine(" ");
                }
            }
            else if(pick == 2)
            {
                foreach (Player p in Loses)
                {
                    Console.WriteLine("Player Name: {0}", p.Name);
                    Console.WriteLine("Loses: {0}", p.Lost);
                    Console.WriteLine(" ");
                }
            }
            else if(pick == 3)
            {
                foreach (Player p in Color)
                {
                    Console.WriteLine("Player Name: {0}", p.Name);
                    Console.WriteLine("color of the deck: {0}", p.DeckColor);
                    Console.WriteLine(" ");
                }
            }
            else if(pick == 4)
            {
                foreach(var pw in group1)
                {
                    Console.WriteLine("Winners: {0}", pw.Key);
                    foreach (Player p in pw)
                {
                    Console.WriteLine("Player Name: {0}", p.Name);
                    Console.WriteLine(" ");
                }
                }
                
            }
            else if (pick == 5)
            {
                foreach (var pw in group2)
                {
                    Console.WriteLine("Losers: {0}", pw.Key);
                    foreach (Player p in pw)
                    {
                        Console.WriteLine("Player Name: {0}", p.Name);
                        Console.WriteLine(" ");
                    }
                }

            }

        }
    }
}
