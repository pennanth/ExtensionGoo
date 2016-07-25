using System;
using System.Threading.Tasks;
using ExtensionGoo.Portable.Extensions;
using ExtensionGoo.Tests.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionGoo.Tests.Tests
{
    [TestClass]
    public class SampleJsonEndpointTest
    {
        [TestMethod]
        public async Task TestGetAndParse()
        {
            var url = "http://jsonplaceholder.typicode.com/posts/1";

            var obj = await url.GetAndParse<TestEntity>();

            Assert.IsNotNull(obj);

            Assert.AreEqual(1, obj.userId);
        }
    }
}
