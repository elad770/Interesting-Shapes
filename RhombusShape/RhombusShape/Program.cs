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
        /*
          A program that shows some functions with techniques 
          for printing a rhombus on the screen
                      *
                     ***
                    *****   
                   *******
                  *********
                   *******                                    
                    *****  
                     ***
                      *
         */

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

        public static void DrawRhombusSimple2(int rows)
        {
            //A function that draws a rhombus in a fairly simple way, the idea is to
            //create a normal triangle in the opposite way and save it and 
            //while printing the normal triangle and then print the inverted triangle

            string sign = "*";
            string triangles = "";
            string t = new string('\t', 6);
            rows = rows % 2 == 0 ? rows + 1 : rows;
            for (int i = 0; i <= rows / 2; i++)
            {
                string format = string.Format("{0," + (rows / 2 - i) + "}", "");
                Console.WriteLine(t + format + sign);

                // Create a string of triangles in reverse
                triangles += '\n' + sign + format + t;

                // triangles += t + format + sign + '\n';
                sign += "**";
            }

            // Running from the end to the beginning - 8 character: this 1 the
            // last character, 6 is of '\t' and 1 of '\n'
            for (int i = triangles.Length - (rows + 8); i >= 0; i--)
            {
                Console.Write(triangles[i]);
            }

            // A second way, instead of running through all the characters 
            // in the string itself, you can split the string according to the \n character
            // into lines and run from the end of the array to the beginning (note that 
            // you need to run from the third term from the end and not from the second!
            // and the string of the triangle in the first loop in the usual order )

            /*string[] spilt = triangles.Split('\n');
            for (int i = spilt.Length - 3; i >= 0; i--)
            {
                Console.WriteLine(spilt[i]);
            }*/

        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            DrawRhombusSimple2(new Random().Next(4, 23));
            Console.ForegroundColor = ConsoleColor.Blue;
            DrawRhombus(new Random().Next(4, 23));
            Console.ForegroundColor = ConsoleColor.Red;
            DrawRhombusSimple(new Random().Next(4, 23));
            Console.ForegroundColor = ConsoleColor.Cyan;
            RecoDrawRhombus(new Random().Next(4, 23));
        }
    }
}
