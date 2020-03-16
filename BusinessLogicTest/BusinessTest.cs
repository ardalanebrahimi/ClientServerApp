using BusinessLogic;
using NUnit.Framework;

namespace BusinessLogicTest
{
    [TestFixture]
    public class BusinessTest
    {
        Business _business;
        public BusinessTest()
        {
            _business = new Business();
        }

        [Test]
        [TestCase("0", "zero dollars")]
        [TestCase("1", "one dollar")]
        [TestCase("25,1", "twenty-five dollars and ten cents")]
        [TestCase("0,01", "zero dollars and one cent")]
        [TestCase("45100", "forty-five thousand one hundred dollars")]
        [TestCase("999999999,99", "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars and ninety-nine cents")]
        public void ConvertToWord_Test(string input, string output)
            => Assert.AreEqual(output, _business.ConvertToWord(input));

        [Test]
        [TestCase(0, "zero")]
        [TestCase(1, "one")]
        [TestCase(10, "ten")]
        [TestCase(19, "nineteen")]
        [TestCase(20, "twenty")]
        [TestCase(21, "twenty-one")]
        [TestCase(100, "one hundred")]
        [TestCase(101, "one hundred one")]
        [TestCase(123, "one hundred twenty-three")]
        public void IntToWord_Test(int input, string output)
            => Assert.AreEqual(output, _business.IntToWord(input));

        [Test]
        [TestCase(0,"dollar", "zero dollars")]
        [TestCase(1, "dollar", "one dollar")]
        [TestCase(10, "dollar", "ten dollars")]
        [TestCase(19, "dollar", "nineteen dollars")]
        [TestCase(20, "dollar", "twenty dollars")]
        [TestCase(21, "dollar", "twenty-one dollars")]
        [TestCase(100, "dollar", "one hundred dollars")]
        [TestCase(101, "dollar", "one hundred one dollars")]
        [TestCase(123, "dollar", "one hundred twenty-three dollars")]

        public void IntToPostfixedWord_Test(int input, string postfix, string output)
            => Assert.AreEqual(output, _business.IntToPostfixedWord(input, postfix));

        [Test]
        [TestCase("123", 123)]
        [TestCase("123,1", 123)]
        [TestCase("2323,01", 2323)]
        [TestCase("333,434", 333)]
        [TestCase("0,0", 0)]
        [TestCase("0,1", 0)]
        [TestCase("1,0", 1)]
        [TestCase("1,1", 1)]
        public void GetIntPart_Test(string input, int output)
            => Assert.AreEqual(output, _business.GetIntPart(input));

        [Test]
        [TestCase("123", 0)]
        [TestCase("123,1", 10)]
        [TestCase("2323,01", 1)]
        [TestCase("333,43", 43)]
        [TestCase("0,0", 0)]
        [TestCase("0,1", 10)]
        [TestCase("1,0", 0)]
        [TestCase("1,1", 10)]
        public void GetDecimalPart_Test(string input, int output)
            => Assert.AreEqual(output, _business.GetDecimalPart(input));
    }
}
