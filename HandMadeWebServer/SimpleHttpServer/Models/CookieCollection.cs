using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpServer.Models
{
    public class CookieCollection : IEnumerable<Cookie>
    {
        private Dictionary<string, Cookie> cookieCollection;

        public CookieCollection()
        {
            this.cookieCollection = new Dictionary<string, Cookie>();
        }

        public int Count
        {
            get
            {
                return this.cookieCollection.Count;
            }
        }

        public void AddCookie(Cookie cookie)
        {
            this.cookieCollection.Add(cookie.Name, cookie);
        }

        public bool ContainsKey(string key)
        {
            if (this.cookieCollection.ContainsKey(key))
            {
                return true;
            }

            return false;
        }
        public Cookie this[string key]
        {
            get
            {
                return this.cookieCollection[key];
            }

            set
            {
                this.cookieCollection[key] = value;
            }
        }

        public IEnumerator<Cookie> GetEnumerator()
        {
            return this.cookieCollection.Values.GetEnumerator();
        }

        public void RemoveCookie(string cookieName)
        {
            this.cookieCollection.Remove(cookieName);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(";", cookieCollection.Values);
        }
    }
}
