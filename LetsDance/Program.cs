using System.Globalization;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Threading;

namespace LetsDance
{
    class Program
    {

        static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to Let´s Dance!");

            System.Console.WriteLine("Controls:");
            System.Console.WriteLine("up: Arw-UP | down: Arw-DOWN | left: Arw-LEFT | right: Arw-RIGHT");
            System.Console.WriteLine();
            System.Console.WriteLine("Press 'enter' to start");

            Console.ReadLine();

            string[] word = {"left", "right", "up", "down"};

            for (int i = 0; i < 30; i++)
            {
                DanceAction danceAction = new DanceAction();
            }

            int points = 0;
            int time = 60 * 100;
            // queuar första i queuelistan
            DanceAction queuedAction = DanceAction.danceActions.Dequeue();
            // meddans listan har instancer av danceAction.
            while (DanceAction.danceActions.Count > 0)
            {
                Thread.Sleep(10);
                time --;
                // skriv ut infor
                Console.WriteLine("PRESS " + queuedAction.DanceKey);

                ConsoleKey key = Console.ReadKey().Key;
                // om knapp neddtryckt är lika med knapp för danceaction dequeuea
                if (queuedAction.DanceKey == key)
                {
                    Console.Clear();
                    queuedAction = DanceAction.danceActions.Dequeue();
                    points += 5;
                }
                // om fel knapp neddtryckt; minus poäng
                else if (key != queuedAction.DanceKey && points > 0)
                {
                    points -= 2;
                }   
                // om tid = 0 innan klar avsluta loop
                if (time == 0) 
                {
                    time = 0;
                    break;
                }

            }
            if (time < 0)
            {
                time = 0;
            }

            // printa slut-info
            System.Console.WriteLine("TOTAL POINTS; " + time * points);
            System.Console.WriteLine("TIME; " + time);
            System.Console.WriteLine("POINTS; " + points);

            // vänta på readline innan avslutar
            Console.ReadLine();
        }
            
    }
        

    class DanceAction
    {
        // statisk lista med syfte att lagra alla instancer av DanceAtion
        static public Queue<DanceAction> danceActions = new Queue<DanceAction>();
        static Random generator = new Random();
        int action;
        private ConsoleKey c;

        // konstruktor DanceAction slumpar en ConsoleKey och sedan lägger till instansen i listan
        public DanceAction()
        {
            action = generator.Next(1,5);
            
            switch(action)
            {
                case 1:
                c = ConsoleKey.LeftArrow;
                break;

                case 2:
                c = ConsoleKey.RightArrow;
                break;

                case 3:
                c = ConsoleKey.UpArrow;
                break;

                case 4:
                c = ConsoleKey.DownArrow;
                break;
            }

            danceActions.Enqueue(this);
        }
        // propertien returnerar key
        public ConsoleKey DanceKey
        {
            get
            {
                return c;
            }
        }


    }
}

