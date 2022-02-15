using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class AccountDAO
    {
        BanDoDienTuDbContext db = null;
        public AccountDAO()
        {
            db = new BanDoDienTuDbContext();
        }
        public long Insert(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return customer.ID;
        }
        public bool Login(string username, string password)
        {
            var result = db.Customers.Count(x => x.UserName == username && x.Password == password);
            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
