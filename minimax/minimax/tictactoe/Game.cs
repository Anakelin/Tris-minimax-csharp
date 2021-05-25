using System;
using System.Collections.Generic;
using minimax.core.adversarial;

namespace minimax.tictactoe
{
    public class Game : IGame<State, Action, Player>
    {
            public List<Action> GetActions(State state)
            {
                throw new NotImplementedException();
            }
                public State GetInitialState()  
            {
                throw new NotImplementedException();
            } 
                public Player GetPlayer(State state)
            {
                throw new NotImplementedException();
            }
                public Player[] GetPlayers()
            {
                throw new NotImplementedException();
            }
                public State GetResult(State state, Action action)
            {
                throw new NotImplementedException();
            }
                public double GetUtility(State state,Player player)
            {
                throw new NotImplementedException();
            }
            public bool IsTerminal(State state)
            {
                throw new NotImplementedException();
            }
    }
}