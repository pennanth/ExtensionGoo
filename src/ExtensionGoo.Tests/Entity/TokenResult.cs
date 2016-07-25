using System.Collections.Generic;

namespace ExtensionGoo.Tests.Entity
{
    public class TokenResult
    {
        public bool IsValid { get; set; }
        public string FailReason { get; set; }
        public Dictionary<string, string> Claims { get; set; }
    }
}
