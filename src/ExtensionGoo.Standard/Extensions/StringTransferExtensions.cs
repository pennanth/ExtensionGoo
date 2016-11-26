using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using ExtensionGoo.Standard.Helpers;
using Newtonsoft.Json;

namespace ExtensionGoo.Standard.Extensions
{
    public static class StringTransferExtensions
    {
        public static async Task<TEntityResult> PostAndParse<TEntityResult, TEntitySend>(this string url,
            TEntitySend postObject, string method = "POST", IDictionary<string, string> headers = null, Action<Exception> exceptionHandler = null)
        where TEntityResult : class
        where TEntitySend : class

        {
            var objSer = postObject.Serialise(exceptionHandler);

            var config = HttpConfigHelper.GetJsonConfig(url, objSer);

            var result = await HttpHelper.Transfer(config);

            if (!result.IsSuccessCode)
            {
                exceptionHandler?.Invoke(result.DownloadException);
                return null;
            }

            var des = result.Result.Deserialise<TEntityResult>(exceptionHandler);

            return des;
        }


        public static async Task<TEntityType> GetAndParse<TEntityType>(
            this string url,
            IDictionary<string, string> headers = null,
            Action<Exception> exceptionHandler = null
            ) where TEntityType : class
        {
            var config = HttpConfigHelper.GetJsonConfig(url, null, null, "GET", headers);

            var result = await HttpHelper.Transfer(config);

            if (!result.IsSuccessCode || result.Result == null)
            {
                return null;
            }

            var des = result.Result.Deserialise<TEntityType>(exceptionHandler);

            return des;
        }

        public static async Task<string> GetRaw(this string url, IDictionary<string, string> headers = null, Action<Exception> exceptionHandler = null)
        {
            var config = HttpConfigHelper.GetJsonConfig(url, null, null, "GET", headers);

            var result = await HttpHelper.Transfer(config);

            if (!result.IsSuccessCode)
                exceptionHandler?.Invoke(result.DownloadException);

            return result.Result;
        }

        public static async Task<string> Post(this string url, string data, IDictionary<string, string> headers = null, Action<Exception> exceptionHandler = null)

        {
            var config = HttpConfigHelper.GetJsonConfig(url, data, null, "POST", headers);

            var result = await HttpHelper.Transfer(config);

            if (!result.IsSuccessCode)
                exceptionHandler?.Invoke(result.DownloadException);

            return result.Result;
        }

        public static async Task<string> Post(this string url, byte[] data, IDictionary<string, string> headers = null, Action<Exception> exceptionHandler = null)
        {
            var config = HttpConfigHelper.GetJsonConfig(url, null, data, "POST", headers, "application/octet-stream");

            var result = await HttpHelper.Transfer(config);

            if (!result.IsSuccessCode)
                exceptionHandler?.Invoke(result.DownloadException);

            return result.Result;
        }
    }
}
