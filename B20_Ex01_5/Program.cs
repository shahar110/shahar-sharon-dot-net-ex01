//3.remove read line at the end


namespace B20_Ex01_5
{
    class Program
    {
        public static void Main()
        {
            string inputNumber;

            System.Console.WriteLine("Pease Enter a positive 9 digit integer:");
            inputNumber = System.Console.ReadLine();

            while (!inputIsValid(inputNumber))
            {
                System.Console.WriteLine("The input you entered is invalid. Please try again.");
                inputNumber = System.Console.ReadLine();
            }

            System.Console.WriteLine(string.Format(
@"The biggest digit in the number is: {0},
The smallest digit in the number is: {1},
There are {2} digits that are divisible by 3,
There are {3} digits the are bigger than the Unit's place.",
            getMaxDigit(inputNumber),
            getMinDigit(inputNumber),
            getAmountOfDigitDevisibleBy3(inputNumber),
            getAmountOfDigitBiggerThanUnitPlace(inputNumber)
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
                foreach(char c in i_ReadNumber.ToCharArray())
                {
                    if (!char.IsDigit(c))
                    {
                        isValid = false;
                    }
                }
            }

            return isValid;
        }

        private static char getMaxDigit(string i_ReadNumber)
        {
            char maxDigit = i_ReadNumber[0];

            foreach (char c in i_ReadNumber.ToCharArray())
            {
                if (c > maxDigit)
                {
                    maxDigit = c;
                }
            }

            return maxDigit;
        }

        private static char getMinDigit(string i_ReadNumber)
        {
            char minDigit = i_ReadNumber[0];

            foreach (char c in i_ReadNumber.ToCharArray())
            {
                if (c < minDigit)
                {
                    minDigit = c;
                }
            }

            return minDigit;
        }

        private static int getAmountOfDigitDevisibleBy3(string i_ReadNumber)
        {
            int amountDevisibileBy3 = 0; ;

            foreach(char c in i_ReadNumber.ToCharArray())
            {
                if ((int)char.GetNumericValue(c) % 3 == 0)
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

            foreach (char c in i_ReadNumber)
            {
                if (c > digitInUnitsPlace)
                {
                    amountBiggeerThanUnitsPlace++;
                }
            }

            return amountBiggeerThanUnitsPlace;
        }

        /*
         program flow:

        read an input string from user (and check its validity)
        convert string input into int (and remove leading zeros)

        now we have what we want. we need to do:
        1. max digit in number
        2. min digit in number
        3. how many digits devide in 3 without remainder
        4. how many digits are bigger then the units place

      
         
         */
    }
}
