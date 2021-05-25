using System;
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
            int[,] campo = stato.Get_board();
            string[,] campovisto = new string[3,3];
            
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    switch (campo[row, col])
                    {
                        case -1:
                            campovisto[row, col] = " ";
                            break;
                        case 0:
                            campovisto[row, col] = "X";
                            break;
                        case 1:
                            campovisto[row, col] = "O";
                            break;

                    }
                }
                
            }

            Console.WriteLine("╔═════════╦═════════╦═════════╗");
            Console.WriteLine("║         ║         ║         ║");
            Console.WriteLine($"║    {campovisto[0,0]}    ║    {campovisto[0, 1]}    ║    {campovisto[0, 2]}    ║");
            Console.WriteLine("║         ║         ║         ║");
            Console.WriteLine("╠═════════╬═════════╬═════════╣");
            Console.WriteLine("║         ║         ║         ║");
            Console.WriteLine($"║    {campovisto[1,0]}    ║    {campovisto[1,1]}    ║    {campovisto[1,2]}    ║");
            Console.WriteLine("║         ║         ║         ║");
            Console.WriteLine("╠═════════╬═════════╬═════════╣");
            Console.WriteLine("║         ║         ║         ║");
            Console.WriteLine($"║    {campovisto[2,0]}    ║    {campovisto[2,1]}    ║    {campovisto[2,2]}    ║");
            Console.WriteLine("║         ║         ║         ║");
            Console.WriteLine("╚═════════╩═════════╩═════════╝");
            Console.ReadKey();
 
        }
    }
}