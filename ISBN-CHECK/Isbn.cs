using System;

namespace ISBN_CHECK
{
    public class Isbn
    {
        private static void Main(string[] args)
        {
            string isbnNumber = "";
            bool isValid = false;
            var isbnValidator = new IsbnValidator();

            do
            {
                isbnNumber = isbnValidator.setIsbnNumber();
                isValid = isbnValidator.isValidIsbn(isbnNumber);
            } while (!isValid);
            Console.ReadLine();
        }
    }
}
