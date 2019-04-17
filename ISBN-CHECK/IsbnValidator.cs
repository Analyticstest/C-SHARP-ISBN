using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBN_CHECK
{
    class IsbnValidator
    {
        public  bool checkNumbersAndHyphons(string isbn)
        {
            int hyphonCounter = 0;
            int numberCounter = 0;

            for (int i = 0; i < isbn.Length; i++)
            {
                char currentChar = isbn[i];
                if (isHyphon(currentChar))
                    hyphonCounter++;
                else if (isNumber(isbn[i]) || isLetterX(isbn[i]))
                    numberCounter++;
            }
            return hyphonCounter == 3 && numberCounter == 10;
        }

        public int isbnCalculation(string isbn)
        {
            int result = 0;
            int isbnMultiplier = 10;

            if (checkNumbersAndHyphons(isbn))
            {
                for (int i = 0; i < isbn.Length; i++)
                {
                    if (isNumber(isbn[i]))
                    {
                        result += (isbn[i] - 48) * isbnMultiplier;
                        isbnMultiplier--;
                    }
                    else if (isLetterX(isbn[i]))
                    {
                        result += 10 * isbnMultiplier;
                        isbnMultiplier--;
                    }
                }
            }
            return result % 11;
        }

        public void isValidIsbn(string isbn)
        {
            if (isbnCalculation(isbn) == 0 && checkNumbersAndHyphons(isbn))
                Console.WriteLine("VALID ISBN");
            else
                Console.WriteLine("INVALID ISBN");
        }
        private static bool isNumber(char currentIsbnChar)
        {
            return currentIsbnChar >= 48 && currentIsbnChar <= 57;

        }
        private static bool isLetterX(char currentIsbnChar)
        {
            return currentIsbnChar == 120 || currentIsbnChar == 88;
        }
        private static bool isHyphon(char currentIsbnChar)
        {
            return currentIsbnChar == 45;
        }

    }
}
