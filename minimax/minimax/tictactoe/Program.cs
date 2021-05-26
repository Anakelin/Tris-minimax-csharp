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
            /*
            // Test printBoard Ok
            State stato = new State();
            stato.RandomState();
            stato.PrintBoard();
            */

            /*
            // Test GetActions Ok
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
            State newState = g.GetResult(stato,new Action(1,1));
            newState.PrintBoard();
            */
        }
    }
}