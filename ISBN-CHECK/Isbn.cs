using System;

namespace ISBN_CHECK
{
    public class Isbn
    {
        private static void Main(string[] args)
        {
            bool isValid = false;
            string isbnNumber = "";
            IsbnValidator isbnValidator = new IsbnValidator();

            do
            {
                isbnNumber = isbnValidator.setIsbnNumber(); 
                isValid = isbnValidator.isValidIsbn(isbnNumber);
            } while (!isValid);

            Console.ReadLine();
        }
    }
}
