using System;
using System.Collections.Generic;
using minimax.core.adversarial;

namespace minimax.tictactoe
{
    public class Game : IGame<State, Action, Player>
    {
            public List<Action> GetActions(State state)
            {
                //dato un campo prendere tutte le mosse possibili
                throw new NotImplementedException();
            }
                public State GetInitialState()  
            {
                //prendi lo stato iniziale (tutto vuoto)
                throw new NotImplementedException();
            } 
                public Player GetPlayer(State state)
            {
                //predi il giocatore corrente
                throw new NotImplementedException();
            }
                public Player[] GetPlayers()
            {
                //prendo giocatori
                throw new NotImplementedException();
            }
                public State GetResult(State state, Action action)
            {
                //ottieni risultato
                throw new NotImplementedException();
            }
                public double GetUtility(State state,Player player)
            {
                //crea un nuovo stato
                //copia il contenuto dello stato precedente nel nuovo stato
                //invertire giocatore
                throw new NotImplementedException();
            }
            public bool IsTerminal(State state)
            {
                //arrivati al termine di un sottoramo?
                throw new NotImplementedException();
            }
    }
}