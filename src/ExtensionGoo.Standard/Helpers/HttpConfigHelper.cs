using System.Collections.Generic;
using ExtensionGoo.Standard.Entity;

namespace ExtensionGoo.Standard.Helpers
{
    public static class HttpConfigHelper
    {
        public static HttpTransferConfig GetJsonConfig(string url, string data = null, byte[] dataBytes = null, string verb = "POST", IDictionary<string, string> headers = null, string contentEncoding = "application/json")
        {
            return new HttpTransferConfig
            {
                Accept = "application/json",
                Data = data,
                ByteData = dataBytes,
                IsValid = true,
                Url = url,
                BaseUrl = url,
                Verb = verb,
                Headers = headers,
                ContentEncoding = contentEncoding
            };
        }
    }
}
