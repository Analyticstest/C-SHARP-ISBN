using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ISBN_CHECK
{
    class Program
    {

        private static void Main(string[] args)
        {
            string isbnNumber = null;
            setIsbnNumber(ref isbnNumber);
            checkNumberAndLines(isbnNumber);
            isbnCalculation(isbnNumber);
            isValidIsbn(isbnNumber);

            Console.ReadLine();            
        }

        private static void setIsbnNumber(ref string isbnNumber)
        {
            Console.WriteLine("ISBN EINGEBEN: ");
            isbnNumber = Console.ReadLine();
        }

        static bool checkNumberAndLines(string isbn)
        {
            int lineCounter = 0;
            int numberCounter = 0;
            for (int i = 0; i < isbn.Length; i++)
            {
                if (isLine(isbn, i)) // 45 = "-"
                {
                    lineCounter++;
                }
                else if (isNumber(isbn, i) || isLetterX(isbn, i))
                {
                    numberCounter++;
                }
            }

            if (lineCounter == 3 & numberCounter == 10)
            {
                return true;
            }
            return false;
        }
        
        static int isbnCalculation(string isbn)
        {
            int result = 0;
            int isbnMultiplier = 10;
            if (checkNumberAndLines(isbn))
            {
                for(int i = 0; i < isbn.Length; i++) {
                    if (isNumber(isbn, i)) {                                                                                                            
                        result += (isbn[i]-48) * isbnMultiplier;
                        isbnMultiplier--;
                    }
                    else if (isLetterX(isbn, i))
                    {
                        result += 10 * isbnMultiplier;
                        isbnMultiplier--;
                    }
                }
            }
            return result%11; 
        }

         static void isValidIsbn(string isbn)
        {
            if (isbnCalculation(isbn) == 0 && checkNumberAndLines(isbn) ) {
                Console.WriteLine("VALID ISBN");
            }
            else
            {
                Console.WriteLine("INVALID ISBN");
            } 
        }
        private static bool isNumber(string isbn, int i) { 
            if (isbn[i] >= 48 && isbn[i] <= 57) 
                return true;
            else 
                return false;
        }
        private static bool isLetterX(string isbn, int i)
        {
            if (isbn[i] == 120 || isbn[i] == 88)
            {
                return true;
            }
            else
                return false;
        }
        private static bool isLine(string isbn, int i)
        {
            if (isbn[i] == 45)
                return true;
            else
                return false;
        }
    }
}
