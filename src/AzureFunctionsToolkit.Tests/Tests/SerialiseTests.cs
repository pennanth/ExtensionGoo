using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureFunctionsToolkit.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureFunctionsToolkit.Tests.Tests
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
