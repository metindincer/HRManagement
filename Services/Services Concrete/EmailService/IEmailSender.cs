using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services_Concrete.EmailService
{
        public interface IEmailSender
        {
            void SendEmail(Message message);
            Task SendEmailAsync(Message message);
        }   
}
