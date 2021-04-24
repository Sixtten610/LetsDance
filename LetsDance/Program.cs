using System;
using System.Collections.Generic;

namespace LetsDance
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class DanceAction
    {
        static public Queue<DanceAction> danceActions = new Queue<DanceAction>();
        string action;
        static Random generator = new Random();

        public DanceAction()
        {
            action = RandAction();

            danceActions.ToArray();
        }

        private string RandAction()
        {
            int word = generator.Next(1,4);

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

