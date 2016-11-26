using System.IO;
using System.Threading.Tasks;
using ExtensionGoo.Standard.Extensions;
using ExtensionGoo.Tests.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionGoo.Tests.Tests
{
    [TestClass]
    public class FullRoundTripTests
    {
        [TestMethod]
        public async Task TestRoundTrip()
        {
            var url =
                "https://jwtparse.azurewebsites.net/api/JWTWithRsaValidator?code=r3gqblabmyfju0c6zbhknwyiimhdrdn1yld7";

            var sampleData = File.ReadAllText("Data\\JwtSampleEntity.txt").Deserialise<JwtSampleEntity>();

            var result = await url.PostAndParse<TokenResult, JwtSampleEntity>(sampleData);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public async Task TestPost()
        {
            var url =
                "http://requestb.in/14bb90w1";

            var img = File.ReadAllBytes("Data\\stan.jpg");

            var postResult = await url.Post(img);

            Assert.IsNotNull(postResult);
        }

        [TestMethod]
        public async Task TestPostErrorHandling()
        {
            var url =
                "http://bad.request/14bb90w1";

            string errorValue = null;

            var img = File.ReadAllBytes("Data\\stan.jpg");

            var postResult = await url.Post(img, null, ex => errorValue = ex.Message);

            Assert.IsNull(postResult);
            Assert.IsNotNull(errorValue);
        }
    }
}
