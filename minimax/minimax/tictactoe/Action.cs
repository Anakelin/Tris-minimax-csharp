using System;
namespace minimax.tictactoe
{
	public class Action
	{
		public int row;
		public int column;

		public Action(int r, int c)
		{
			this.row=r;
			this.column=c;
		}

		public int Get_row()
		{
			 return row; 
		}
	
		public int Get_column()
		{
			return column; 
		}
	}
}
	
