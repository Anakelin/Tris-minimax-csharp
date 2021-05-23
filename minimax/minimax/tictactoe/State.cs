using System;

public class State
{
    private int[,] _campo;
    private int _currentPlayer;
        
    public State(int[,] campo, int player)
    {
        _campo = (int[,])campo;
        _currentPlayer = player;
    }

    public int Get_currentPlayer()
    {
        return _currentPlayer;
    }

    public int[,] Get_campo()
    {
        return _campo;
    }
    
    
}
