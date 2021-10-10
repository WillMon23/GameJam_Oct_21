using System;
using System.Collections.Generic;
using System.Text;

namespace GameJam_Oct_21
{
    class Engine
    {
        private static bool _applicationShouldExit;
        // Checks if the game has ended yet 
        private bool gameOver = false;
        // Creats an instance of a board 
        private Plot _gameBoard;

        /// <summary>
        /// Runs the Starts, Draw, Updatw and End Functions 
        /// </summary>
        public void Run()
        {
            Start();

            while (!gameOver)
            {
                
                Draw();
                Update();
                Console.Clear();
            }

            End();
        }

        /// <summary>
        /// Initilazes The Board
        /// </summary>
        private void Start()
        {
            _gameBoard = new Plot();
            _gameBoard.Start();
        }

        private void Draw()
        {
            Console.Clear();
            _gameBoard.Draw();

        }

        private void Update()
        {
            _gameBoard.Update();
        }

        private void End()
        {
            _gameBoard.End();
        }

        public static int GetInput(string description, params string[] options)
        {
            int choice = -1;
            Console.WriteLine(description);

            for (int i = 0; i < options.Length; i++)
                Console.WriteLine((i+1) + ". " + options[i] );
            Console.Write("> ");

            while (choice == -1)
            {
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    choice--;
                    if (choice < 0 || choice >= options.Length)
                    {
                        choice = -1;
                        Console.WriteLine("Invalde Input");
                    }
                }
                else
                {
                    choice = -1;
                    Console.WriteLine("Invalde Input");
                }
            }
            return choice;

        }
    }
}
