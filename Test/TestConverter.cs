using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GramOunceConverter;

namespace Test
{
    [TestClass]
    public class TestConverter
    {
        [TestMethod]
        public void TestConverterMethod()
        {
           // Change the method inside the converter to static and now it works!
           // 2-10-2018 || Christian Witt

            //Testing if the method can convert from gram to ounce
            Assert.AreEqual(GramAndOunceConverter.ToOunce(170), 5.99647266313933);
            Assert.AreEqual(GramAndOunceConverter.ToOunce(340), 11.99294532627866);
            Assert.AreEqual(GramAndOunceConverter.ToOunce(680), 23.98589065255732);


            //Testing if the method can convert from ounce to gram
            Assert.AreEqual(GramAndOunceConverter.ToGram(5), 141.75);
            Assert.AreEqual(GramAndOunceConverter.ToGram(10), 283.5);
            Assert.AreEqual(GramAndOunceConverter.ToGram(15), 425.25);
        }
    }
}
