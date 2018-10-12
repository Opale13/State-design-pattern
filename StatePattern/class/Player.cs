using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class Player
    {
        private Random rnd = new Random();
        private string pseudo;
        private int life;

        public Player(string pseudo)
        {
            this.pseudo = pseudo;
            this.life = 100;
        }

        public int Attack() { return rnd.Next(25); }


        public string Pseudo { get => pseudo; }

        public int Life { get => life; set => life = value;  }
    }
}
