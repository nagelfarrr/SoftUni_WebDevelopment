using System;
using System.Linq;

namespace _06.Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] cols = Console.ReadLine().Split().Select(int.Parse).ToArray();

                jaggedArray[row] = new int[cols.Length];

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] =cols[col];
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                    break;

                string[] commands = input.Split();
                string commandType = commands[0];
                int rowToModify = int.Parse(commands[1]);
                int colToModify = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if (rowToModify < 0 || rowToModify >= jaggedArray.Length || colToModify < 0 ||
                    colToModify >= jaggedArray.Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (commandType == "Add")
                    {
                        jaggedArray[rowToModify][colToModify] += value;
                    }
                    else if (commandType == "Subtract")
                    {
                        jaggedArray[rowToModify][colToModify] -=value;
                    }
                }
            }

            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }
    }
}
