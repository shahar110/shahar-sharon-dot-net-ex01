using System;
using System.Linq;
using System.Text;
using System.Globalization;

namespace B20_Ex01_4
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a string to analyze:");
            string stringToAnalyze = Console.ReadLine();
            StringBuilder validityErrorMessages = new StringBuilder();

            while (!ValidityCheck(stringToAnalyze, validityErrorMessages))
            {
                Console.Write(validityErrorMessages);
                validityErrorMessages.Clear();
                Console.WriteLine("Invalid input entered! Please try again:");
                stringToAnalyze = Console.ReadLine();
            }

            Console.WriteLine(string.Format("The string is {0}!", IsPalindrome(stringToAnalyze) ? "a Palindrome" : "NOT a Palindrome"));

            if (int.TryParse(stringToAnalyze, out int numberToAnalyze))
            {
                Console.WriteLine(string.Format("The string number is {0}!", IsDivisibleByFive(numberToAnalyze) ? "divisible by five" : "NOT divisible by five"));
            }
            else
            {
                Console.WriteLine(string.Format("There are {0} capital letters in the string.", GetNumOfCapitalLetters(stringToAnalyze)));
            }
        }

        public static bool ValidityCheck(string i_AnalyzedString, StringBuilder o_ErrorMessages)
        {
            bool isValid = true;
            if (i_AnalyzedString.Length != 8)
            {
                isValid = false;
                o_ErrorMessages.Append(string.Format("String must be 8 characters long{0}", Environment.NewLine));
            }

            if (!i_AnalyzedString.All(char.IsDigit) && !i_AnalyzedString.All(char.IsLetter))
            {
                isValid = false;
                o_ErrorMessages.Append(string.Format("String must be comprised with either letters only or digits only{0}", Environment.NewLine));
            }

            return isValid;
        }

        public static bool IsPalindrome(string i_AnalyzedString)
        {
            bool nextLevelIndexCheck;
            if (i_AnalyzedString.Length <= 1)
            {
                nextLevelIndexCheck = true;
            }
            else
            {
                bool firstLastIndexCheck = i_AnalyzedString[0] == i_AnalyzedString[i_AnalyzedString.Length - 1];
                nextLevelIndexCheck = firstLastIndexCheck && IsPalindrome(i_AnalyzedString.Substring(1, i_AnalyzedString.Length - 2));
            }

            return nextLevelIndexCheck;
        }

        public static bool IsDivisibleByFive(int i_NumberToCheck)
        {
            return i_NumberToCheck % 5 == 0;
        }

        public static int GetNumOfCapitalLetters(string i_AnalyzedString)
        {
            int lettersCounter = 0;
            foreach (char c in i_AnalyzedString.ToCharArray())
            {
                if (char.GetUnicodeCategory(c) == UnicodeCategory.UppercaseLetter)
                {
                    lettersCounter++;
                }
            }

            return lettersCounter;
        }
    }
}
