using System;

namespace Lab5._2_a
{
    enum Roshambo
    {
        Rock,
        Paper,
        Scissors
    }

    class Player
    {
        public string playerName;
        public Roshambo choice;
        public string roboName;

        public virtual Roshambo GenerateRoshambo()
        {
            Console.Write("Enter your name: ");
            playerName = Console.ReadLine();
            return choice;
        }
    }

    class RobotOne : Player
    {
        public new string roboName = "Robot One";
        public override Roshambo GenerateRoshambo()
        {
            choice = Roshambo.Rock;
            Console.WriteLine($"{roboName} chose {choice}");

            return choice;
        }
    }

    class RobotTwo : Player
    {
        public new string roboName = "Robot Two";

        public override Roshambo GenerateRoshambo()
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 3);
            Roshambo choice = (Roshambo)num;

            Console.WriteLine($"{roboName} chose {choice}");

            return choice;
        }
    }

    class Human : Player
    {
        public override Roshambo GenerateRoshambo()
        {
            Console.Write("Rock, Paper, or Scissors? (R/P/S): ");
            string rps = Console.ReadLine().ToUpper();

            if (rps == "R")
                choice = Roshambo.Rock;
            else if (rps == "P")
                choice = Roshambo.Paper;
            else if (rps == "S")
                choice = Roshambo.Scissors;
            Console.WriteLine($"{playerName} chose {choice}");

            return choice;
        }
    }

    class Program
    {
        static void WhoWon(Player left, Player right)
        {
            if (left.choice == right.choice)
            {
                Console.WriteLine("Draw!");
            }
            else if (left.choice == Roshambo.Rock && right.choice == Roshambo.Paper)
            {
                Console.WriteLine($"Winner is {right}");
            }
            else
            {
                Console.WriteLine($"Winner is {left}");
            }
        }

        static void Main(string[] args)
        {
            bool cont = true;

            Player play = new Player();
            play.GenerateRoshambo();

            Console.Write("Which Robot do you want to play against, 1 or 2?: ");
            int roboChoice = Int32.Parse(Console.ReadLine());

            if (roboChoice == 1)
            {
                play = new RobotOne();
            }
            else if (roboChoice == 2)
            {
                play = new RobotTwo();
            }
            else
            {
                Console.WriteLine("Thats not a valid choice.");
            }
            while (cont)
            {
                Human user = new Human();
                user.GenerateRoshambo();
                //Console.WriteLine($"{user.playerName} chose {userChoice}");

                play.GenerateRoshambo();
                //Console.WriteLine($"{play.roboName} chose {roboPlay}");

                bool validYN = false;
                while (!validYN)
                {
                    Console.Write("Play again? (y/n) ");
                    string yn = Console.ReadLine();
                    if (yn != "Y" && yn != "y" && yn != "n" && yn != "N")
                    {
                        Console.WriteLine("Please enter y or n");
                    }
                    else
                    {
                        validYN = true;
                        if (yn == "N" || yn == "n")
                        {
                            Console.WriteLine("Goodbye!");
                            cont = false;
                        }
                    }
                }

            }
        }
    }
}
