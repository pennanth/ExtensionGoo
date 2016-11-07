using System.Collections.Generic;
using ExtensionGoo.Standard.Entity;

namespace ExtensionGoo.Standard.Helpers
{
    public static class HttpConfigHelper
    {
        public static HttpTransferConfig GetJsonConfig(string url, string data, string verb = "POST", IDictionary<string, string> headers = null)
        {
            return new HttpTransferConfig
            {
                Accept = "application/json",
                Data = data,
                IsValid = true,
                Url = url,
                BaseUrl = url,
                Verb = verb,
                Headers = headers,
                ContentEncoding = "application/json"
            };
        }
    }
}
