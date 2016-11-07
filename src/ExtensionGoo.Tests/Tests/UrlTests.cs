using System.Collections.Generic;
using System.Threading.Tasks;
using ExtensionGoo.Standard.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionGoo.Tests.Tests
{
    [TestClass]
    public class UrlTests
    {
        [TestMethod]
        public async Task TestDownloader()
        {
            var result = await
                "http://www.xamling.net".GetRaw(new Dictionary<string, string>
                {
                    {"TestHeader", "TestValue" }
                });

            Assert.IsNotNull(result);
        }
    }
}
