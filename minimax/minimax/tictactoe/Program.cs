﻿using System;
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



        }
    }
}