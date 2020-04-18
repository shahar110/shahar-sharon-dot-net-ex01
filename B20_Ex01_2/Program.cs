using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        SandTimerDrawer.sandTimerHeight = 3;
        SandTimerDrawer.Draw(SandTimerDrawer.sandTimerHeight);
    }
}

public class SandTimerDrawer
{
    public static int sandTimerHeight;

    public static void Draw(int i_CurrentHeightLevel)
    {
        var lineToDraw = new StringBuilder();
        generateLineOfAstericks(lineToDraw, (sandTimerHeight - i_CurrentHeightLevel), ((i_CurrentHeightLevel * 2) - 1));

        if (i_CurrentHeightLevel <= 1)
        {
            Console.WriteLine(lineToDraw);
            return;
        }

        Console.WriteLine(lineToDraw);
        Draw(i_CurrentHeightLevel - 1);
        Console.WriteLine(lineToDraw);
    }

    private static void generateLineOfAstericks(StringBuilder lineToDraw, int i_NumOfSpaces, int i_NumOfAsterisks)
    {
        lineToDraw.Append(' ', i_NumOfSpaces);
        lineToDraw.Append('*', i_NumOfAsterisks);
    }
}

