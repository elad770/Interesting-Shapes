using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareCircleShape
{
    internal class Program
    {




        public static void SquareCircle(int rows)
        {

            int columns = rows + 4;
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"{new string('\t', 5)}");
                for (int j = 0; j < columns; j++)
                {
                    if ((j >= 2 && j <= columns - 3) && (i == 0 || i == rows - 1)
                        || (j == 1 || j == columns - 2) && (i == 1 || i == rows - 2)
                        || (j == 0 || j == columns - 1) && (i > 1 && i < rows - 2)
                        )
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

        }

        public static void SquareCircleWithFormat(int rows)
        {
            Console.WriteLine();
            for (int i = 0; i < rows; i++)
            {

                string format = new string('\t', 5);
                int count_shape = rows - 4;
                if (i == rows - 1 || i == 0)
                {
                    format += $"  {new string('*', (rows))}";
                }
                else if (i == rows - 2 || i == 1)
                {
                    format += $" *{new string(' ', (rows))}*";
                }
                else
                {
                    format += $"*{new string(' ', (rows + 2))}*";
                }
                Console.WriteLine(format);

            }


        }


        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int rand = new Random().Next(4, 12);
            Console.WriteLine($"{new string('\t', 5)}Darw Square Circle:\n");
            SquareCircle(rand);

            Console.WriteLine($"{new string('\n', 3)}{new string('\t', 5)}Darw Square Circle With Format:");

            SquareCircleWithFormat(rand);
        }
    }
}
