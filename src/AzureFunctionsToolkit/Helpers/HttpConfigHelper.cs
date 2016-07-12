using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureFunctionsToolkit.Entity;

namespace AzureFunctionsToolkit.Helpers
{
    public static class HttpConfigHelper
    {
        public static HttpTransferConfig GetJsonConfig(string url, string data)
        {
            return new HttpTransferConfig
            {
                Accept = "application/json",
                Data = data,
                IsValid = true,
                Url = url,
                BaseUrl = url,
                Verb = "POST",
                Headers = new Dictionary<string, string>(),
                ContentEncoding = "application/json"
            };
        }
    }
}
