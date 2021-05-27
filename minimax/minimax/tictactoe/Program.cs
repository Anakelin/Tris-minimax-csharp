using System;
using System.Collections.Generic;
using minimax.tictactoe;
using minimax;


namespace minimax.tictactoe
{
    public class Program
    {
        public int turno = 0;

        static void Main(string[] args)
        {

            Game g = new Game();
            State stato = g.GetInitialState();
            bool matchInProgress = true;
            int currentPlayer = g.FirstPlayer();
<<<<<<< HEAD
<<<<<<< HEAD
=======
            AdversarialSearch<State, Action> adversarialSearch;
            

>>>>>>> 2c3fc0e8df832312015c6815b19e131f29faa7b6
=======
            
>>>>>>> parent of 2c3fc0e (Implementato l'Ai)
            do
            {
                turno++
                Console.WriteLine("{0}° Turno",turno)
                stato.PrintBoard();

                if (currentPlayer == 0)
                {
                    //IA




                    currentPlayer = 1;
                }
                else
                {
<<<<<<< HEAD
<<<<<<< HEAD
                    //User

=======
                    Console.ReadKey();
>>>>>>> 2c3fc0e8df832312015c6815b19e131f29faa7b6
=======


>>>>>>> parent of 2c3fc0e (Implementato l'Ai)


                    currentPlayer = 0;
                }


                matchInProgress = g.IsTerminal(stato);
            } while (matchInProgress);



            /*
            // Test printBoard Ok
            State stato = new State();
            stato.RandomState();
            stato.PrintBoard();
            */

            /*
            // Test GetActions Ok
            State stato = new State();
            Game g = new Game();
            List<Action> legalMoves = g.GetActions(stato);
            foreach (Action move in legalMoves)
            {
                Console.WriteLine($"Riga: {move.Get_row()} Colonna: {move.Get_column()}");
            }
            */

            /*
            // Test GetResult Ok
            Game g = new Game();
            State stato = new State();
            State newState = g.GetResult(stato,new Action(2,2));
            newState.PrintBoard();
            */


            /*
            //test getInitialState ok
            State stato;
            Game g = new Game();
            stato = g.GetInitialState();
            stato.PrintBoard();
            */

            /*
            //test getPlayer ok
            State stato = new State();
            Game g = new Game();
            Player player1;
            player1 = g.GetPlayer(stato);
            Console.WriteLine(player1);
            */

            /*
            // Test IsVictory Ok
            Game g = new Game();
            State stato = g.GetInitialState();
            stato.RandomState();
            int victory = g.IsVictory(stato);
            stato.PrintBoard();
            Console.WriteLine(victory);
            */

            /*
            // Test NearVictory2 Ok
            Game g = new Game();
            State stato = g.GetInitialState();
            stato.RandomState();
            stato.PrintBoard();
            Console.WriteLine(g.NearVictory2(stato.Get_board()));
            */

            /*
            // Test IsNearVictory Ok
            Game g = new Game();
            State stato = g.GetInitialState();
            stato.RandomState();
            stato.PrintBoard();
            Console.WriteLine(g.IsNearVictory(stato));
            */

            /*
            // Test Getutility Ok
            Game g = new Game();
            //State stato = g.GetInitialState();
            //stato.RandomState();
            int[,] board = new int[,] {
                {0,-1,-1 },
                {-1,0,-1 },
                {-1,-1,-1 } 
            };
            State stato = new State(board,0);
            stato.PrintBoard();
            Console.WriteLine(g.GetUtility(stato,stato.Get_currentPlayer()));
            */

            /*
            //Test IsTerminal Ok
            Game g = new Game();
            State stato = g.GetInitialState();
            stato.RandomState();
            stato.PrintBoard();
            Console.WriteLine(g.IsTerminal(stato));
            */

            

            Console.WriteLine("END");
            Console.ReadKey();
        }
    }
}