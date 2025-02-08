using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonGame.Else
{
    internal class Question
    {
        public string question = "";
        public string answer = "" ;
        public Question()
        {
            Random random = new Random();
            if(random.Next(1,3) == 1)
            {
                question = "Ответь на вопрос и получи что-то: 2+2 = ?";
                answer = "4";
            }
            else if (random.Next(1, 3) == 2)
            {
                question = "Ответь на вопрос и получи что-то: быть или не быть?";
                answer = "быть";
            }
            else
            {
                question = "Ответь на вопрос и получи что-то: да или нет?";
                answer = "или";
            }

        }
    }
}
