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
                RenderDiamond1(diamondSize);
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
        /// Ritar ut diamanten (Alternativ 1), kan använda RenderRow1 och RenderRow2
        /// </summary>
        /// <param name="maxCount">Ger antalet asterisker diamentens midja ska ha</param>
        private static void RenderDiamond1(byte maxCount)
        {
            // Anropar metoden som ritar en rad i diamanten lika många gånger som variabeln maxCount anger
            for (int i = 0; i < maxCount; i++)
            {
                RenderRow2((int)maxCount, i);
            }

        }
        /// <summary>
        /// Ritar ut diamanten (Alternativ 2), kan använda RenderRow3
        /// </summary>
        /// <param name="maxCount">Ger antalet asterisker diamentens midja ska ha</param>
        private static void RenderDiamond2(byte maxCount)
        {
            // Anropar metoden som ritar en rad i diamanten lika många gånger som variabeln maxCount anger, 
            for (int i = 0; i < maxCount; i++)
            {
                // Beräknar antalet asterisker som raden ska ha, (2*i+1) anger udda tal 
                // formeln beskriver funktionen N = M-|M-(2*i+1)| där N är antalet asterisker i raden och M är max antal asterisker i en rad. 
                // Den funktionen skapar alla udda tal från 1 - M och sedan tillbaka ner till 1 igen för alla heltal 0<x<M
                int asteriskCount = maxCount - Math.Abs(maxCount - (2 * i + 1));

                // Anropar metoden som ritar en rad i diamanten och det andra argumentet anger antalet asterisker i raden
                RenderRow3((int)maxCount, asteriskCount);
            }

        }
        /// <summary>
        /// Ritar ut en rad i diamanten (Alternativ 1)
        /// </summary>
        /// <param name="maxCount">Midjans läng (längsta raden asterisker)</param>
        /// <param name="asteriskCount">Raden som ritas ut nummer</param>
        private static void RenderRow1(int maxCount, int rowNumber)
        {
            // Påbörjar ny rad
            Console.WriteLine();

            // Ritar ut antingen * eller tomt mellanslag på varje position(kolumn) i raden som är maxCount stycken
            for (int i = 0; i < maxCount; i++)
            {
                // Kontrollerar om det ska vara ett mellanslag som ritas ut, annars ritas *
                // Två villkor konrolleras
                // 1. Om kolumnens nummer är mindre än mittkolumnen minus radens nummer så ritas mellanslag (Ritar ut mellanslag till vänster om *)
                // absoultbeloppsfunktionen gör så att radnummer större än mittradens nummer ger samma blanka positioner till vänster om asteriskerna
                // 2. Om kolumnens nummer är större eller lika med skillnaden mellan mittkolumnen minus radens nummer så ritas mellanslag (Ritar ut mellanslag till höger om *)
                if (i < Math.Abs(maxCount / 2 - rowNumber) || i >= maxCount - Math.Abs(maxCount / 2 - rowNumber))
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("*");
                }
            }
        }

        /// <summary>
        /// Ritar ut en rad i diamanten (Alternativ 2)
        /// </summary>
        /// <param name="maxCount">Midjans läng (längsta raden asterisker)</param>
        /// <param name="asteriskCount">Raden som ritas ut nummer</param>
        private static void RenderRow2(int maxCount, int rowNumber)
        {
            // Påbörjar ny rad
            Console.WriteLine();

            // Ritar ut antingen * eller tomt mellanslag på varje position(kolumn) i raden som är maxCount stycken
            for (int i = 0; i < maxCount; i++)
            {
                if (Math.Abs(maxCount / 2 - rowNumber) <= i && i < maxCount - Math.Abs(maxCount / 2 - rowNumber))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }

        }
        /// <summary>
        /// Ritar en rad i diamanten (ALternativ 3), kräver RenderDiamond2 för att fungera
        /// </summary>
        /// <param name="maxCount">Antalet asterisker i diamantens midja</param>
        /// <param name="asteriskCount">Antalet asterisker som ska ritas ut i mitten av raden</param>
        private static void RenderRow3(int maxCount, int asteriskCount)
        {
            // Påbörjar ny rad
            Console.WriteLine();

            //Ritar ut mellanslag och asterisker
            for (int i = 0; i < maxCount; i++)
            {
                // Ritar ut ett antal asterisker lika många som asteriskCount, 
                // det andra villkoret säger när asteriskerna ska börja ritas
                for (int n = 0; n < asteriskCount && i == Math.Abs((maxCount - asteriskCount) / 2); n++)
                {
                    Console.Write("*");
                }
                Console.Write(" ");
            }
        }

    }
}
