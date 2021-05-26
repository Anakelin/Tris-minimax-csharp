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
            throw new NotImplementedException();
        }
        public bool IsTerminal(State state)
        {
            throw new NotImplementedException();
            int[,] board = state.Get_board();
            board[action.Get_row(), action.Get_column()] = (int)state.Get_currentPlayer();

            //righe
            for (int i = 0; i < length; i++)
			{
                if ()
	            {
                    
	            }
			}
        }
    }
}