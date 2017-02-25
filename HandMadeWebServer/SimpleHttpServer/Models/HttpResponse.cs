namespace SimpleHttpServer.Models
{
    using Enums;
    using System;
    using System.Text;
    public class HttpResponse
    {
        public HttpResponse()
        {
            Header = new Header(HeaderType.HttpResponse);
            Content = new byte[] { };
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
            response.Append(Header.ToString());
            Console.WriteLine(response);
            return response.ToString();
        }
    }
}
