using System;
using System.IO;
using Casino;
using Casino.BlackJack;

namespace BlackJack_ClassesAndObjects__Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            const string casinoName = "St James's Casino";

            Console.WriteLine("Welcome to {0}. Please tell us your name.", casinoName);
            string playerName = Console.ReadLine();

            bool validAnswer = false;
            int bank = 0;
            while (!validAnswer)
            {
                Console.WriteLine("How much money are you willing to lose today?");
                validAnswer = int.TryParse(Console.ReadLine(), out bank);
                if (!validAnswer) Console.WriteLine("Please enter digits only, no decimals");
            }
            

            Console.WriteLine("Hey, {0}. Are you ready to start?", playerName);
            string answer = Console.ReadLine().ToLower();
            if (answer =="yes" || answer =="yeah" || answer =="y" || answer =="ya")
            {
                Player player = new Player(playerName, bank);
                player.Id = Guid.NewGuid();
                using (StreamWriter file = new StreamWriter(@"C:\Coding\log.txt", true))
                {
                    file.WriteLine(player.Id);
                }
                Game game = new BlackJackGame();
                game += player;
                player.isActivelyPlaying = true;
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    try
                    {
                        game.Play();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("An error occured. Please contact your System Administrator.");
                        Console.ReadLine();
                        return;
                    }
                    
                }
                game -= player;
                Console.WriteLine("Thank you for playing!");
                

            }
            Console.WriteLine("Feel free to look around. Bye for now.");
            Console.ReadLine();
        }
    }
}
