using System;
using System.Collections.Generic;
using minimax.core.adversarial;

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
                    if (board[row,col] == -1)
                    {
                        legalMoves.Add(new Action(row,col));
                    }
                }
            }
            return legalMoves;
        }
       
        public int FirstPlayer()
        {
            bool loop = true;
            Console.WriteLine("Chi inizia per primo?");
            do
            {
                Console.WriteLine("0 - IA || 1 - Player");
                int scelta = ReturnInt();
                switch (scelta)
                {
                    case 0: return 0; 
                    case 1: return 1;
                    default: Console.Write("ERRORE: Dovresti inserire "); break;
                }
            } while (loop);
            return -1;
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
            int[,] board = state.Get_board();
            board[action.Get_row(), action.Get_column()] = (int)GetPlayer(state);

            State newState;
            if (GetPlayer(state) == Player.Cross)
            {
                newState = new State(board, Player.Circle);
            }
            else
            {
                newState = new State(board, Player.Cross);
            }
            
            return newState;
        }
        
        public double GetUtility(State state,Player player)
        {
            int winner;
            if (IsTerminal(state))
            {
                winner = IsVictory(state);
                if (winner != -1)
                {
                    if (winner == (int)player)
                    {
                        return double.PositiveInfinity - 1;
                    }
                    else
                    {
                        return double.NegativeInfinity + 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if(IsNearVictory(state) != 0)
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
                        if (board[0, 0] == currentPlayer || board[2, 0] == currentPlayer || board[2, 0] == currentPlayer || board[2, 2] == currentPlayer)
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

                    return 0;
                }
                
            }
        }
     
        public bool IsTerminal(State state)
        {
            int[,] board = state.Get_board();

            int isWin = IsVictory(state);

            if (isWin !=-1)
            {
                if (isWin == 0)
               	{
                    Console.WriteLine("X Vince!");
            	}
                else
	            {
                    Console.WriteLine("O Vince!");
	            }
                return true;
            }
            else
            {
                if (Program.turno >= 9)
                {
                    return true;
                }
                else
	            {
                    return false;
	            }
	
                /*
                for (int row = 0; row < 3; row++)
		    	{
                     for (int col = 0; col < 3; col++)
		             {
                          if (board[row,col] == -1)
	                      {
                                 return false;
	                      }
		             }
		    	}
                */
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
            
            return -1;
        }

        public double IsNearVictory(State state)
        {
            int[,] board = state.Get_board();
            int currentPlayer = (int)state.Get_currentPlayer();
            int winner = NearVictory2(board);
            if (winner != -1)
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
                    bool rowComb0 = board[row, 0] == (int)player && board[row, 1] == (int)player && board[row, 2] == -1;
                    bool rowComb1 = board[row, 0] == (int)player && board[row, 2] == (int)player && board[row, 1] == -1;
                    bool rowComb2 = board[row, 1] == (int)player && board[row, 2] == (int)player && board[row,0]== -1;
                    rowComb = rowComb0 || rowComb1 || rowComb2 || rowComb;
                }

                for (int col = 0; col < 3; col++)
                {
                    bool colComb0 = board[0, col] == (int)player && board[1, col] == (int)player && board[2, col] == -1;
                    bool colComb1 = board[0, col] == (int)player && board[2, col] == (int)player && board[1, col] == -1;
                    bool colComb2 = board[1, col] == (int)player && board[2, col] == (int)player && board[0, col] == -1;
                    colComb = colComb0 || colComb1 || colComb2 || colComb;
                }

                bool diaComb = (board[0, 0] == (int)player && board[1, 1] == (int)player && board[2, 2] == -1) || (board[0, 0] == (int)player && board[2, 2] == (int)player && board[1, 1] == -1) || (board[1, 1] == (int)player && board[2, 2] == (int)player && board[0, 0] == -1);
                bool diaCombR = (board[0, 2] == (int)player && board[1, 1] == (int)player && board[2, 0] == -1) || (board[0, 2] == (int)player && board[2, 0] == (int)player && board[1, 1] == -1) || (board[1, 1] == (int)player && board[2, 0] == (int)player && board[0, 2] == -1);

                if (rowComb || colComb || diaComb || diaCombR)
                {
                    return (int)player; 
                }
            }
            return -1;
        }

        public int ReturnInt()
        {
            int n = -1;
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
                    Console.WriteLine("ERRORE: Il numero deve essere intero!");
                }
            } while (loop);
            return n;
        }    
    }
}