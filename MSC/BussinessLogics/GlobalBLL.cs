using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace MSC.BussinessLogics
{
    public class GlobalBLL
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MSCEntities"].ConnectionString;
        }
    }
}
