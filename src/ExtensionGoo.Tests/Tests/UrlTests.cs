using System.Threading.Tasks;
using ExtensionGoo.Portable.Extensions;
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
                "http://www.xamling.net".GetRaw();

            Assert.IsNotNull(result);
        }
    }
}
