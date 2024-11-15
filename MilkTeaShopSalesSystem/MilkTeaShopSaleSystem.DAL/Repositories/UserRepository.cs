using MilkTeaShopSaleSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTeaShopSaleSystem.DAL.Repositories
{
    public class UserRepository
    {
        private MilkTeaShopSaleDbContext _context;

        public User GetOne(string e, string p)
        {
            _context = new();
            return _context.Users.FirstOrDefault(x => x.Email.ToLower() == e && x.Password == p);
        }
    }
}
