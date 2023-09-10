using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hourglass
{
    internal class Program
    {

        static void DrawHourglass(int rows)
        {
            if (rows % 2 != 1)
            {
                rows++;
            }
            int totalColunm = rows;
            int x = 0;
            for (int i = 0; i < rows; i++)
            {
                Console.Write("\t\t");
                for (int j = 0; j < rows; j++)
                {
                    if (j % 2 == 0 && (i == 0 || i == rows - 1) || j == i || j == totalColunm - i - 1)
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


        static void DrawHourglass2(int rows)
        {
            if (rows % 2 != 1)
            {
                rows++;
            }
            int totalColunm = rows;
            int x = 0;
            for (int i = 0; i <= rows; i++)
            {
                Console.Write("\t\t");
                for (int j = 0; j < totalColunm; j++)
                {
                    if (j >= x)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                if (i < rows / 2)
                {
                    totalColunm--;
                    x++;
                }
                else if (i > rows / 2)
                {
                    totalColunm++;
                    x--;
                }
                Console.WriteLine();
            }

        }


        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            DrawHourglass2(22);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            DrawHourglass(22);

        }
    }
}
