using LibrarieModele;
using NivelAccessDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserAccessor UA = new UserAccessor("");
            List<USER> list = UA.GetUsers();
            foreach (USER user in list)
            {
                Console.WriteLine($"User: {user.USER_ID}, {user.USERNAME}, {user.PASSWORD}, {user.EMAIL}, {user.PHONE}, {user.REGISTRATION_DATE}, {user.LAST_LOGIN_DATE}");
            }
            Console.ReadKey();
        }
    }
}