using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureFunctionsToolkit.Extensions;
using AzureFunctionsToolkit.Tests.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureFunctionsToolkit.Tests.Tests
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

            Assert.IsTrue(result.IsValid);
        }
    }
}
