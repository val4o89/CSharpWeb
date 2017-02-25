﻿namespace SimpleHttpServer.Models
{
    using Enums;
    using System.Text;

    public class HttpRequest
    {
        public RequestMethod Method { get; set; }

        public string Url { get; set; }

        public Header Header { get; set; }

        public string Content { get; set; }

        public override string ToString()
        {
            var request = new StringBuilder();

            request.AppendLine($"{this.Method} {this.Url} HTTP/1.0");

            request.AppendLine(this.Header.ToString());

            if (Method == RequestMethod.POST)
            {
                request.AppendLine(this.Content);
            }

            return request.ToString();
        }
    }
}
