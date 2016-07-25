using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ExtensionGoo.Standard.Entity;

namespace ExtensionGoo.Standard.Helpers
{
    public static class HttpHelper
    {
        public static async Task<HttpTransferResult> Transfer(HttpTransferConfig config)
        {
            var httpHandler = new HttpClientHandler();

           

            using (var httpClient = new HttpClient(httpHandler))
            {
                var method = HttpMethod.Get;

                switch (config.Verb)
                {
                    case "GET":
                        method = HttpMethod.Get;
                        break;
                    case "POST":
                        method = HttpMethod.Post;
                        break;
                    case "PUT":
                        method = HttpMethod.Put;
                        break;
                    case "DELETE":
                        method = HttpMethod.Delete;
                        break;
                }

                using (var message = new HttpRequestMessage(method, config.Url))
                {
                    if (config.Headers != null)
                    {
                        foreach (var item in config.Headers)
                        {
                            message.Headers.Add(item.Key, item.Value);
                        }
                    }

                    // Accept-Encoding:
                    if (config.AcceptEncoding != null)
                    {
                        //message.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue(""));
                        message.Headers.Add("Accept-Encoding", config.AcceptEncoding);
                    }


                    // Accept:
                    if (!string.IsNullOrWhiteSpace(config.Accept))
                    {
                        message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(config.Accept));
                    }


                    if (!string.IsNullOrWhiteSpace(config.Data))
                    {
                        var content = new StringContent(config.Data, Encoding.UTF8,
                            config.ContentEncoding ?? "application/json");
                        message.Content = content;
                    }

                    if (config.ByteData != null)
                    {
                        var content = new ByteArrayContent(config.ByteData, 0, config.ByteData.Length);

                        message.Content = content;
                    }

                    if (config.Auth != null && config.AuthScheme != null)
                    {
                        message.Headers.Authorization = new AuthenticationHeaderValue(config.AuthScheme,
                            config.Auth);
                    }

                    if (config.Timeout != 0)
                    {
                        httpClient.Timeout = TimeSpan.FromSeconds(config.Timeout);
                    }

                    try
                    {
                        Debug.WriteLine("{0}: {1}", config.Verb.ToLower() == "get" ? "Downloading" : "Uploading", config.Url);

                        using (var result = await httpClient.SendAsync(message))
                        {
                            Debug.WriteLine("Finished: {0}", config.Url);
                            return await GetResult(result, config);
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Debug.WriteLine("Warning - HttpRequestException encountered: {0}", ex.Message);

                        return new HttpTransferResult { DownloadException = ex, Result = null, IsSuccessCode = false };
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Warning - general HTTP exception encountered: {0}", ex.Message);
                        return new HttpTransferResult { DownloadException = ex, Result = null, IsSuccessCode = false };
                    }
                }
            }

        }

        public static async Task<HttpTransferResult> GetResult(HttpResponseMessage result, HttpTransferConfig originalConfig)
        {
            try
            {
                var resultText = "";

                var isSuccess = true;

                if (result.Content != null)
                {
                    resultText = await result.Content.ReadAsStringAsync();
                }

                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    isSuccess = false;
                }

                if (!result.IsSuccessStatusCode)
                {
                    isSuccess = false;
                }

                var headers = new Dictionary<string, List<string>>();

                if (result.Headers != null)
                {
                    foreach (var item in result.Headers)
                    {
                        headers.Add(item.Key, item.Value.ToList());
                    }
                }

                return new HttpTransferResult
                {
                    HttpStatusCode = result.StatusCode,
                    Result = resultText,
                    IsSuccessCode = isSuccess,
                    Headers = headers
                };
            }
            catch (Exception ex)
            {
                return new HttpTransferResult { DownloadException = ex, Result = null, IsSuccessCode = false };
            }
        }


    }
}
