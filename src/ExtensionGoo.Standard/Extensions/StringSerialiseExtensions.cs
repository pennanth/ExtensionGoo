using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace ExtensionGoo.Standard.Extensions
{
    public static class SerialiseExtension
    {
        public static TEntity Deserialise<TEntity>(this string data, Action<Exception> exceptionHandler = null)
            where TEntity : class
        {
            try
            {
                var resultCatch1 = JsonConvert.DeserializeObject<TEntity>(data);
                return resultCatch1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("JSON Load corrupt: {0}", ex.ToString());
                exceptionHandler?.Invoke(ex);
            }

            return null;
        }


        public static string Serialise<TEntity>(this TEntity obj, Action<Exception> exceptionHandler = null)
            where TEntity : class
        {
            try
            {
                var resultCatch1 = JsonConvert.SerializeObject(obj);
                return resultCatch1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("JSON Load corrupt: {0}", ex.ToString());
                exceptionHandler?.Invoke(ex);
            }

            return null;
        }
    }
}
