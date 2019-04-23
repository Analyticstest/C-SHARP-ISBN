using System;
using System.Collections.Generic;
using System.Text;
using ISBN_CHECK;
using Xunit;

namespace ISBN.tests
{
    public class ValidIsbnTest
    {
        [Fact]
        public void isValidIsbnTest()
        {
            var isbn = "3-8266-2931-0";
            var isbnValidator = new IsbnValidator();

            Assert.True(isbnValidator.isValidIsbn(isbn));
        }
    }   
}
