using KivesDatabase;
using Knives.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FirstServerTest
{
    public static class RetrieveContactUs
    {
        public static void AddMessageToDb(KnivesDbContext db, string content)
        {
            string[] messageData = WebUtility.UrlDecode(content).Split('&');

            if (messageData.Length != 3)
            {
                return;
            }
            var messageDbModel = new Message();

            foreach (var item in messageData)
            {
                var kvp = item.Split('=').Select(x => x.Trim()).ToArray();

                if (kvp[0] == "email")
                {
                    messageDbModel.Email = kvp[1];
                }
                else if (kvp[0] == "subject")
                {
                    messageDbModel.Subject = kvp[1];
                }
                else if (kvp[0] == "message")
                {
                    messageDbModel.MessageText = kvp[1];
                }
            }

            db.Messages.Add(messageDbModel);

            db.SaveChanges();
        }
    }
}
