using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonGame.Player
{
    class Bow
    {
        public string nameWeapon = "Палка с ниткой (лук)";
        public string description = "Им лучше стрелять нежели чем бить";
        public double damage = 0;
        public void Atack(int countArrows) 
        {
            Random random = new Random();
            if (countArrows > 0)
            {
               damage = random.Next(5, 15);
            }
        }
    }
    class Sword
    {
        public string nameWeapon = "Меч";
        public string description = "Меньше читай больше мечом махай";
        public double damage = 0;
        public void Atack()
        {
            Random random = new Random();
            damage = random.Next(10, 20);
        }
    }
    class Arrows
    {
        public string nameWeapon = "Палка c острым концом";
        public string description = "Главное не сила, а их количество";
        public double damage = 0;
        public int count = 5;
    }
}
