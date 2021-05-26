using System;
using System.Collections.Generic;
using minimax.tictactoe;
using minimax;


namespace minimax.tictactoe
{
    public class Program
    {
        static void Main(string[] args)
        {
            State stato = new State();
            stato.RandomState();
            stato.PrintBoard();
            /*
            // Test GetActions
            Game g = new Game();
            List<Action> legalMoves = g.GetActions(stato);
            foreach (Action move in legalMoves)
            {
                Console.WriteLine($"Riga: {move.Get_row()} Colonna: {move.Get_column()}");
            }
            */
        }
    }
}