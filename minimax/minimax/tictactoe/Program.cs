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
            /*
            int[,] board = new int[,] {
            {-1,-1,-1 },
            {-1,1,-1 },
            {-1,-1,-1 }
            };
            */
            Game g = new Game();
            State stato = g.GetInitialState();
            int[,] board = stato.Get_board();
            int turnPlayer = (int)stato.Get_currentPlayer();
            //State stato = new State(board,Player.Cross);
            bool matchInProgress = true;

            int howManyPlayers = g.HowManyPlayers();
            bool P1isIA = true;
            bool P2isIA = true;
            switch (howManyPlayers)
            {
                case 0: break;
                case 1: int FirstPlayer = g.FirstPlayer();
                    if (FirstPlayer==0)
                    {
                        P2isIA = false;
                    }
                    else
                    {
                        P1isIA = false;
                    }
                    break;
                case 2: P1isIA = false; P2isIA = false; break;
                default: Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine("ERRORE SOVRANNATURALE: Nessuna casistica dovrebbe portarti qui... se viene dato questo messaggio non ci possiamo + fidare di C#"); break;
            }
            
            AdversarialSearch<State, Action> adversarialSearch;
            int nTurno = 0;
            bool player1Turn = true;

            do
            {
                nTurno++;
                stato.PrintBoard();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                if (player1Turn)
                {
                    Console.Write("\n{0}° Turno, tocca al 1° giocatore: ",nTurno);
                    if (P1isIA)
                    {
                        stato = g.PlayIA(out adversarialSearch, stato, g);
                    }
                    else
                    {
                        stato = g.PlayUser(stato);
                    }
                    player1Turn = false;
                }
                else
                {
                    Console.Write("\n{0}° Turno, tocca al 2° giocatore: ", nTurno);
                    if (P2isIA)
                    {
                        stato = g.PlayIA(out adversarialSearch, stato, g);
                    }
                    else
                    {
                        stato = g.PlayUser(stato);
                    }
                    player1Turn = true;
                }


                matchInProgress = !(g.IsTerminal(stato)); //Se non è terminale deve continuare
            } while (matchInProgress);
            stato.PrintBoard();

            int segnoVincitore = g.IsVictory(stato);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (segnoVincitore == -1)
            {
                if (P1isIA && P2isIA)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\n\nLo scontro è stato decisivo, lo stato di equilibrio dell'IA è stato raggiunto");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine("Parità");
                }
            }
            else if (segnoVincitore == 0)
            {
                if (P1isIA)
                {
                    Console.WriteLine("Vince il primo giocatore (IA)!");
                }
                else
                {
                    Console.WriteLine("Vince il primo giocatore (user)!");
                }
            }
            else if (segnoVincitore == 1)
            {
                if (P2isIA)
                {
                    Console.WriteLine("Vince il secondo giocatore (IA)!");
                }
                else
                {
                    Console.WriteLine("Vince il secondo giocatore (user)!");
                }

            }

            Console.ForegroundColor = ConsoleColor.White;
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