using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC.Models
{
    public class UserLoginResult
    {
        public bool Granted { get; set; }
        public string UserName { get; set; }
        public string Error { get; set; }
    }
    public class Users
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
