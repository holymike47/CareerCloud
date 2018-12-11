using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public abstract class BaseDataRepository
    {
        protected string ConnectionString;
        public BaseDataRepository()
        {
            ConnectionString = @"Data Source=DESKTOP-7SBTKDS\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True;";
        }
    }
}
