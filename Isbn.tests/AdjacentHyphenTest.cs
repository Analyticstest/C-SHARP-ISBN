using Xunit;
using ISBN_CHECK;

namespace Isbn.tests
{
    public class AdjacentHyphenTest
    {
        [Fact]
        public void isbnNumberShouldNotHaveTwoHyphensTest()
        {
            string isbn = "3-8266-2931--0";
            var isbnValidator = new IsbnValidator();

            Assert.False(isbnValidator.isValidIsbn(isbn));
        }
    }
}
