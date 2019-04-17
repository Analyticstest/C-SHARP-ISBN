using System;


namespace ISBN_CHECK
{

    class Isbn
    {
        private static void Main(string[] args)
        {
            string isbnNumber = setIsbnNumber();
            checkNumbersAndHyphons(isbnNumber);
            isbnCalculation(isbnNumber);
            isValidIsbn(isbnNumber);

            Console.ReadLine();
        }

        private static string setIsbnNumber()
        {
            Console.WriteLine("ISBN EINGEBEN: ");
            var isbnNumber = Console.ReadLine();
            return isbnNumber;
        }

        private static bool checkNumbersAndHyphons(string isbn)
        {
            int hyphonCounter = 0;
            int numberCounter = 0;

            for (int i = 0; i < isbn.Length; i++)
            {
                char currentChar = isbn[i];
                if (isHyphon(currentChar)) 
                {
                    hyphonCounter++;
                }
                else if (isNumber(isbn[i]) || isLetterX(isbn[i]))
                {
                    numberCounter++;
                }
            }
            return hyphonCounter == 3 && numberCounter == 10;
        }
        
        private static int isbnCalculation(string isbn)
        {
            int result = 0;
            int isbnMultiplier = 10;

            if (checkNumbersAndHyphons(isbn))
            {
                for (int i = 0; i < isbn.Length; i++) {
                    if (isNumber(isbn[i])) {
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

        private static void isValidIsbn(string isbn)
        {
            if (isbnCalculation(isbn) == 0 && checkNumbersAndHyphons(isbn)) 
                Console.WriteLine("VALID ISBN");
            else
                Console.WriteLine("INVALID ISBN");
        }
        private static bool isNumber(char currentIsbnChar) {
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
