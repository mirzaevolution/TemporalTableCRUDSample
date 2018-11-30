using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using MSC.Models;
using MirzaCryptoHelpers.Hashings;

namespace MSC.BussinessLogics
{
    public class UsersBLL
    {
        public UserLoginResult Login(string username, string password)
        {
            UserLoginResult result = new UserLoginResult();
            try
            {
                using(SqlConnection sqlConn = new SqlConnection(GlobalBLL.GetConnectionString()))
                {
                    Users user = sqlConn.QueryFirstOrDefault<Users>("SELECT UserName, PasswordHash FROM vx.Users WHERE UserName=@UserName AND PasswordHash=@PasswordHash",
                        new
                        {
                            UserName = username,
                            PasswordHash = new SHA256Crypto().GetHashBase64String(password)
                        });
                    if(user==null)
                    {
                        result.Error = "Invalid credentials";
                        result.Granted = false;
                    }
                    else
                    {
                        result.UserName = username;
                        result.Granted = true;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Granted = false;
                result.Error = ex.ToString(); 
            }
            return result;
        }
    }
}
