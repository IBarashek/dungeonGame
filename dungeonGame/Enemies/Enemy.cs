using dungeonGame.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonGame.Enemies
{
    class Enemy
    {
        public string name = "Зомби";
        public string description = "очень злобное создание";
        public double health = 50;
        public int money = 0;
        public int Atack()
        {
            Random random = new Random();
            money += random.Next(1, 3);
            return random.Next(10, 15);
        }
    }
}
