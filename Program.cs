using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BlackJack_ClassesAndObjects__Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the best ever BlackJack game. Please tell us your name.");
            string playerName = Console.ReadLine();
            Console.WriteLine("How much money are you willing to lose today?");
            int bank = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hey, {0}. Are you ready to start?", playerName);
            string answer = Console.ReadLine().ToLower();
            if (answer =="yes" || answer =="yeah" || answer =="y" || answer =="ya")
            {
                Player player = new Player(playerName, bank);
                Game game = new BlackJackGame();
                game += player;
                player.isActivelyPlaying = true;
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    game.Play();
                }
                game -= player;
                Console.WriteLine("Thank you for playing!");
                

            }
            Console.WriteLine("Feel free to look around. Bye for now.");
            Console.ReadLine();
        }
    }
}
