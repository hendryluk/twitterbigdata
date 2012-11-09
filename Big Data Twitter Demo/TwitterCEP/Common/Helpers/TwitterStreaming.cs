using System;
using System.IO;
using System.Net;

namespace StreamInsight.Demos.Twitter.Common
{
    public class TwitterStreaming
    {
        private TwitterConfig _config;

        public TwitterStreaming(TwitterConfig config)
        {
            this._config = config;
        }

        public TextReader Read()
        {
            var url = GetURL();
            var request = HttpWebRequest.Create(url);
            request.Timeout = _config.Timeout;

            request.Credentials = new NetworkCredential(_config.Username, _config.Password);
            var response = request.GetResponse();

            return new StreamReader(response.GetResponseStream());
        }

        private string GetURL()
        {
            string result = this._config.StreamingURL;

            if (!string.IsNullOrEmpty(_config.Parameters))
                result += "?track=" + _config.Parameters;

            return result;
        }
    }
}
