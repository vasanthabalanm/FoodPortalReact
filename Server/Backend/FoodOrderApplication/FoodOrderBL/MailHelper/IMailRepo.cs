using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderBL.MailHelper
{
    public interface IMailRepo
    {
        string SendMail(string senderMail);
        void SendOrderApproveMail(string ToMail);
    }
}
