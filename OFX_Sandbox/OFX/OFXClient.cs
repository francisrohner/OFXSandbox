using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OFX_Sandbox.OFX
{
    public class OFXClient
    {
        public static OFXClient Instance => instance;
        private static readonly OFXClient instance;
        static OFXClient()
        {
            //If unset, sink
            if (ServicePointManager.ServerCertificateValidationCallback == null)
            {
                ServicePointManager.ServerCertificateValidationCallback += (se, certificate, chain, policyErrors) => { return true; };
            }
            instance = new OFXClient();
        }
        private OFXClient() {}
        
        public OFXResponse PostRequest(OFXRequest request)
        {
            ResponseData response = POST(request.Endpoint, request.Content);
            return new OFXResponse(response.Success, response.Content);            
        }

        private ResponseData POST(string url, string body)
        {            
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.ContentType = "application/x-ofx";
                request.Accept = "*/*, application/x-ofx";
                request.Method = "POST";
                SetRequestBody(request, body);
                return ReadResponse(request.GetResponse() as HttpWebResponse);
            }
            catch(WebException ex)
            {
                if(ex.Response is HttpWebResponse errResponse)
                {
                    return ReadResponse(errResponse);
                }
            }            
            return new ResponseData(); //Only returned on invalid response
        }
        
        private ResponseData ReadResponse(HttpWebResponse response)
        {            
            string body = string.Empty;            
            using(StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                body = reader.ReadToEnd();
            }            
            return new ResponseData(response.StatusCode, body);
        }

        private void SetRequestBody(WebRequest request, string body)
        {
            byte[] content = Encoding.ASCII.GetBytes(body);
            request.ContentLength = content.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(content, 0, content.Length);
            }
        }
    }
    public class ResponseData
    {
        HttpStatusCode? StatusCode { get; }
        public string Content { get; }
        public bool Success => StatusCode == HttpStatusCode.OK;
        public ResponseData()
        {            
        }
        public ResponseData(HttpStatusCode code, string body)
        {
            StatusCode = code;
            Content = body;
        }
    }
}
