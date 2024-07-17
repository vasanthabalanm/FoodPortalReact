using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManageDL.MailHelper
{
    public interface IMailRepo
    {
        void SendOrderApproveMail(string ToMail);
    }
}
