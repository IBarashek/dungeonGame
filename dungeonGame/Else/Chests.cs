using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonGame.Else
{
    internal class Chests
    {
        public int money = 0;
        public Question question;
        public Potions potion;
        public Chests()
        {
            Random random = new Random();
            if (random.Next(1, 3) == 1)
            {
                money = 10;
                question = new Question();
            }
            else if (random.Next(1, 3) == 2)
            {
                potion = new Potions();
                question = new Question();
            }

            else
            {
                money = 20;
                question = new Question();
            }
        }

    }
}
