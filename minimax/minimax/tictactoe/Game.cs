﻿using System;
using System.Collections.Generic;
using minimax.core.adversarial;
using minimax.tictactoe;

namespace minimax.tictactoe
{
    public class Game : IGame<State, Action, Player>
    {
        public List<Action> GetActions(State state)
        {
            int[,] board = state.Get_board();
            List<Action> legalMoves = new List<Action>();
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row,col] == State.EMPTY)
                    {
                        legalMoves.Add(new Action(row,col));
                    }
                }
            }
            /*
            Random rng = new Random();
            int n = legalMoves.Count;
            while (n>1)
            {
                n--;
                int k = rng.Next(n + 1);
                Action tmp = legalMoves[k];
                legalMoves[k] = legalMoves[n];
                legalMoves[n] = tmp;
            }
            */
            return legalMoves;
        }
       
        public int HowManyPlayers()
        {
            bool incorrect = true;
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Quanti utenti giocano?"); Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Console.WriteLine("0 - 1 - 2");
                int scelta = ReturnInt();
                switch (scelta)
                {
                    case 0: return 0;
                    case 1: return 1;
                    case 2: return 2;
                    default: Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("ERRORE: Dovresti inserire "); Console.ForegroundColor = ConsoleColor.White; break;
                }
            } while (incorrect);
            return 1;
        }
        public int FirstPlayer()
        {
            bool incorrect = true;
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Chi inizia per primo?"); Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Console.WriteLine("0 - IA || 1 - Player");
                int scelta = ReturnInt();
                switch (scelta)
                {
                    case 0: return 0; 
                    case 1: return 1;
                    default: Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("ERRORE: Dovresti inserire "); Console.ForegroundColor = ConsoleColor.White; break;
                }
            } while (incorrect);
            return State.EMPTY;
        }

        public State PlayIA(out AdversarialSearch<State, Action> adversarialSearch, State stato, Game g)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue; Console.Write("IA."); Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            adversarialSearch = new MinimaxSearch<State, Action, Player>(g);
            Action move = adversarialSearch.makeDecision(stato);
            stato = GetResult(stato, move);
            return stato;
        }
        public State PlayUser(State stato)
        {

            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write("Utente."); Console.ForegroundColor = ConsoleColor.White;

            int row, col;
            bool emptyCell;
            Action mossaCorrente;
            do
            {
                emptyCell = false;
                List<Action> legalMoves = new List<Action>();
                Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write("\nInserire riga (0-1-2): "); Console.ForegroundColor = ConsoleColor.White;
                do
                {
                    row = ReturnInt();
                    if (row < 0 || row > 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("\nERRORE: Il numero deve essere 0, 1 o 2): "); Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (row < 0 || row > 2);

                Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write("Inserire colonna (0-1-2): "); Console.ForegroundColor = ConsoleColor.White;
                do
                {
                    col = ReturnInt();
                    if (col < 0 || col > 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("\nERRORE: Il numero deve essere 0, 1 o 2): "); Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (col < 0 || col > 2);

                mossaCorrente = new Action(row, col);
                legalMoves = GetActions(stato);

                foreach (Action mossaLegale in legalMoves)
                {
                    if (mossaCorrente.Get_row() == mossaLegale.Get_row() && mossaCorrente.Get_column() == mossaLegale.Get_column())
                    {
                        emptyCell = true;
                    }
                }

                if (emptyCell == false)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("\nERRORE: La cella selezionata e occupata! "); Console.ForegroundColor = ConsoleColor.White;
                }

            } while (emptyCell == false);

            stato = GetResult(stato, mossaCorrente);
            return stato;
        }

        public State GetInitialState()  
        {
            State stato = new State();
            return stato;
        } 
          
        public Player GetPlayer(State state)
        {
            Player currentPlayer = state.Get_currentPlayer();
            return currentPlayer;
        }
          
        public Player[] GetPlayers()
        {
            Player[] bothPlayers = new Player[] {Player.Cross,Player.Circle};
            return bothPlayers;
        }

        public State GetResult(State state, Action action)
        {
            State newState = new State();

            newState.Set_board((int[,])state.Get_board().Clone());
            newState.Set_currentPlayer(state.Get_currentPlayer());
            newState.Get_board()[action.Get_row(), action.Get_column()] = (int)newState.Get_currentPlayer();

            if (GetPlayer(newState) == Player.Cross)
            {
                newState.Set_currentPlayer(Player.Circle);
            }
            else
            {
                newState.Set_currentPlayer(Player.Cross);
            }
            return newState;
        }

        public double GetUtility(State state,Player player)
        {
            int winner;
            if (IsTerminal(state))
            {
                winner = IsVictory(state);
                if (winner != State.EMPTY)
                {
                    if (winner == (int)player)
                    {
                        return 20;
                    }
                    else
                    {
                        return -20;
                    }
                }
                else
                {
                    return 0;
                }
            }
            /*
            else
            {
                if (IsNearVictory(state) != 0)
                {
                    return IsNearVictory(state);
                }
                else
                {
                    int[,] board = state.Get_board();
                    int currentPlayer = (int)state.Get_currentPlayer();

                    //Prima mossa
                    if (currentPlayer == (int)Player.Cross)
                    {
                        //Se è Giocatore 1
                        if (board[0, 0] == currentPlayer || board[0, 2] == currentPlayer || board[2, 0] == currentPlayer || board[2, 2] == currentPlayer)
                        {
                            return 0.5;
                        }
                    }
                    else
                    {
                        //Se è Giocatore 2

                        if (board[1, 1] == currentPlayer)
                        {
                            return 0.75;
                        }
                    }

                    
                }
            }
            */
            return 0;
        }
     
        public bool IsTerminal(State state)
        {
            int[,] board = state.Get_board();

            int isWin = IsVictory(state);

            if (isWin != State.EMPTY)
            {
                return true;
            }
            else
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (board[row, col] == State.EMPTY)
                        {
                            return false;
                        }
                    }
                }
            }
             return true;
        }
        
        public int IsVictory(State state)
        {
            Player[] players = GetPlayers(); 
            foreach (Player player in players)
            {
                int[,] board = state.Get_board();
                for (int row = 0; row < 3; row++)
                {
                    if (board[row,0] == (int)player && board[row,1] == (int)player && board[row,2] == (int)player)
                    {
                        
                        return (int)player;
                    }
                }
                for (int col = 0; col < 3; col++)
                {
                    if (board[0,col] == (int)player && board[1,col] == (int)player && board[2,col] == (int)player)
                    {
                        
                        return (int)player;
                    }
                }
                if (board[0,0] == (int)player && board[1,1] == (int)player && board[2,2] == (int)player)
                {
                    
                    return (int)player;
                }
                if (board[0,2] == (int)player && board[1,1] == (int)player && board[2,0] == (int)player)
                {
                    
                    return (int)player;
                }
            }
            
            return State.EMPTY;
        }

        public double IsNearVictory(State state)
        {
            int[,] board = state.Get_board();
            int currentPlayer = (int)state.Get_currentPlayer();
            int winner = NearVictory2(board);
            if (winner != State.EMPTY)
            {
                if (winner == currentPlayer)
                {
                    return 0.9;
                }
                else
                {
                    return -0.9;
                }
            }
            else
            {
                return 0;
            }
            
        }

        public int NearVictory2(int[,] board)
        {
            bool rowComb = false;
            bool colComb = false;
            Player[] players = GetPlayers();
            foreach (Player player in players)
            {
                for (int row = 0; row < 3; row++)
                {
                    bool rowComb0 = board[row, 0] == (int)player && board[row, 1] == (int)player && board[row, 2] == State.EMPTY;
                    bool rowComb1 = board[row, 0] == (int)player && board[row, 2] == (int)player && board[row, 1] == State.EMPTY;
                    bool rowComb2 = board[row, 1] == (int)player && board[row, 2] == (int)player && board[row,0]== State.EMPTY;
                    rowComb = rowComb0 || rowComb1 || rowComb2 || rowComb;
                }

                for (int col = 0; col < 3; col++)
                {
                    bool colComb0 = board[0, col] == (int)player && board[1, col] == (int)player && board[2, col] == State.EMPTY;
                    bool colComb1 = board[0, col] == (int)player && board[2, col] == (int)player && board[1, col] == State.EMPTY;
                    bool colComb2 = board[1, col] == (int)player && board[2, col] == (int)player && board[0, col] == State.EMPTY;
                    colComb = colComb0 || colComb1 || colComb2 || colComb;
                }

                bool diaComb = (board[0, 0] == (int)player && board[1, 1] == (int)player && board[2, 2] == State.EMPTY) || (board[0, 0] == (int)player && board[2, 2] == (int)player && board[1, 1] == State.EMPTY) || (board[1, 1] == (int)player && board[2, 2] == (int)player && board[0, 0] == State.EMPTY);
                bool diaCombR = (board[0, 2] == (int)player && board[1, 1] == (int)player && board[2, 0] == State.EMPTY) || (board[0, 2] == (int)player && board[2, 0] == (int)player && board[1, 1] == State.EMPTY) || (board[1, 1] == (int)player && board[2, 0] == (int)player && board[0, 2] == State.EMPTY);

                if (rowComb || colComb || diaComb || diaCombR)
                {
                    return (int)player; 
                }
            }
            return State.EMPTY;
        }

        public int ReturnInt()
        {
            int n = State.EMPTY;
            bool loop;
            do
            {
                loop = false;
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    loop = true;
                    Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("ERRORE: Il numero deve essere intero!"); Console.ForegroundColor = ConsoleColor.White;
                }
            } while (loop);
            return n;
        }    
    }
}