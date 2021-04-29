using System;
using System.Collections.Generic;
using Raylib_cs;
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

            for (int i = 0; i < 100; i++)
            {
                DanceAction danceAction = new DanceAction();
            }

            DanceAction queuedAction = DanceAction.danceActions.Dequeue();

            while (DanceAction.danceActions.Count > 0)
            {

                Console.WriteLine("PRESS " + word[queuedAction.Action]);
                
                if (queuedAction.Action == Key())
                {
                    DanceAction.danceActions.Dequeue();
                }
            }

            Console.ReadLine();

            int Key()
            {
                // int k = Raylib.GetKeyPressed();
                // switch(k)
                // {
                //     case (int)KeyboardKey.KEY_LEFT:
                //     return 1;

                //     case (int)KeyboardKey.KEY_RIGHT:
                //     return 2;

                //     case (int)KeyboardKey.KEY_UP:
                //     return 3;

                //     case (int)KeyboardKey.KEY_DOWN:
                //     return 4;
                // }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                {
                    return 1;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    return 2;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                {
                    return 3;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    return 4;
                }

                return 10;
            }
        }
            
    }
        

    class DanceAction
    {
        static public Queue<DanceAction> danceActions = new Queue<DanceAction>();
        static Random generator = new Random();
        int action;

        public DanceAction()
        {
            action = generator.Next(1,5);

            danceActions.Enqueue(this);
        }

        public int Action
        {
            get
            {
                return action;
            }
        }


    }
}

