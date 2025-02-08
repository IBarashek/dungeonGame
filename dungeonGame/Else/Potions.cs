using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonGame.Else
{
    class Potions
    {
        public string name = "Зелье здоровья";
        public string description = "Восстанавливает здоровье игрока на случайное значение от 10 до 20";
        public int heal = 0;
        public int count = 3;
        public void UseHealPotions()
        {
            Random random = new Random();
            heal = random.Next(10, 20);
        }
    }
}
