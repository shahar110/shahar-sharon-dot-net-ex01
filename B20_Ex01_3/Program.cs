using System;
using System.Text;

namespace B20_Ex01_3
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter the desired height of the Sand Timer you wish to draw:");
            string sandTimerHeightInput = Console.ReadLine();
            StringBuilder validityErrorMessages = new StringBuilder();

            while (!ValidityCheck(sandTimerHeightInput, validityErrorMessages))
            {
                Console.Write(validityErrorMessages);
                validityErrorMessages.Clear();
                Console.WriteLine("Invalid input entered! Please try again:");
                sandTimerHeightInput = Console.ReadLine();
            }

            ActivateDrawer(int.Parse(sandTimerHeightInput));
        }

        public static bool ValidityCheck(string i_UserInput, StringBuilder o_ErrorMessages)
        {
            bool isValid = true;
            if (!int.TryParse(i_UserInput, out int o_SandTimerHeight))
            {
                o_ErrorMessages.Append(string.Format("Must be a number{0}", Environment.NewLine));
                isValid = false;
            }
            else if (o_SandTimerHeight <= 0 || o_SandTimerHeight > 50)
            {
                o_ErrorMessages.Append(string.Format("Number range must be between 1 to 50{0}", Environment.NewLine));
                isValid = false;
            }

            return isValid;
        }

        public static void ActivateDrawer(int i_SandTimerHeight)
        {
            B20_Ex01_2.Program.SandTimerDrawer(i_SandTimerHeight, i_SandTimerHeight);
        }
    }
}
