
using System;
using static System.Collections.Specialized.BitVector32;
using static System.Formats.Asn1.AsnWriter;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Меню:\n1. Игра 'Угадай число'\n2. Таблица умножения\n3. Вывод делителей числа\n4. Game\n5. Exit");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                GuessNumber();
            }
            else if (choice == 2)
            {
                MultiplicationTable();
            }
            else if (choice == 3)
            {
                Divisors();
            }
            else if (choice == 4)
            {
                Gmain();
            }
            else if (choice == 5)
            {
                break;
            }
            else
            {
                Console.WriteLine("Неверный выбор, попробуйте еще раз");
            }
        }
    }

    static void GuessNumber()
    {
        Random random = new Random();
        int randomNumber = random.Next(0, 101);
        int guess = -1;
        while (guess != randomNumber)
        {
            Console.Write("Введите число от 0 до 100: ");
            guess = int.Parse(Console.ReadLine());
            if (guess < randomNumber)
            {
                Console.WriteLine("Загаданное число больше");
            }
            else if (guess > randomNumber)
            {
                Console.WriteLine("Загаданное число меньше");
            }
        }
        Console.WriteLine("Победа!");
    }

    static void MultiplicationTable()
    {
        Console.Write("Введите число для таблицы умножения: ");
        int n = int.Parse(Console.ReadLine());
        int[,] table = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                table[i, j] = (i + 1) * (j + 1);
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0}\t", table[i, j]);
            }
            Console.WriteLine();
        }
    }

    static void Divisors()
    {
        Console.Write("Введите число: ");
        int num = int.Parse(Console.ReadLine());
        Console.Write("Делители числа {0}: ", num);
        for (int i = 1; i <= num; i++)
        {
            if (num % i == 0)
            {
                Console.Write("{0} ", i);
            }
        }
        Console.WriteLine();
    }
   
public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public Player(string name, int health, int attack, int defense)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }
    }

public class Bot
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public Bot(string name, int health, int attack, int defense)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }
    }



public class Game
    {
        private Player player;
        private Bot bot;

        public Game()
        {
            // Создаем игрока и бота с начальными значениями
            player = new Player("Player", 100, 10, 5);
            bot = new Bot("Bot", 100, 8, 4);
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the Jurassic World: The Game!");

            while (true)
            {
                // Показываем текущее состояние игрока и бота
                Console.WriteLine("Player: " + player.Name + " | Health: " + player.Health);
                Console.WriteLine("Bot: " + bot.Name + " | Health: " + bot.Health);

                // Игрок выбирает действие (атака или защита)
                Console.WriteLine("Choose an action: ");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Defend");

                int choice = int.Parse(Console.ReadLine());

                // В зависимости от выбора игрока выполняем соответствующее действие
                switch (choice)
                {
                    case 1:
                        // Игрок наносит удар боту
                        int playerDamage = player.Attack - bot.Defense;
                        bot.TakeDamage(playerDamage);
                        Console.WriteLine("Player attacked Bot for " + playerDamage + " damage.");
                        break;
                    case 2:
                        // Игрок защищается от атаки бота
                        int botDamage = bot.Attack - player.Defense;
                        player.TakeDamage(botDamage);
                        Console.WriteLine("Player defended against Bot's attack and took " + botDamage + " damage.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        continue;
                }

                // Проверяем, не закончилась ли игра (если у игрока или бота здоровье равно 0)
                if (player.Health == 0)
                {
                    Console.WriteLine("Player lost the game. Game Over!");
                    break;
                }
                else if (bot.Health == 0)
                {
                    Console.WriteLine("Player won the game. Congratulations!");
                    break;
                }

                // Бот выбирает действие (случайным образом)
                int botChoice = new Random().Next(1, 3);

                switch (botChoice)
                {
                    case 1:
                        // Бот наносит удар игроку
                        int botDamage = bot.Attack - player.Defense;
                        player.TakeDamage(botDamage);
                        Console.WriteLine("Bot attacked Player for " + botDamage + " damage.");
                        break;
                    case 2:
                        // Бот защищается от атаки игрока
                        int playerDamage = player.Attack - bot.Defense;
                        bot.TakeDamage(playerDamage);
                        Console.WriteLine("Bot defended against Player's attack and took " + playerDamage + " damage.");
                        break;
                }
            }
        }
    }



        static void Gmain()
        {
            Game game = new Game();
            game.Start();
        }
    }
  