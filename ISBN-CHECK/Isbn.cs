using System;

namespace ISBN_CHECK
{
    public class Isbn
    {
        private static void Main(string[] args)
        {
            string isbnNumber = setIsbnNumber();

            IsbnValidator isbnValidator = new IsbnValidator();
            isbnValidator.isValidIsbn(isbnNumber);

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
