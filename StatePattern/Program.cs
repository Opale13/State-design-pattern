using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pseudo player1: ");
            string nameOne = Console.ReadLine();

            Player player1 = new Player(nameOne);
            Player player2 = new Player("IA");

            Game game = new Game(player1, player2);
            game.SetState = new StartGame();

            int turn = 1;
            while (!game.EndGame)
            {
                game.NextTurn();
              
                Console.WriteLine("\r\n>Turn " + turn);     
                
                turn++;
            }            
        }
    }
}
