using System;

namespace ISBN_CHECK
{

    public class Isbn
    {
        private static void Main(string[] args)
        {
            IsbnValidator isbn = new IsbnValidator();
            string isbnNumber = setIsbnNumber();

            isbn.checkNumbersAndHyphons(isbnNumber);
            isbn.isbnCalculation(isbnNumber);
            isbn.isValidIsbn(isbnNumber);

            Console.ReadLine();
        }

        private static string setIsbnNumber()
        {
            Console.WriteLine("ISBN EINGEBEN: ");
            var isbnNumber = Console.ReadLine();
            return isbnNumber;
        }
    }
}
