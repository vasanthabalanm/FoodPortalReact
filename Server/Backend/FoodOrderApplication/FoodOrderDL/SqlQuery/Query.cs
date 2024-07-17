using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderDL.SqlQuery
{
    public class Query
    {
        public const string CountApprovedUser = "select count(*) as ApprovedUser from ApprovedUsers where UserRole = 'User'";
    }
}
