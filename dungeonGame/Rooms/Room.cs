using dungeonGame.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dungeonGame.Rooms
{
    internal class Room
    {
        internal string name = "";
        internal string description = "";
        public virtual string Introduction()
        {
            return "Вы открыли дверь и увидели " + name + " " + description;
        }
    }
    class Monster : Room
    {
        new string name = "комнату с врагом";
        new string description = "Где-то в темноте вас поджидает враг, защищайтесь";
        public override string Introduction()
        {
            return "Вы открыли дверь и увидели " + name + " " + description;
        }

    }
    class Empty : Room
    {
        new string name = "...";
        new string description = "вроде пусто";
         public override string Introduction()
        {
            return "Вы открыли дверь и увидели " + name + " " + description;
        }
    }
    class Trap : Room
    {
        new string name = "....";
        new string description = "оказывается не пусто";
         public  override string Introduction()
        {
            return "Вы открыли дверь и увидели " + name + " " + description;
        }
    }
    class Chest : Room
    {
        new string name = "комнату с сундуком";
        new string description = "здесь вы можете передохнуть и попробовать открыть сундук с предметами";
         public override string Introduction()
        {
            return "Вы открыли дверь и увидели " + name + " " + description;
        }
    }
    class Trader : Room
    {
        new string name = "торговца";
        new string description = "Вам подвернулась удача встретить человек в подземелье, вы можете купить у него зелье здоровья";
         public override string Introduction()
        {
            return "Вы открыли дверь и увидели " + name + " " + description;
        }
    }
    class Boss : Room
    {
        new string name = "Удачи";
        new string description = "Победите босса";
        public override string Introduction()
        {
            return name + "! " + description;
        }
    }
   

}
