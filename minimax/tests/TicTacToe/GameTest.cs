using System;
//using Xunit;
using minimax.tictactoe;

public class GameTest
{
	public const int COL = 3, ROW = 3;
	public const int EMPTY = -1;
	public GameTest()
	{
		int[,] board = Inizialize();
		//int[,] board = RandInizialize();
		/*
		*/
		
		Player contestant = Player.Cross;
		State situation = new State(board,(int)contestant);
	}
	public int[,] Inizialize()
    {
		int[,] board = new int[COL,ROW];
        for (int i = 0; i < ROW; i++)
        {
            for (int j = 0; j < COL; j++)
            {
                board[i, j] = EMPTY;
            }
        }
		return board;
    }
	/*
	public int[,] RandInizialize()
    {
		Random rand = new Random();
		int tmp;
		int[,] board = new int[COL,ROW];
        for (int i = 0; i < ROW; i++)
        {
            for (int j = 0; j < COL; j++)
            {
				tmp=rand.Next(-1,2);
                board[i, j] = tmp;
            }
        }
		return board;
    }
	
	public int RandTurnPlayer(int[,] board)
	{
		int tmp = 0;
		int nCross = 0;
		int nCircle = 0;
		for (int i = 0; i < ROW; i++)
        {
            for (int j = 0; j < COL; j++)
            {
				if (board[i,j] == 0)
				{
					nCross++;
				}
				else if (board[i,j] == 1)
				{
					nCircle++;
				}
            }
        }

		if (nCross<=nCircle)
		{
			tmp=1;
		}

		return tmp;
	}
	*/
}
