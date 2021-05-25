using System;

namespace minimax.tictactoe
{
    public class State
    {
        public const int EMPTY = -1,  CROSS = (int)Player.Cross, CIRCLE = (int)Player.Circle;
        private int[,] _board;
        private Player _currentPlayer;
            
        public State()
        {
            _board = new int[3,3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _board[i, j] = EMPTY;
                }
                _currentPlayer = (Player)CROSS;
            }
        }
        public State(int[,] board, Player player)
        {
            _board = (int[,])board;
            _currentPlayer = player;
        }

        public Player Get_currentPlayer()
        {
            return _currentPlayer;
        }

        public int[,] Get_board()
        {
            return _board;
        }
        
        public int GetBoardState(int row,int col)
        {
            return _board[row,col];
        }
        
    }

}
