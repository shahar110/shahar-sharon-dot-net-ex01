using System;
using System.Text;

namespace B20_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            SandTimerDrawer(3, 3);
        }

        public static void SandTimerDrawer(int i_CurrentHeightLevel, int i_SandTimerHeight)
        {
            var lineToDraw = new StringBuilder();
            generateLineOfAstericks(lineToDraw, i_SandTimerHeight - i_CurrentHeightLevel, (i_CurrentHeightLevel * 2) - 1);

            if (i_CurrentHeightLevel <= 1)
            {
                Console.WriteLine(lineToDraw);
                return;
            }

            Console.WriteLine(lineToDraw);
            SandTimerDrawer(i_CurrentHeightLevel - 1, i_SandTimerHeight);
            Console.WriteLine(lineToDraw);
        }

        private static void generateLineOfAstericks(StringBuilder o_LineToDraw, int i_NumOfSpaces, int i_NumOfAsterisks)
        {
            o_LineToDraw.Append(' ', i_NumOfSpaces);
            o_LineToDraw.Append('*', i_NumOfAsterisks);
        }
    }
}