using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBN_CHECK
{
    public class IsbnValidator
    {
        private bool checkForNumbersAndHyphens(string isbn)
        {
            int hyphenCounter = 0;
            int numberCounter = 0;

            for (int i = 0; i < isbn.Length; i++)
            {
                char currentIsbnChar = isbn[i];
                
                if (i > 0 && isAdjacentHyphen(currentIsbnChar, isbn[i - 1])) 
                {
                    Console.WriteLine("\nTwo or more Hyphens are Adjacent");
                    return false;
                }
                else if (isHyphen(currentIsbnChar))
                    hyphenCounter++;
                else if (isNumber(currentIsbnChar) || isLetterX(currentIsbnChar))
                    numberCounter++;
            }

            return hyphenCounter == 3 && numberCounter == 10;
        }

        private int isbnCalculation(string isbn)
        {
            int isbnMultiplier = 11;
            var isbnNumbers = isbn
                .Where(c => isNumber(c) || isLetterX(c)) // The letter X is treated as the Number 10 
                .Select(c => {
                    if (isNumber(c)) return c - 48;     // The Numbers are treated as Characters, so we have to Subtract 48 for it to become an Decimal Number
                    else return 10;
                });

            var aggregatedNumber = isbnNumbers.Sum(currentNumber =>
            {
                isbnMultiplier--;
                return currentNumber * isbnMultiplier;
            });

            return aggregatedNumber % 11;
        }

        public bool isValidIsbn(string isbn)
        {
            if (checkForNumbersAndHyphens(isbn) && isbnCalculation(isbn) == 0)
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
            return currentIsbnChar == 120 || currentIsbnChar == 88; // 120 is the ASCII Character Code for X  - 88 stands for x
        }
        private static bool isHyphen(char currentIsbnChar)
        {
            return currentIsbnChar == 45; // 45 is the ASCII Character Code for Hyphens
        }
        private static bool isAdjacentHyphen(char currentIsbnChar, char previousIsbnChar)
        {

            return currentIsbnChar == 45 && previousIsbnChar == 45; 
        }
    }
}
