using BynaryToInt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BynaryToInt.Tests
{
    [TestClass()]
    public class UnitTest1
    {

        [DataTestMethod]
        [DataRow("100", "4")]
        [DataRow("1000", "8")]
        [DataRow("1000000000000000000000000000", "134217728")]
        [DataRow("1000000000000000000000000000000000000000000000000000000000000000", "9223372036854775808")]
        public void ConvertBinaryTest(string input, string expected)
        {
            //Act
            var actual = BinaryConverter.ConvertBinary(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
