using System;
using Todo_Asp_Mvc.Net.Models;

namespace Todo_Asp_Mvc.Net.Services
{
    public class Messagerie : IMessagerie
    {
        public void SendEmail(MessageEmail emailSend)
        {
           Console.WriteLine("Send Email !");
        }
    }
}