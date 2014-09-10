using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_2_rita_med_asterisker
{
    class Program
    {

        static void Main(string[] args)
        {
            //Deklarerar lokala variabler
            byte maxWidth = 79;

            do
            {
                ReadOddByte(String.Format(Strings.NumberAsteriskQuestion_Prompt, maxWidth),maxWidth);
            }
            while(IsContinuing());
        }
        /// <summary>
        /// Kollar om användaren vill avsluta programmet eller fortsätta köra programmet en gång till
        /// </summary>
        /// <returns>Ett boolean värde</returns>
        private static bool IsContinuing()
        {
            Console.WriteLine("\n");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Strings.EndQuestion_Prompt);
            Console.ResetColor();
            Console.WriteLine("\n");
            
            return (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        /// <summary>
        /// Ska läsa in ett udda heltal av typen byte från användaren
        /// </summary>
        /// <param name="prompt">Felmeddelande som ska visas om användaren visar fel värde</param>
        /// <param name="maxValue">Maxvärde som användaren kan mata in</param>
        /// <returns>Ett udda heltal av typen byte</returns>
        private static byte ReadOddByte(String prompt=null,byte maxValue = 255)
        {
            // Deklarerar lokal variabel
            byte readValue = 0;

            // Läser in och returnerar en byte
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    readValue = byte.Parse(Console.ReadLine());
                    if (readValue > maxValue)
                    {
                        throw new ApplicationException();
                    }
                    return readValue;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();         
                    Console.WriteLine(String.Format(Strings.Error_Message, maxValue));
                    Console.WriteLine();   
                    Console.ResetColor();
                }
            }
            
            return 255;
        }
        /// <summary>
        /// Ritar ut diamanten
        /// </summary>
        /// <param name="maxCount">Ger antalet asterisker diamentens midja ska ha</param>
        private static void RenderDiamond(byte maxCount)
        {

        }
        /// <summary>
        /// Ritar ut en rad i diamanten
        /// </summary>
        /// <param name="maxCount">Midjans läng (längsta raden asterisker)</param>
        /// <param name="asteriskCount">Längden på raden</param>
        private static void RenderRow(int maxCount,int asteriskCount)
        {

        }
    }
}
