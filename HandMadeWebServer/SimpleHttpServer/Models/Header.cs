namespace SimpleHttpServer.Models
{
    using Enums;
    using System.Collections.Generic;
    using System.Text;

    public class Header
    {
        public Header(HeaderType headerType)
        {
            this.Type = headerType;
            this.ContentType = "text/html";
            this.Cookies = new CookieCollection();
            this.OtherParameters = new Dictionary<string, string>();
        }

        public string ContentLength { get; set; }
        public string ContentType { get; set; }
        public CookieCollection Cookies { get; private set; }
        public Dictionary<string, string> OtherParameters { get; set; }
        public HeaderType Type { get; set; }

        public override string ToString()
        {
            var header = new StringBuilder();

            header.AppendLine($"Content-Type: {this.ContentType}");

            if (Cookies.Count > 0)
            {
                foreach (var cookie in Cookies)
                {
                    header.AppendLine($"Set-Cookie: {cookie.ToString()}");
                }
            }
            if (ContentLength != null)
            {
                header.AppendLine($"Content-Length: {this.ContentLength}");
            }
            foreach (var otherParameter in OtherParameters)
            {
                header.AppendLine($"{otherParameter.Key}: {otherParameter.Value}");
            }

            header.AppendLine();

            return header.ToString();
        }
    }
}
