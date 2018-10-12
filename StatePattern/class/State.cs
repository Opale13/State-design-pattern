using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public interface StateGame
    {
        void NextTurn(Game game);
    }

    public class StartGame : StateGame
    {
        private Random rnd = new Random();

        public StartGame() { }

        public void NextTurn(Game game)
        {
            game.CurrentPlayer = rnd.Next(2);

            Console.WriteLine("The first player is " + game.Players[game.CurrentPlayer].Pseudo);

            game.SetState = new MidGame();
        }
    }

    public class MidGame : StateGame
    {
        public MidGame() { }

        public void NextTurn(Game game)
        {
            int damage = 0;
            int selectAttacker = game.CurrentPlayer;
            int selectDefender = (selectAttacker + 1) % 2;

            Player attacker = game.Players[selectAttacker];
            Player defender = game.Players[selectDefender];            

            if (attacker.Pseudo != "IA")
            {
                Console.WriteLine("Voulez vous attaquer ? (y/n)");
                string response =  Console.ReadLine();

                if (response == "y")
                {
                    damage = attacker.Attack();
                }

            } else
            {
                damage = attacker.Attack();
            }
            
            defender.Life = defender.Life - damage;
            
            Console.WriteLine(attacker.Pseudo + " attaque de: " + damage);
            Console.WriteLine("Il reste " + defender.Life + " point de vie à " + defender.Pseudo);

            if (defender.Life > 0)
            {
                game.SetState = new MidGame();
                game.CurrentPlayer = selectDefender;

            } else
            {
                game.SetState = new EndGame();
                game.NextTurn();
            }
        }
    }

    public class EndGame : StateGame
    {
        public EndGame() { }

        public void NextTurn(Game game)
        {
            Player winner = game.Players[game.CurrentPlayer];

            game.EndGame = true;

            Console.WriteLine("\r\nThe winner is " + winner.Pseudo + " !");
            Console.ReadKey();
        }
    }
}
