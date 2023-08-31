using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text.pdf.parser;
using static iTextSharp.text.pdf.PdfDocument;

namespace StarDavid
{


    internal class Program
    {

        static void StarDavid(int row)
        {
            //darw Star-David to example:
            //          *
            //         * *
            //        *   *
            // *******************
            //  *   *       *   *
            //   * *         * *
            //    *           *
            //   * *         * *
            //  *   *       *   *
            // *******************
            //        *   *
            //         * *
            //          *



            int r = row * 4;
            r++;

            Array consoleColors = Enum.GetValues(typeof(ConsoleColor));
            ConsoleColor randomColor = (ConsoleColor)consoleColors.GetValue(new Random().Next(consoleColors.Length));

            int maxWidth = row * 6 + 1;
            string row_star = new string('*', maxWidth);

            // Create pdf file to save shape Star David
            Document document = new Document();
            string title = "Star of David";
            Paragraph titleParagraph = new Paragraph(title, new Font(Font.FontFamily.COURIER, 18, Font.BOLD, BaseColor.BLACK));
            titleParagraph.Alignment = Element.ALIGN_CENTER;

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("StarDavid.pdf", FileMode.Create));
            document.Open();
            document.Add(titleParagraph);
            Chunk emptyLine = new Chunk("\n");
            document.Add(emptyLine);

            int col = row_star.Length / 2 + 1;
            int temp = col;
            int prog = -1;
            Console.WriteLine();
            for (int x = 0; x < r; x++, col++)
            {
                string line = "";
                Console.Write(string.Format("{0,38}", ""));

                if (r / 4 <= x)
                {
                    prog++;
                }
                for (int y = 0; y < row_star.Length; y++)
                {
                    if (r / 4 == x || r * 3 / 4 == x || col - 1 == y || temp - 1 - x == y || (y == prog || y == row_star.Length - 1 - prog))
                    {

                        Console.ForegroundColor = randomColor;
                        Console.Write("*");
                        line += "*";
                    }
                    else
                    {
                        Console.Write(" ");
                        line += " ";
                    }
                }
                Console.WriteLine();

                int div = row < 7 ? 2 : 3;
                document.Add(new Paragraph(new string(' ', int.Parse(43.ToString()) / div) + line, new Font(Font.FontFamily.COURIER, 12, Font.NORMAL, BaseColor.BLUE)));

            }
            document.Close();


        }

        static void Main(string[] args)
        {
            StarDavid(new Random().Next(3, 9));
        }
    }
}
