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

            var sampleData = File.ReadAllText("Data\\JwtSampleEntity.txt").DeSerialise<JwtSampleEntity>();

            var result = await url.PostAndParse<TokenResult, JwtSampleEntity>(sampleData);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public async Task TestPost()
        {
            var url =
                "[someurl]";

            var img = File.ReadAllBytes("Data\\stan.jpg");

            var postResult = await url.Post(img);

            Assert.IsNotNull(postResult);
        }
    }
}
