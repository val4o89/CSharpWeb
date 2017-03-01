using SimpleHttpServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMore.Services
{
    public static class LangService
    {
        public static void SetLanguage(HttpResponse response, string language)
        {

            var langCookie = new Cookie("lang", language);
            response.Header.Cookies.Add(langCookie);

        }
    }
}
