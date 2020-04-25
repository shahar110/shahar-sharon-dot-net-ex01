namespace B20_Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            string inputNumber;

            System.Console.WriteLine("Pease Enter a positive 9 digit integer:");

            getInputFromUser(out inputNumber);

            System.Console.WriteLine(string.Format(
@"The biggest digit in the number is: {0},
The smallest digit in the number is: {1},
There are {2} digits that are divisible by 3,
There are {3} digits the are bigger than the Unit's place.",
            getMaxDigit(inputNumber),
            getMinDigit(inputNumber),
            getAmountOfDigitDevisibleBy3(inputNumber),
            getAmountOfDigitBiggerThanUnitPlace(inputNumber)));           
        }

        private static void getInputFromUser(out string o_userInput)
        {
            string userInput = System.Console.ReadLine();

            while(!inputIsValid(userInput))
            {
                System.Console.WriteLine("The input you entered is invalid. Please try again.");
                userInput = System.Console.ReadLine();
            }

            o_userInput = userInput;
        }

        private static bool inputIsValid(string i_ReadNumber)
        {
            bool isValid = true;
            
            if(i_ReadNumber.Length != 9)
            {
                isValid = false;
            }
            else if(isZero(i_ReadNumber))
            {
                isValid = false;
            }
            else
            {
                for(int i = 0; i < i_ReadNumber.Length && isValid; i++)
                {
                    if(!char.IsDigit(i_ReadNumber[i]))
                    {
                        isValid = false;
                    }
                }
            }

            return isValid;
        }

        private static bool isZero(string i_ReadNumber)
        {
            bool isZero = true;

            for(int i = 0; i < i_ReadNumber.Length && isZero; i++)
            {
                if(i_ReadNumber[i] != '0')
                {
                    isZero = false;
                }
            }

            return isZero;
        }

        private static char getMaxDigit(string i_ReadNumber)
        {
            char maxDigit = i_ReadNumber[0];

            for(int i = 0; i < i_ReadNumber.Length; i++)
            {
                if(i_ReadNumber[i] > maxDigit)
                {
                    maxDigit = i_ReadNumber[i];
                }
            }

            return maxDigit;
        }

        private static char getMinDigit(string i_ReadNumber)
        {
            char minDigit = i_ReadNumber[0];

            for(int i = 0; i < i_ReadNumber.Length; i++)
            {
                if(i_ReadNumber[i] < minDigit)
                {
                    minDigit = i_ReadNumber[i];
                }
            }

            return minDigit;
        }

        private static int getAmountOfDigitDevisibleBy3(string i_ReadNumber)
        {
            int amountDevisibileBy3 = 0;

            for(int i = 0; i < i_ReadNumber.Length; i++)
            {
                if((int)char.GetNumericValue(i_ReadNumber[i]) % 3 == 0)
                {
                    amountDevisibileBy3++;
                }
            }
                       
            return amountDevisibileBy3;
        }

        private static int getAmountOfDigitBiggerThanUnitPlace(string i_ReadNumber)
        {
            char digitInUnitsPlace = i_ReadNumber[i_ReadNumber.Length - 1];
            int amountBiggeerThanUnitsPlace = 0;

            for(int i = 0; i < i_ReadNumber.Length; i++)
            {
                if(i_ReadNumber[i] > digitInUnitsPlace)
                {
                    amountBiggeerThanUnitsPlace++;
                }
            }

            return amountBiggeerThanUnitsPlace;
        }
    }
}
