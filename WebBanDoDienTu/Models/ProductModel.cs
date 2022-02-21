using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanDoDienTu.Models
{
    public class ProductModel
    {
        private BANDODIENTUContext db = new BANDODIENTUContext();
        public List<Product> FindAll()
        {
            var a = db.Product.ToList();
            return a;
        }
        public Product Find(long id)
        {
            var a = db.Product.Find(id);
            return a;
        }
    }
}
