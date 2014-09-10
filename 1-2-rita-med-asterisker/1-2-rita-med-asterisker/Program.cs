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

        }
        /// <summary>
        /// Kollar om användaren vill avsluta programmet eller fortsätta köra programmet en gång till
        /// </summary>
        /// <returns>Ett boolean värde</returns>
        private static bool IsContinuing()
        {
            return true;
        }
        /// <summary>
        /// Ska läsa in ett udda heltal av typen byte från användaren
        /// </summary>
        /// <param name="prompt">Felmeddelande som ska visas om användaren visar fel värde</param>
        /// <param name="maxValue">Maxvärde som användaren kan mata in</param>
        /// <returns>Ett udda heltal av typen byte</returns>
        private static byte ReadOddByte(String prompt=null,byte maxValue = 255)
        {
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
