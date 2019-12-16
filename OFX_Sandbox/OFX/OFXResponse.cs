using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFX_Sandbox.OFX
{
    public class OFXResponse
    {
        public bool Success { get; }
        public string Raw { get; }
        public OFXResponse(bool success, string body)
        {
            Success = success;
            Raw = body;
        }
    }
}
