using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsToolkit.Tests.Entity
{
    public class JwtSampleEntity
    {
        public string token { get; set; }

        public string rsaKey { get; set; }

        public string issuer { get; set; }

        public string audience { get; set; }
    }
}
