using System;
namespace minimax.tictactoe
{
	public class Action
	{
		public int row;
		public int column;

		public Action(int row, int column)
		{
			this.row=row;
			this.column=column;
		}

		public int row
		{
			get { return row; }
		}
	
		public int column
		{
			get { return column; }
		}
	}
}
	
