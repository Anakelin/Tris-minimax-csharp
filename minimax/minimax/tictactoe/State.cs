using System;

namespace minimax.tictactoe
{
    public class State
    {
        //Attributi
        public const int EMPTY = -1,  CROSS = (int)Player.Cross, CIRCLE = (int)Player.Circle;
        private int[,] _board;
        private Player _currentPlayer;
        
        //Costruttori
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

<<<<<<< HEAD
        //Inizializazione casuale del campo
        public void RandomState()
        {
            int num;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Random rand = new Random();
                    num = rand.Next(-1, 2);
                    _board[row, col] = num;
                }
            }
        }
        
        //Stampa del campo corrente
        public void PrintBoard()
        {
            string[,] writeBoard = new string[3, 3];

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    switch (_board[row, col])
                    {
                        case -1:
                            writeBoard[row, col] = " ";
                            break;
                        case 0:
                            writeBoard[row, col] = "X";
                            break;
                        case 1:
                            writeBoard[row, col] = "O";
                            break;

                    }
                }

            }
            Console.WriteLine("╔═════════╦═════════╦═════════╗");
            Console.WriteLine("║         ║         ║         ║");
            Console.WriteLine($"║    {writeBoard[0, 0]}    ║    {writeBoard[0, 1]}    ║    {writeBoard[0, 2]}    ║");
            Console.WriteLine("║         ║         ║         ║");
            Console.WriteLine("╠═════════╬═════════╬═════════╣");
            Console.WriteLine("║         ║         ║         ║");
            Console.WriteLine($"║    {writeBoard[1, 0]}    ║    {writeBoard[1, 1]}    ║    {writeBoard[1, 2]}    ║");
            Console.WriteLine("║         ║         ║         ║");
            Console.WriteLine("╠═════════╬═════════╬═════════╣");
            Console.WriteLine("║         ║         ║         ║");
            Console.WriteLine($"║    {writeBoard[2, 0]}    ║    {writeBoard[2, 1]}    ║    {writeBoard[2, 2]}    ║");
            Console.WriteLine("║         ║         ║         ║");
            Console.WriteLine("╚═════════╩═════════╩═════════╝");
            
        }
        
        //Get di tutti gli attributi
=======
>>>>>>> parent of 8c5816f (Creazione Program.cs)
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
