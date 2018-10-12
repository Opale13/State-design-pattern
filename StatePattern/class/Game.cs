using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class Game
    {
        private StateGame state;
        private int currentPlayer;
        private List<Player> players = new List<Player>();
        private bool endGame = false;

        public Game(Player player1, Player player2)
        {
            players.Add(player1);
            players.Add(player2);
        }
        
        public void NextTurn()
        {
            state.NextTurn(this);
        }
        

        public StateGame SetState { set => state = value; }

        public List<Player> Players { get => players; }

        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }

        public bool EndGame { get => endGame; set => endGame = value; }
    }
}
