namespace B20_Ex01_1
{
    public class NumberStats
    {
        public static int s_NumberOfDigits = 9;
        string m_userInput1;
        string m_userInput2;
        string m_userInput3;

        int m_decimalInput1;
        int m_decimalInput2;
        int m_decimalInput3;
        
        public NumberStats(string i_inputNumber1, string i_inputNumber2, string i_inputNumber3)
        {
            this.m_userInput1 = i_inputNumber1;
            this.m_userInput2 = i_inputNumber2;
            this.m_userInput3 = i_inputNumber3;

            this.m_decimalInput1 = binaryStringToInt(m_userInput1);
            this.m_decimalInput2 = binaryStringToInt(m_userInput2);
            this.m_decimalInput3 = binaryStringToInt(m_userInput3);
        }

        public int GetFirstDecimal()
        {
            return binaryStringToInt(m_userInput1);
        }

        public int GetSecondDecimal()
        {
            return binaryStringToInt(m_userInput2);
        }

        public int GetThirdDecimal()
        {
            return binaryStringToInt(m_userInput3);
        }

        private int binaryStringToInt(string binaryNumber)
        {
            int decimalNumber = 0;

            for (int i = 0; i < s_NumberOfDigits; i++)
            {
                int power = s_NumberOfDigits - 1 - i;
                decimalNumber += (binaryNumber[i] - '0') * (int)System.Math.Pow(2, power);
            }

            return decimalNumber;
        }

        public int GetMin()
        {
             return System.Math.Min(System.Math.Min(m_decimalInput1, m_decimalInput2), m_decimalInput3);
        }

        public int GetMax()
        {
            return System.Math.Max(System.Math.Max(m_decimalInput1, m_decimalInput2), m_decimalInput3);
        }
        
        public int AmountOfPowerOf2()
        {
            int amountOfPowerOf2 = 0;

            if (isPowerOf2(m_decimalInput1))
            {
                amountOfPowerOf2++;
            }

            if (isPowerOf2(m_decimalInput2))
            {
                amountOfPowerOf2++;
            }

            if (isPowerOf2(m_decimalInput3))
            {
                amountOfPowerOf2++;
            }

            return amountOfPowerOf2;
        }

        private bool isPowerOf2(int i_DecimalNumber)
        {
            bool isPowerOfTwo = false;

            if (i_DecimalNumber == 0)
            {
                isPowerOfTwo = false;
            }
            if (System.Math.Ceiling(System.Math.Log(i_DecimalNumber, 2)) == System.Math.Floor(System.Math.Log(i_DecimalNumber, 2)))
            {
                isPowerOfTwo = true;
            }

            return isPowerOfTwo;
        }

        public int AmountOfAscendingOrderNumbers()
        {
            int amountOfAscending = 0;

            if (isAscendingOrder(m_decimalInput1))
            {
                amountOfAscending++;
            }

            if (isAscendingOrder(m_decimalInput2))
            {
                amountOfAscending++;
            }

            if (isAscendingOrder(m_decimalInput3))
            {
                amountOfAscending++;
            }

            return amountOfAscending;
        }

        private bool isAscendingOrder(int i_DecimalNumber)
        {
            bool m_isAscendingSeries = true;
            int currentReadDigit = i_DecimalNumber % 10;
            i_DecimalNumber /= 10;
            int nextDigitToCheck = i_DecimalNumber % 10;

            while (i_DecimalNumber != 0)
            {
                if (currentReadDigit > nextDigitToCheck)
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

        public int CalculateAverageDigit(char i_Digit)
        {
            return (countDigitInString(m_userInput1, i_Digit)
                   + countDigitInString(m_userInput2, i_Digit)
                   + countDigitInString(m_userInput2, i_Digit)) /3;
        }   

        private int countDigitInString (string i_StringNumber, char i_Digit)
        {
            int numberOfDigits = 0;

            for (int i = 0; i < i_StringNumber.Length; i++)
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
