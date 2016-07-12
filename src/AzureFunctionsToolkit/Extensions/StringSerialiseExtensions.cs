using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AzureFunctionsToolkit.Extensions
{
    public static class SerialiseExtension
    {
        public static string Serialise<TEntity>(this TEntity obj)
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
            }

            return null;
        }
    }
}
