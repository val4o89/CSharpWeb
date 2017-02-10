using SimpleHttpServer.Enums;
using System.Text;

namespace SimpleHttpServer.Models
{
    public class HttpResponse
    {
        public HttpResponse()
        {
            this.Header = new Header(HeaderType.HttpResponse);
            this.Content = new byte[] { };
        }
        public ResponseStatusCode StatusCode { get; set; }

        public string StatusMessage { get { return this.StatusCode.ToString(); } }

        public Header Header { get; set; }

        public byte[] Content { get; set; }

        public string ContentAsUTF8
        {
            set { this.Content = Encoding.UTF8.GetBytes(value); }
        }

        public override string ToString()
        {
            var response = new StringBuilder();
            response.AppendLine($"HTTP/1.0 {(int)this.StatusCode} {this.StatusMessage}");
            response.AppendLine(Header.ToString());

            return response.ToString();
        }
    }
}
