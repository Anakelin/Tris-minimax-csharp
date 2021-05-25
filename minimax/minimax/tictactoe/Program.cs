using System;
using minimax.tictactoe;
using minimax;


namespace minimax.tictactoe
{
    public class Program
    {
        

        static void Main(string[] args)
        {
            State stato = new State();
            //stato.RandomState();
            int[,] campo = stato.Get_board();
            stato.PrintBoard();
            Console.ReadKey();
        }

        
    }
}