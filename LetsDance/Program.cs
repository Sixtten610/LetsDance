using System;
using System.Collections.Generic;
using System.Windows.Input;

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
            }

            int timer = 6 * 600;
            while (timer > 0)
            {
                DanceAction queuedAction =  DanceAction.danceActions.Peek();    

                System.Console.WriteLine(queuedAction.Action);





                timer--;
            }
            
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

            danceActions.ToArray();
        }

        private void CheckAction()
        {
            switch()
        }

        public string Action
        {
            get
            {
                return action;
            }
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


    }
}

