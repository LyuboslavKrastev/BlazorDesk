
using System.Collections.Generic;

namespace BlazorDesk.Server.Helpers
{
    public class RegisterResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
