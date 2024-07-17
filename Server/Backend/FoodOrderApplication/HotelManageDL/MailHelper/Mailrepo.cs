using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageDL.MailHelper
{
    public class Mailrepo : IMailRepo
    {
        //approve mail
        public void SendOrderApproveMail(string ToMail)
        {
            string senderMail = "vasanthabalanm.kanini@gmail.com";
            string senderPassword = "jshjmjnbbkdkylwi";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(senderMail);
            message.Subject = "OrderApproval regard - regards";
            message.To.Add(new MailAddress(ToMail));

            //template html
            string messageContent = "<html>" +
                "<head>" +
                    "<style>" +
                        "body { font-family: 'Arial', sans-serif; background-color: #f4f4f4;}" +
                        "p { font-weight: 600; color: #333;}" +
                    "</style>" +
                "</head>" +
                "<body>" +
                    "<p>Welcome to Online Food order!</p>" +
                    "<p>Please pick your order within 30 mins.</p>" +
                "</body>" +
            "</html>";

            message.Body = messageContent;
            message.IsBodyHtml = true;

            var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(senderMail, senderPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
        }
    }
}
