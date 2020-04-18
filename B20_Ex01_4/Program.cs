using System;
using System.Linq;
using System.Text;
using System.Globalization;


class Program
{
    public static void Main()
    {
        Console.WriteLine("Please enter a string to analyze:");
        string stringToAnalyze = Console.ReadLine();
        StringBuilder validityErrorMessages = new StringBuilder();

        while (!StringAnalysis.ValidityCheck(stringToAnalyze, validityErrorMessages))
        {
            Console.Write(validityErrorMessages);
            validityErrorMessages.Clear();
            Console.WriteLine("Invalid input entered! Please try again:");
            stringToAnalyze = Console.ReadLine();
        }

        if (StringAnalysis.IsPalindrome(stringToAnalyze))
        {
            Console.WriteLine("The number is a Palindrome!");
        }
        else
        {
            Console.WriteLine("The number is NOT a Palindrom!");
        }

        if (int.TryParse(stringToAnalyze, out int numberToAnalyze))
        {
            if (StringAnalysis.IsDivisibleByFive(numberToAnalyze))
            {
                Console.WriteLine("The number is divisible by five!");
            }
            else
            {
                Console.WriteLine("The number is NOT divisible by five!");
            }
        }
        else
        {
            Console.WriteLine(String.Format("There are {0} capital letters in the string.", StringAnalysis.GetNumOfCapitalLetters(stringToAnalyze)));
        }
    }
}

class StringAnalysis
{
    public static bool ValidityCheck(string i_AnalyzedString, StringBuilder o_ErrorMessages)
    {
        bool isValid = true;
        if (i_AnalyzedString.Length != 8)
        {
            isValid = false;
            o_ErrorMessages.Append(String.Format("String must be 8 characters long{0}", Environment.NewLine));
        } 
        if (!i_AnalyzedString.All(char.IsDigit) && !i_AnalyzedString.All(char.IsLetter))
        {
            isValid = false;
            o_ErrorMessages.Append(String.Format("String must be comprised with either letters only or digits only{0}", Environment.NewLine));
        }
        return isValid;
    }

    public static bool IsPalindrome(string i_AnalyzedString)
    {
        if (i_AnalyzedString.Length <= 1)
        {
            return true;
        }
        bool firstLastIndexCheck = (i_AnalyzedString[0] == i_AnalyzedString[i_AnalyzedString.Length - 1]);
        return (firstLastIndexCheck && IsPalindrome(i_AnalyzedString.Substring(1, i_AnalyzedString.Length - 2)));
    }

    public static bool IsDivisibleByFive(int i_NumberToCheck)
    {
        return i_NumberToCheck % 5 == 0;
    }

    public static int GetNumOfCapitalLetters(string i_AnalyzedString)
    {
        int lettersCounter = 0;
        foreach(char c in i_AnalyzedString.ToCharArray())
        {
            if (char.GetUnicodeCategory(c) == UnicodeCategory.UppercaseLetter)
            {
                lettersCounter++;
            }
        }
        return lettersCounter;
    }
}