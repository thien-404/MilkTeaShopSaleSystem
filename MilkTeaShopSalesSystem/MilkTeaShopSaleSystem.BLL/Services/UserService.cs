using MilkTeaShopSaleSystem.DAL.Models;
using MilkTeaShopSaleSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTeaShopSaleSystem.BLL.Services
{
    public class UserService
    {
        private UserRepository _repo = new();

        public User GetAccount(string e, string p)
        {
            return _repo.GetOne(e, p);
        }
    }
}
