using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AthletesAccounting.DataBase.User
{
    public class Hash
    {
        public static string getHashSha256(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        public static string  getHashSha256FromBD(string login)
        {
            try
            {
                using (UserContext db = new UserContext())
                {
                    var result = db.Users
                        .AsEnumerable()
                        .Where(c => c.login == login)
                        .Select(c => c.password)
                        .FirstOrDefault()
                        .ToString();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
