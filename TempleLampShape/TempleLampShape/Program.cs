using System;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace TempleLampShape
{
    internal class Program
    {

        static void TempleLamp()
        {

            //Prints the temple lamp
            //*   *   *   *   *   *   *   *   *
            // *   *   *   *  *  *   *   *   * 
            //  *   *   *   * * *   *   *   *  
            //   *   *   *   ***   *   *   *   
            //    *   *   *   *   *   *   *    
            //     *   *   *  *  *   *   *     
            //      *   *   * * *   *   *      
            //       *   *   ***   *   *       
            //        *   *   *   *   *        
            //         *   *  *  *   *         
            //          *   * * *   *          
            //           *   ***   *           
            //            *   *   *            
            //             *  *  *             
            //              * * *              
            //               ***               
            //                *
            //                *
            //                *
            //                *
            //              * * *
            //             * * * *


            int row = 21;
            int col = 33;
            int temp = col;
            Console.ForegroundColor = ConsoleColor.Cyan;

            // to save to file pdf Temple Lamp shape
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("TempleOfLamp.pdf", FileMode.Create));
            document.Open();

            // Add title to the PDF document
            string title = "Temple of Lamp";
            Paragraph titleParagraph = new Paragraph(title, new Font(Font.FontFamily.COURIER, 18, Font.BOLD, BaseColor.BLACK));
            titleParagraph.Alignment = Element.ALIGN_CENTER;
            StringBuilder outputBuilder = new StringBuilder();
            document.Add(titleParagraph);
            Chunk emptyLine = new Chunk("\n");
            document.Add(emptyLine);

            for (int i = 0; i < row; i++)
            {
                Paragraph lineParagraph = null;
                Console.Write(String.Format("{0,45}", ""));
                int space = i < 16 ? i : 16;
                string patt = string.Format("{0," + space + "}", "") + "*";
                for (int j = 1; j < temp / 2; j++)
                {
                    patt += j % 4 == 0 ? "*" : " ";
                }
                temp = temp % 4 == 0 ? col : temp - 2;
                char[] charArray = patt.ToCharArray();
                if (i < 16)
                {
                    Console.Write(patt + "*");

                    Array.Reverse(charArray);
                    Console.WriteLine(charArray);
                    outputBuilder.AppendLine(new string(' ', 17) + patt + "*" + new string(charArray));
                    lineParagraph = new Paragraph(new string(' ', 17) + patt + "*" + new string(charArray), new Font(Font.FontFamily.COURIER, 12, Font.NORMAL, BaseColor.BLUE));
                }
                else
                {
                    Console.WriteLine(patt);
                    lineParagraph = new Paragraph(new string(' ', 17) + patt, new Font(Font.FontFamily.COURIER, 12, Font.NORMAL, BaseColor.BLUE));
                    outputBuilder.AppendLine(new string(' ', 17) + patt);
                }

                document.Add(lineParagraph);
            }
            File.WriteAllText("TempleOfLamp.txt", outputBuilder.ToString());
            document.Close();
        }
        static void Main(string[] args)
        {

            TempleLamp();
        }
    }
}
