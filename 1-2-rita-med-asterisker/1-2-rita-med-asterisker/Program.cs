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
            byte diamondSize = 0;

            do
            {
                // Anropar metoden ReadOddbyte för att få diamantens storlek från användaren
                diamondSize = ReadOddByte(String.Format(Strings.NumberAsteriskQuestion_Prompt, maxWidth), maxWidth);

                // Anropar metoden för att rita diamanten 
                RenderDiamond(diamondSize);
            }
            while (IsContinuing());
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
        private static byte ReadOddByte(String prompt = null, byte maxValue = 255)
        {
            // Deklarerar lokal variabel
            byte readValue = 0;

            // Läser in och returnerar en byte från användaren
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    readValue = byte.Parse(Console.ReadLine());

                    // Kontrollerar så att inmatat värde varken är mer än maxvärdet och så att det är ett udda tal
                    if (readValue > maxValue || readValue % 2 == 0)
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

        }
        /// <summary>
        /// Ritar ut diamanten
        /// </summary>
        /// <param name="maxCount">Ger antalet asterisker diamentens midja ska ha</param>
        private static void RenderDiamond(byte maxCount)
        {
            // Anropar metoden som ritar en rad i diamanten lika många gånger som variabeln maxCount anger
            for (int i = 0; i < maxCount; i++)
            {
                RenderRow((int)maxCount, i);
            }

        }
        /// <summary>
        /// Ritar ut en rad i diamanten
        /// </summary>
        /// <param name="maxCount">Midjans läng (längsta raden asterisker)</param>
        /// <param name="asteriskCount">Längden på raden</param>
        private static void RenderRow(int maxCount, int asteriskCount)
        {
            // Påbörjar ny rad
            Console.WriteLine();

            // Ritar ut antingen * eller tomt mellanslag på varje position(kolumn) i raden som är maxCount stycken
            for (int i = 0; i < maxCount; i++)
            {
                // Kontrollerar om det ska vara ett mellanslag som ritas ut, annars ritas *
                // Fyra stycken villkor kontrolleras
                // 1. Om kolumnens nummer är mindre än mittkolumnen minus radens nummer så ritas ingen * (Ritar ut mellanslag till vänster om *)
                // 2. Om kolumnens nummer är större eller lika med skillnaden mellan mittkolumnen minus radens nummer så ritas ingen * (Ritar ut mellanslag till höger om *)
                // De två övre kraven ritar den övre halvan av diamanten (pyramiden)
                // Nästa två krav ritar den nedra halvan och är mostsatta men aktiveras bara om radens nummer är större än halva diamantens höjd
                // 3. Eftersom radens nummer nu är mer än hälften av totala antalet rader så blir det omvänt förhållande från 1 för att få samma värden
                // 4. Motsatsen till 2 med samma resonemang som 3.
                if (i < maxCount / 2 - asteriskCount
                    || i >= maxCount - (maxCount / 2 - asteriskCount)
                    || (asteriskCount > maxCount / 2 && i < asteriskCount - maxCount / 2)
                    || (asteriskCount > maxCount / 2 && i >= maxCount - (asteriskCount - maxCount / 2)))
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("*");
                }
            }


        }
    }
}
