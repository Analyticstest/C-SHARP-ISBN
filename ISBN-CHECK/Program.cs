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
            numberAndLineChecker(isbnNumber);
            isbnCalculation(isbnNumber);
            isIsbn(isbnNumber);

            Console.ReadLine();            
        }

        static string setIsbnNumber(ref string isbnNumber)
        {
            Console.WriteLine("ISBN EINGEBEN: ");
            isbnNumber = Console.ReadLine();

            return isbnNumber;
        }

        static bool numberAndLineChecker(string isbn)
        {
            int lineCounter = 0;
            int numberCounter = 0;
            for (int i = 0; i < isbn.Length; i++)
            {
                if (isbn[i] == 45) // 45 = "-"
                {
                    lineCounter++;
                }
                else if (isbn[i] >= 48 && isbn[i] <= 57 || isbn[i] == 120 || isbn[i] == 88) // 120 = X;   88 = 
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
            if (numberAndLineChecker(isbn))
            {
                for(int i = 0; i < isbn.Length; i++) {
                    if (isbn[i] >= 48 & isbn[i] <= 57) {                                                                                                            
                        result += (isbn[i]-48) * isbnMultiplier;
                        isbnMultiplier--;
                    }
                    else if (isbn[i] == 120 || isbn[i] == 88)
                    {
                        result += 10 * isbnMultiplier;
                        isbnMultiplier--;
                    }
                }

            }
            return result%11; 
        }

        static void isIsbn(string isbn)
        {
            if (isbnCalculation(isbn) == 0 && numberAndLineChecker(isbn) ) {
                Console.WriteLine("VALID ISBN");
            }
            else
            {
                Console.WriteLine("INVALID ISBN");
            } 
        }
    }
}
