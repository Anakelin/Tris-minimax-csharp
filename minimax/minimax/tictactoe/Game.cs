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
            throw new NotImplementedException();
        }
            public State GetResult(State state, Action action)
        {
            int[,] board = state.Get_board();
            board[action.Get_row(), action.Get_column()] = (int)state.Get_currentPlayer();
            State newState = new State(board,state.Get_currentPlayer());
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
                return IsNearVictory(state);
            }
        }
        public bool IsTerminal(State state)
        {
            throw new NotImplementedException();
        }
        
        public int IsVictory(State state)
        {
            //getplayers ancora non implementato se implementato togliere la riga sotto getPlayers
            //Player[] players = GetPlayers(); 
            Player[] players = new Player[] { Player.Cross, Player.Circle };
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
            Player[] players = new Player[] { Player.Cross, Player.Circle };
            foreach (Player player in players)
            {
                for (int row = 0; row < 3; row++)
                {
                    bool rowComb0 = board[row, 0] == (int)player && board[row, 1] == (int)player;
                    bool rowComb1 = board[row, 0] == (int)player && board[row, 2] == (int)player;
                    bool rowComb2 = board[row, 1] == (int)player && board[row, 2] == (int)player;
                    rowComb = rowComb0 || rowComb1 || rowComb2 || rowComb;
                }

                for (int col = 0; col < 3; col++)
                {
                    bool colComb0 = board[0, col] == (int)player && board[1, col] == (int)player;
                    bool colComb1 = board[0, col] == (int)player && board[2, col] == (int)player;
                    bool colComb2 = board[1, col] == (int)player && board[2, col] == (int)player;
                    colComb = colComb0 || colComb1 || colComb2 || colComb;
                }

                bool diaComb = (board[0, 0] == (int)player && board[1, 1] == (int)player) || ((board[0, 0] == (int)player && board[2, 2] == (int)player) || board[1, 1] == (int)player && board[2, 2] == (int)player);
                bool diaCombR = (board[0, 2] == (int)player && board[1, 1] == (int)player) || ((board[0, 2] == (int)player && board[2, 0] == (int)player) || board[1, 1] == (int)player && board[2, 0] == (int)player);

                if (rowComb || colComb || diaComb || diaCombR)
                {
                    return (int)player; 
                }
            }
            return -1;
        }
    }
}