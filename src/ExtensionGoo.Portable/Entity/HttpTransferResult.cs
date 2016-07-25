using System;
using System.Collections.Generic;
using System.Net;

namespace ExtensionGoo.Portable.Entity
{
    public class HttpTransferResult
    {
        public string Result { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }

        public Exception DownloadException { get; set; }

        public bool IsSuccessCode { get; set; }

        public Dictionary<string, List<string>> Headers { get; set; }
    }
}
