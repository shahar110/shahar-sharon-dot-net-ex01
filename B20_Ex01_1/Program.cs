using System.Text;
namespace B20_Ex01_1
{
    class Program
    {
        public static void Main()
        {
            string userInput;
            string userInput1 = "";
            string userInput2 = "";
            string userInput3 = "";

            System.Console.WriteLine("Please enter 3 binary numbers, 9 digits each: ");
      
            for (int i = 0; i < 3; i++)
            {
                userInput = System.Console.ReadLine();
                while (!inputIsValid(userInput))
                {
                    System.Console.WriteLine("The input you entered is invalid. Please try again.");
                    userInput = System.Console.ReadLine();
                }

                if (i == 0)
                {
                    userInput1 = userInput;
                }
                else if(i == 1)
                {
                    userInput2 = userInput;
                }
                else
                {
                    userInput3 = userInput;
                }
            }

            NumberStats stats = new NumberStats(userInput1, userInput2, userInput3);

            System.Console.WriteLine(string.Format(
@"The decimal numbers are: {0} {1} {2}.
The average number of 0's is: {3}, the average number of 1's is: {4}.
There are {5} numbers which are power of two.
There are {6} numbers which are in ascending order.
The smallest number is: {7}, the biggest number is: {8}.",
               stats.GetFirstDecimal(),
               stats.GetSecondDecimal(),
               stats.GetThirdDecimal(),
               stats.CalculateAverageDigit('0'),
               stats.CalculateAverageDigit('1'),
               stats.AmountOfPowerOf2(),
               stats.AmountOfAscendingOrderNumbers(),
               stats.GetMin(),
               stats.GetMax()
               ));

            System.Console.ReadLine();
                         
        }

        private static bool inputIsValid(string i_ReadNumber)
        {
            bool isValid = true;

            if (i_ReadNumber.Length != 9)
            {
                isValid = false;
            }
            else
            {
                for (int i = 0; i < i_ReadNumber.Length; i++)
                {
                    if (!i_ReadNumber[i].Equals('0') && !i_ReadNumber[i].Equals('1'))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid;
        }
    }
}