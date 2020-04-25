﻿namespace B20_Ex01_1
{
    public class Program
    {
        public static void Main()
        {
            string firstUserInput;
            string secondUserInput;
            string thirdUserInput;

            System.Console.WriteLine("Please enter 3 binary numbers, 9 digits each: ");

            getInputFromUser(out firstUserInput);
            getInputFromUser(out secondUserInput);
            getInputFromUser(out thirdUserInput);

            int decimalInput1 = binaryToDecimal(firstUserInput);
            int decimalInput2 = binaryToDecimal(secondUserInput);
            int decimalInput3 = binaryToDecimal(thirdUserInput);

            System.Console.WriteLine(string.Format(
@"The decimal numbers are: {0} {1} {2}.
The average number of 0's is: {3:0.0}, the average number of 1's is: {4:0.0}.
There are {5} numbers which are power of two.
There are {6} numbers which are in ascending order.
The smallest number is: {7}, the biggest number is: {8}.",
               decimalInput1,
               decimalInput2,
               decimalInput3,
               calculateAverageDigit(firstUserInput, secondUserInput, thirdUserInput, '0'),
               calculateAverageDigit(firstUserInput, secondUserInput, thirdUserInput, '1'),
               amountOfPowerOf2(decimalInput1, decimalInput2, decimalInput3),
               amountOfAscendingOrderNumbers(decimalInput1, decimalInput2, decimalInput3),
               getMin(decimalInput1, decimalInput2, decimalInput3),
               getMax(decimalInput1, decimalInput2, decimalInput3)));
        }

        private static void getInputFromUser(out string o_UserInput)
        {
            string userInput = System.Console.ReadLine();

            while(!inputIsValid(userInput))
            {
                System.Console.WriteLine("The input you entered is invalid. Please try again.");
                userInput = System.Console.ReadLine();
            }

            o_UserInput = userInput;
        }

        private static bool inputIsValid(string i_ReadNumber)
        {
            bool isValid = true;

            if(i_ReadNumber.Length != 9)
            {
                isValid = false;
            }
            else if(binaryToDecimal(i_ReadNumber) == 0)
            {
                isValid = false;
            }
            else
            {
                for(int i = 0; i < i_ReadNumber.Length && isValid; i++)
                {
                    if(!i_ReadNumber[i].Equals('0') && !i_ReadNumber[i].Equals('1'))
                    {
                        isValid = false;
                    }
                }
            }

            return isValid;
        }

        private static int binaryToDecimal(string binaryNumber)
        {
            int decimalNumber = 0;

            for(int i = 0; i < 9; i++)
            {
                int power = 9 - 1 - i;
                decimalNumber += (binaryNumber[i] - '0') * (int)System.Math.Pow(2, power);
            }

            return decimalNumber;
        }

        private static int getMin(int i_FirstNumber, int i_SecondNumber, int i_ThirdNumber)
        {
            return System.Math.Min(System.Math.Min(i_FirstNumber, i_SecondNumber), i_ThirdNumber);
        }

        private static int getMax(int i_FirstNumber, int i_SecondNumber, int i_ThirdNumber)
        {
            return System.Math.Max(System.Math.Max(i_FirstNumber, i_SecondNumber), i_ThirdNumber);
        }

        private static int amountOfPowerOf2(int i_FirstNumber, int i_SecondNumber, int i_ThirdNumber)
        {
            int amountOfPowerOf2 = 0;

            if(isPowerOf2(i_FirstNumber))
            {
                amountOfPowerOf2++;
            }

            if(isPowerOf2(i_SecondNumber))
            {
                amountOfPowerOf2++;
            }

            if(isPowerOf2(i_ThirdNumber))
            {
                amountOfPowerOf2++;
            }

            return amountOfPowerOf2;
        }

        private static bool isPowerOf2(int i_DecimalNumber)
        {
            bool isPowerOfTwo = false;

            if(i_DecimalNumber == 0)
            {
                isPowerOfTwo = false;
            }

            if(System.Math.Ceiling(System.Math.Log(i_DecimalNumber, 2)) == System.Math.Floor(System.Math.Log(i_DecimalNumber, 2)))
            {
                isPowerOfTwo = true;
            }

            return isPowerOfTwo;
        }

        private static int amountOfAscendingOrderNumbers(int i_FirstNumber, int i_SecondNumber, int i_ThirdNumber)
        {
            int amountOfAscending = 0;

            if(isAscendingOrder(i_FirstNumber))
            {
                amountOfAscending++;
            }

            if(isAscendingOrder(i_SecondNumber))
            {
                amountOfAscending++;
            }

            if(isAscendingOrder(i_ThirdNumber))
            {
                amountOfAscending++;
            }

            return amountOfAscending;
        }

        private static bool isAscendingOrder(int i_DecimalNumber)
        {
            bool m_isAscendingSeries = true;
            int currentReadDigit = i_DecimalNumber % 10;
            i_DecimalNumber /= 10;
            int nextDigitToCheck = i_DecimalNumber % 10;

            while(i_DecimalNumber != 0)
            {
                if(currentReadDigit > nextDigitToCheck)
                {
                    currentReadDigit = nextDigitToCheck;
                    i_DecimalNumber /= 10;
                    nextDigitToCheck = i_DecimalNumber % 10;
                }
                else
                {
                    m_isAscendingSeries = false;
                    break;
                }
            }

            return m_isAscendingSeries;
        }

        private static double calculateAverageDigit(string userInput1, string userInput2, string userInput3, char i_Digit)
        {
            return (countDigitInString(userInput1, i_Digit)
                   + countDigitInString(userInput2, i_Digit)
                   + countDigitInString(userInput3, i_Digit)) / 3.0;
        }

        private static int countDigitInString(string i_StringNumber, char i_Digit)
        {
            int numberOfDigits = 0;

            for(int i = 0; i < i_StringNumber.Length; i++)
            {
                if (i_StringNumber[i].Equals(i_Digit))
                {
                    numberOfDigits++;
                }
            }

            return numberOfDigits;
        }
    }
}