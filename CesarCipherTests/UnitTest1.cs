using CesarCipher;

namespace CesarCipherTests
{
    public class UnitTest1
    {
        [Fact]
        public void CzyZnaszAlfabat()
        {
            Assert.Equal(32 + 3, CesarEnryption.Alphabet.Length);
        }

        [Fact]
        public void CzyAlgorytmNadalDzia³a()
        {
            string sentence = "Ala ma kota";
            string expectedResult = "CNC OC MQWC";

            string actualResult = new CesarEnryption().Perform(sentence, true);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}