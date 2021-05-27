using System;
using System.Collections.Generic;
using minimax.tictactoe;
using minimax;
using minimax.core.adversarial;


namespace minimax.tictactoe
{
    public class Program
    {
        public int turno = 0;

        static void Main(string[] args)
        {

            Game g = new Game();
            /*
            int[,] board = new int[,] {
            {-1,-1,-1 },
            {-1,1,-1 },
            {-1,-1,-1 }
            };
            */
            State stato = g.GetInitialState();
            int[,] board = stato.Get_board();
            int turnPlayer = (int)stato.Get_currentPlayer();
            //State stato = new State(board,Player.Cross);
            bool matchInProgress = true;
            int currentPlayer = g.FirstPlayer();
            AdversarialSearch<State, Action> adversarialSearch;
            int nTurno = 0;

            do
            {
                nTurno++;
                stato.PrintBoard();
                
                if (currentPlayer == 0)
                {
                    Console.Write("\n{0}° Turno, tocca all'IA. ",nTurno);
                    Console.ReadKey();
                    //IA
                    adversarialSearch = new MinimaxSearch<State, Action, Player>(g);
                    Action move = adversarialSearch.makeDecision(stato.DeepCopy());
                    g.GetResult(stato, move);

                    currentPlayer = 1;
                }
                else
                {
                    Console.Write("\n{0}° Turno, tocca a te! ", nTurno);
                    int row, col;
                    bool emptyCell;
                    Action mossaCorrente;
                    do
	                {   
                        emptyCell=false;
                        List<Action> legalMoves = new List<Action>();
                        Console.Write("\nInserire riga (0-1-2): ");
                        do
                        {
                            row = g.ReturnInt();
                            if (row < 0 || row > 2)
                            {
                                Console.Write("\nERRORE: Il numero deve essere 0, 1 o 2): ");
                            }
	                    } while (row < 0 || row > 2);
                    
                        Console.Write("\nInserire colonna (0-1-2): ");
                        do
	                    {
                            col = g.ReturnInt();
                            if (col < 0 || col > 2)
                            {
                                Console.Write("\nERRORE: Il numero deve essere 0, 1 o 2): ");
                            }
                        } while (col < 0 || col > 2);

                        mossaCorrente = new Action(row,col);
                        legalMoves = g.GetActions(stato);
                        
                        foreach (Action mossaLegale in legalMoves)
	                    {
                            if (mossaCorrente.Get_row() == mossaLegale.Get_row() && mossaCorrente.Get_column() == mossaLegale.Get_column())
                            {
                                emptyCell=true;
	                        }
	                    }

                        if (emptyCell==false)
                        {
                            Console.Write("\nERRORE: La cella selezionata e occupata! ");
                        }

                    } while (emptyCell==false);

                    stato = g.GetResult(stato, mossaCorrente);
                    currentPlayer = 0;
                }


                matchInProgress = !(g.IsTerminal(stato)); //Se non è terminale deve continuare
                //Console.WriteLine(matchInProgress);
            } while (matchInProgress);
            stato.PrintBoard();
            Console.WriteLine("\n\nEND");
            Console.ReadKey();


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
            State stato = g.GetInitialState();
            stato.RandomState();
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

        }
    }
}