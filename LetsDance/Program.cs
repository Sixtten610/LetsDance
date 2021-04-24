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

            for (int i = 0; i < 100; i++)
            {
                DanceAction danceAction = new DanceAction();
                System.Console.WriteLine(DanceAction.danceActions.Count);
            }

            Console.ReadLine();

            int timer =  60;
            while (timer > 0)
            {
                Thread.Sleep(1000);
                
                DanceAction queuedAction = DanceAction.danceActions.Peek();    

                System.Console.WriteLine("PRESS " + queuedAction.Action);
                System.Console.WriteLine("time left: " + timer);

                if (queuedAction.CheckActionTrue())
                {
                    DanceAction.danceActions.Dequeue();
                }

                timer--;
            }

            Console.ReadLine();
            
        }
    }

    class DanceAction
    {
        static public Queue<DanceAction> danceActions = new Queue<DanceAction>();
        string action;
        static Random generator = new Random();
        int word = generator.Next(1,4);

        public DanceAction()
        {
            action = RandAction();

            danceActions.Enqueue(this);
        }

        private string CheckAction()
        {
            int key = Raylib.GetKeyPressed();
            switch(key)
            {
                case (int)KeyboardKey.KEY_LEFT:
                return "left";

                case (int)KeyboardKey.KEY_RIGHT:
                return "right";

                case (int)KeyboardKey.KEY_UP:
                return "up";

                case (int)KeyboardKey.KEY_DOWN:
                return "down";
            }
            return "";
        }

        private string RandAction()
        {
            switch (word)
            {
                case 1:
                return "left";
                
                case 2:
                return "right";

                case 3:
                return "up";

                case 4:
                return "down";
            }

            return "";
        }

        public bool CheckActionTrue()
        {
            if (CheckAction() == action)
            {
                return true;
            }
            return false;
        }

        public string Action
        {
            get
            {
                return action;
            }
        }


    }
}

