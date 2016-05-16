using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Utilities;
using Newtonsoft.Json;

namespace Microsoft_Project
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {

                string stensaxpåse = message.Text.ToLower();
 
                Random rng = new Random();
                int bot = rng.Next(3);
                //0=sten 1=sax 2=påse
                string resultat="";
                switch (stensaxpåse)
                {
                    case "sten":
                        switch(bot)
                        {
                            case 0: resultat = "Lika"; break;
                            case 1: resultat = "Vinst"; break;
                            case 2: resultat = "Förlust"; break;
                        }
                        break;
                    case "sax":
                        switch (bot)
                        {
                            case 1: resultat = "Lika"; break;
                            case 2: resultat = "Vinst"; break;
                            case 0: resultat = "Förlust"; break;
                        }
                        break;
                    case "påse":
                        switch (bot)
                        {
                            case 2: resultat = "Lika"; break;
                            case 0: resultat = "Vinst"; break;
                            case 1: resultat = "Förlust"; break;
                        }
                        break;
                }

                return message.CreateReplyMessage(resultat);

                // return our reply to the user

            }
            else
            {
                return HandleSystemMessage(message);
            }
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }
}