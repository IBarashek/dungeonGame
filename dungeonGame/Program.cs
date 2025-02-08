using dungeonGame.Enemies;
using dungeonGame.Player;
using dungeonGame.Rooms;
using dungeonGame.Else;
string answer;
MainPlayer Player  = new MainPlayer();
Console.WriteLine("Введите имя пользователя ");
string stroka = Console.ReadLine();
do
{
    if (stroka != "")
        Player.Name = stroka; //Имя игрока
    else
    {
        Console.WriteLine("Вы не ввели имя пользователя. Введите имя пользователя");
        stroka = Console.ReadLine();
    }
}
while(stroka == "");
Console.WriteLine("Добро пожаловать, " + Player.Name + " куда-то");
Game game = new Game(); // Создание игры из 10 комнат
Random random = new Random();
Console.WriteLine("\n\r----------------------------------------------------------------------------\n\r");
for (int i = 0; i < 9; i++)
{
    int rnd = random.Next(1, 5);
    switch (rnd)
    {
        case 1: game.rooms[i] = new Monster(); break;
        case 2: game.rooms[i] = new Empty(); break;
        case 3: game.rooms[i] = new Trap(); break;
        case 4: game.rooms[i] = new Chest(); break;
        case 5: game.rooms[i] = new Trader(); break;
    }
}
game.rooms[9] = new Boss();
Enemy enemy = new Enemy();
int number;
for(int i = 0; i < 9 && Player.Health > 0;i++)
{
      Console.WriteLine(game.rooms[i].Introduction());
    if (game.rooms[i].Introduction() == new Monster().Introduction())
    {
            enemy = new Enemy();
        Console.WriteLine("Вас атаковал " + enemy.name + ". Чем будете отбиваться? Если хотите выбрать меч, нажмите 1, если хотите выбрать лук, нажмите 2 (учтите если у вас нет стрел, вы не сможете атаковать и пропустите ход");
        do
        {
            answer = Console.ReadLine();
            Player.Inventory.firstCell.Atack();
            double swordDamage = Player.Inventory.firstCell.damage;
            int count = Player.Inventory.thirdCell.count;
            int enemyDamage = enemy.Atack();
            Player.Inventory.secondCell.Atack(count);
            double bowDamage = Player.Inventory.secondCell.damage;
            if (answer == "1")
            {
                Console.WriteLine("Вы нанесли врагу " + swordDamage + "нажмите enter чтобы продолжить");
                Console.ReadLine();
                enemy.health -= swordDamage;
            }
            else if (answer == "2")
            {
                if (count > 0)
                {
                    Console.WriteLine("Вы нанесли врагу " + bowDamage + "нажмите enter");
                    Console.ReadLine();
                    enemy.health -= bowDamage; 
                }
                else
                {
                    Console.WriteLine("У вас нет стрел, вы замешкались " + "нажмите enter чтобы продолжить");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Такого варианта нет, во время битвы нельзя отвлекаться." + "нажмите enter чтобы продолжить");
                Console.ReadLine();
            }
            if(enemy.health > 0)
            {
                Console.WriteLine("Вас ударил враг и нанес " + enemyDamage + " урона");
                Player.Health -= enemyDamage;
                Console.WriteLine(Player.Name + " у вас осталось " + Player.Health + " здоровья" + "нажмите enter чтобы продолжить");
                Console.ReadLine();
                Console.WriteLine("Чем будете отбиваться? Если хотите выбрать меч, нажмите 1, если хотите выбрать лук, нажмите 2 (учтите если у вас нет стрел, вы не сможете атаковать и пропустите ход");
            }
            else
            {
                Console.WriteLine("Вы убили врага" + "нажмите enter чтобы продолжить");
                Console.ReadLine();
            }
        }
        while (enemy.health > 0 && Player.Health > 0);
        
    }
    else if (game.rooms[i].Introduction() == new Empty().Introduction())
    {
        Console.WriteLine("Тут пусто, можешь идти дальше" + "нажмите enter чтобы продолжить");
        Console.ReadLine();
    }
    else if (game.rooms[i].Introduction() == new Trap().Introduction())
    {
        number = random.Next(10,20);
        Player.Health -= number;
        Console.WriteLine("Ты попал в ловушку и получил урон. У тебя осталось " + Player.Health + " здоровья" + "нажмите enter чтобы продолжить");
        Console.ReadLine();
    }
    else if (game.rooms[i].Introduction() == new Chest().Introduction())
    {
        Console.WriteLine("Тебе повезло, в этой комнате есть сундук, попробуй его взломать" + "нажмите enter чтобы продолжить");
        Console.ReadLine();
        Chests chest = new Chests();
        Console.WriteLine(chest.question.question);
        do
        {
            answer = Console.ReadLine();
            if (answer == chest.question.answer)
            {
                if (chest.money != 0)
                {
                    Player.Inventory.fourthCell.count += 1;
                    Console.WriteLine("Вы получили зелье здоровья с сундука. Теперь у вас есть " + Player.Inventory.fourthCell.count + "зелий" + "нажмите enter чтобы продолжить");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Вы получили монеты с сундука в размере: " + chest.money );
                    Player.Money += Convert.ToInt32(chest.money);
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Попробуйте еще раз или напишите 1, чтобы пойти дальше");
                Console.ReadLine();
            }
        }
        while (answer == chest.question.answer && answer == "1"); 
    }
    else if (game.rooms[i].Introduction() == new Trader().Introduction())
    {
        Console.WriteLine("Не хотите преобрести зелье здоровья всего за 30 монет? - спросил торговец. 1 - да, 2 - нет");        
        do
        {
            answer = Console.ReadLine();
            if (answer == "1")
            {
                if (Player.Money >= 30)
                {
                    Player.Money -= 30;
                    Console.WriteLine("Поздравляю, теперь у тебя есть еще одно зелье здоровья");
                }
                else
                {
                    Console.WriteLine("У тебя не хватает денег, топай отсюда");
                }
            }
            else if (answer == "2")
            {
                Console.WriteLine("Хорошо, иди давай отсюда");
            }
            else
            {
                Console.WriteLine("Такого варианта нет, но вы можете попробовать снова");
            }
        }
        while (answer != "1" && answer != "2");
    }
    if (Player.Health <= 0)
    {
        Console.WriteLine("Вы проиграли!");

    }
    else
    {
        Console.WriteLine("Вы можете использовать залье здоровья или пойти дальше? 1 - следующая комната, 2 - использовать зельье здоровья");
        do
        {
            answer = Console.ReadLine();
            if (answer == "2" || answer == "0")
            {
                if (Player.Inventory.fourthCell.count > 0)
                {
                    Player.Inventory.fourthCell.UseHealPotions();
                    Player.Health += Player.Inventory.fourthCell.heal;
                    Player.Inventory.fourthCell.count -= 1;
                    Console.WriteLine(Player.Name + " у вас осталось " + Player.Health + " здоровья." + "нажмите enter чтобы продолжить");
                }
                else
                Console.WriteLine("У вас не осталось зелий здоровья ");
                Console.WriteLine("Отлично идем дальше это была " + (i + 1) + " комната из 10");
                Console.WriteLine(Player.Name + " у вас осталось " + Player.Health + " здоровья и " + Player.Money + " монет" + "нажмите enter чтобы продолжить");
                Console.ReadLine();
            }

            else if (answer == "1")
            {
                Console.WriteLine("Отлично идем дальше это была " + (i + 1) + " комната из 10" + "нажмите enter чтобы продолжить");
                Console.ReadLine();
                Console.WriteLine(Player.Name + " у вас осталось " + Player.Health + " здоровья и " + Player.Money + " монет" + "нажмите enter чтобы продолжить");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Такого варианта нет, но вы можете попробовать снова" + "нажмите enter чтобы продолжить");
                Console.ReadLine();
            }
        }
        while (answer != "1" && answer != "2");
        Console.WriteLine("За прохождения комнаты вы увлечили свое здоровье на 20 хп" + "нажмите enter чтобы продолжить");
        Console.ReadLine();
        Player.Health += 20;
        Console.WriteLine("\n\r----------------------------------------------------------------------------\n\r");
    }
    
}
if(Player.Health > 0)
{
    Console.WriteLine("Битва с боссом. Если хотите выбрать меч, нажмите 1, если хотите выбрать лук, нажмите 2 (учтите если у вас нет стрел, вы не сможете атаковать и пропустите ход");
    double bossHealth = 100;
    double bossDamage;
    do
    {
        answer = Console.ReadLine();
        bossDamage = random.Next(10,20);
        Player.Inventory.firstCell.Atack();
        double swordDamage = Player.Inventory.firstCell.damage;
        int count = Player.Inventory.thirdCell.count;
        Player.Inventory.secondCell.Atack(count);
        double bowDamage = Player.Inventory.secondCell.damage;
        if (answer == "1")
        {
            Console.WriteLine("Вы нанесли врагу " + swordDamage + "нажмите enter чтобы продолжить");
            Console.ReadLine();
            bossHealth -= swordDamage;
        }
        else if (answer == "2")
        {
            if (count > 0)
            {
                Console.WriteLine("Вы нанесли врагу " + bowDamage + "нажмите enter чтобы продолжить");
                Console.ReadLine();
                bossHealth -= bowDamage;
            }
            else
            {
                Console.WriteLine("У вас нет стрел, вы замешкались" + "нажмите enter чтобы продолжить");
                Console.ReadLine();
            }
        }
        else
        {
            Console.WriteLine("Такого варианта нет, во время битвы нельзя отвлекаться." + "нажмите enter чтобы продолжить");
            Console.ReadLine();
        }
        if (bossHealth > 0)
        {
            Console.WriteLine("У босса осталось " + bossHealth + " здоровья");
            Console.WriteLine("Вас ударил враг и нанес " + bossDamage + " урона");
            Player.Health -= bossDamage;
            Console.WriteLine(Player.Name + " у вас осталось " + Player.Health + " здоровья" + "нажмите enter чтобы продолжить");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Вы убили врага" + "нажмите enter чтобы продолжить");
            Console.ReadLine();
        }
    }
    while (enemy.health > 0 && Player.Health > 0);

}



