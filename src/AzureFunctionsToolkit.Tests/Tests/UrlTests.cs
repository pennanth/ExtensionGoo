using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AzureFunctionsToolkit.Portable.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureFunctionsToolkit.Tests.Tests
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
