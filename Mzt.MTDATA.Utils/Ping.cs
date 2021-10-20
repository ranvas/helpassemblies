using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Mzt.MTDATA.Utils
{
    public class PingResult
    {
        public bool IsOK { get; set; }
        public string Exception { get; set; }
    }

    public static class Ping
    {
        public static PingResult PingUrl(string url, int timeoutMs = 10000)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                // Network does not available.
                return null;
            }

            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Timeout = timeoutMs;
                request.AllowAutoRedirect = false; // find out if this site is up and don't follow a redirector
                request.Method = "HEAD";

                using (var response = request.GetResponse())
                {
                    return new PingResult()
                    {
                        IsOK = true
                    };
                }
            }
            catch (Exception e)
            {
                return new PingResult()
                {
                    IsOK = false,
                    Exception = e.Message
                };
            }
        }
    }
}
