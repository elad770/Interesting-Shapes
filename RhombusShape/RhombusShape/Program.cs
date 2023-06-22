using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RhombusShape
{
    internal class Program
    {

        public static void RecoDrawRhombus(int rows)
        {
            //A A wrapper function that draws a rhombus with an inner recursive function

            void InternalRecoDrawRhombus(int i, int adv, int c)
            {
                if (i == rows && rows % 2 == 1 || i > rows && rows % 2 == 0)
                {
                    return;
                }
                int r = rows;

                Console.Write(String.Format("{0,45}", "") +
                    String.Format("{0," + (r - adv) + "}", "") + new string('*', c - r + 1));

                if (r / 2 <= i)
                {
                    c -= 2;
                    adv--;
                }
                else
                {
                    adv++;
                    c += 2;
                }

                Console.WriteLine();
                InternalRecoDrawRhombus(++i, adv, c);
            }
            Console.Write(new string('\n', 3));
            InternalRecoDrawRhombus(0, 0, rows);

        }

        public static void DrawRhombus(int rows)
        {
            // A Wrapper function that draws a rhombus, used with an
            // inner function that draws two triangles regular and inverted triangle.
            // (in every run of the inner function that draws a triangle according to the sign variable)

            void InternalDrawRhombus(bool sign = false)
            {
                int r = (rows % 2 == 1 ? rows : rows + 1);
                int c = r;

                for (int i = 0; i <= r / 2; i++)
                {

                    int adv = (i + 1);
                    int actual_columns = c - adv;

                    if (!sign)
                    {
                        actual_columns = c / 2 + adv;
                        adv = c / 2 - i;
                    }
                    Console.Write(String.Format("{0,45}", ""));
                    for (int j = 0; j < actual_columns; j++)
                    {
                        Console.Write(j >= adv ? "*" : " ");
                    }
                    Console.WriteLine();
                }
            }
            InternalDrawRhombus();
            InternalDrawRhombus(true);

        }

        public static void DrawRhombusSimple(int rows)
        {
            //A function that draws a rhombus with one loop

            int r;
            int c = r = rows;
            int adv = 0;


            using (StreamWriter writer = new StreamWriter("RhombusShape.txt"))
            {
                for (int i = 0; i <= r; i++)
                {
                    if (i == r && r % 2 == 1)
                        return;
                    string format = String.Format("{0,45}", "") +
                        String.Format("{0," + (r - adv) + "}", "") + new string('*', c - r + 1);
                    writer.Write(format);
                    Console.Write(format);

                    if (r / 2 <= i)
                    {
                        c -= 2;
                        adv--;
                    }
                    else
                    {
                        adv++;
                        c += 2;
                    }
                    writer.WriteLine();
                    Console.WriteLine();
                }
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            DrawRhombus(new Random().Next(4, 23));
            Console.ForegroundColor = ConsoleColor.Red;
            DrawRhombusSimple(new Random().Next(4, 23));
            Console.ForegroundColor = ConsoleColor.Cyan;
            RecoDrawRhombus(new Random().Next(10, 23));
        }
    }
}
