using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBN_CHECK
{
    class IsbnValidator
    {
        private bool checkNumbersAndHyphons(string isbn)
        {
            int hyphonCounter = 0;
            int numberCounter = 0;

            for (int i = 0; i < isbn.Length; i++)
            {
                char currentChar = isbn[i];

                if (isHyphon(currentChar))
                    hyphonCounter++;
                else if (isNumber(currentChar) || isLetterX(currentChar))
                    numberCounter++;
            }
            return hyphonCounter == 3 && numberCounter == 10;
        }

        private int isbnCalculation(string isbn)
        {
            int result = 0;
            int isbnMultiplier = 10;

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
            return result % 11;
        }

        public bool isValidIsbn(string isbn)
        {
            if (checkNumbersAndHyphons(isbn) && isbnCalculation(isbn) == 0)
            {
                Console.WriteLine("\nVALID ISBN\n");
                Console.WriteLine("Press enter to leave.");
                return true;
            }
            else
            {
                Console.WriteLine("\nINVALID ISBN\n");
                return false;
            }
        }
        public string setIsbnNumber()
        {
            Console.Write("ISBN EINGEBEN: ");
            var isbnNumber = Console.ReadLine();
            return isbnNumber;
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
