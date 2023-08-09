using Todo_Asp_Mvc.Net.Models;

namespace Todo_Asp_Mvc.Net.Services
{
    public interface IMessagerie
    {
        void SendEmail(MessageEmail emailSend);
    }
}