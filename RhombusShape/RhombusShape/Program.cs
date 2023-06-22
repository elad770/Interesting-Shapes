using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhombusShape
{
    internal class Program
    {

        public static void DrawRhombus(int rows)
        {
            int r;
            int c = r = rows;
            int adv = 0;

            using (StreamWriter writer = new StreamWriter("torah.txt"))
            {
                for (int i = 0; i <= r; i++)
                {

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

        //public static void DarwRhombus(int rows)
        //{
        //    int r;
        //    int c = r = rows;
        //    int adv = 0;
        //    for (int i = 0; i <= r; i++)
        //    {

        //        Console.Write(String.Format("{0,45}", "") +
        //            String.Format("{0," + (r - adv) + "}", "") + new string('*', c - r + 1));

        //        if (r / 2 <= i)
        //        {
        //            c -= 2;
        //            adv--;
        //        }
        //        else
        //        {
        //            adv++;
        //            c += 2;
        //        }
        //        Console.WriteLine();
        //    }
        //}


        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            DrawRhombus(new Random().Next(4, 23));
        }
    }
}
