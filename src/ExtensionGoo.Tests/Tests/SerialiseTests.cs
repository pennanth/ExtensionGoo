using System.Threading.Tasks;
using ExtensionGoo.Standard.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionGoo.Tests.Tests
{
    [TestClass]
    public class SerialiseTests
    {
        [TestMethod]
        public async Task TestSerialiser()
        {
            var testClass = new TestSerClass
            {
                Name = "Jordan",
                Age = 21
            };

            var result = testClass.Serialise();

            Assert.IsNotNull(result);
        }

        class TestSerClass
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
