using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonGame.Player
{
    internal class MainPlayer
    {
        private string name = "Noname";
        protected double health = 100;
        private int money = 0;
        private Inventory inventory = new Inventory();
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Health
        {
            get { return health; }
            set { health = value; }
        }
        public int Money
        {
            get { return money; }
            set { money = value; }
        }
        public Inventory Inventory
        {
            get { return inventory; }
            set { inventory = value; }

        }
    }
}
