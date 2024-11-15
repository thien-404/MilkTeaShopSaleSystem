using MilkTeaShopSaleSystem.DAL.Models;
using MilkTeaShopSaleSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTeaShopSaleSystem.BLL.Services
{
    public class StaffService
    {
        private StaffRepository _repo = new();

        public List<User> GetAllStaff()
        {
            return _repo.GetAll();
        }
        public void CreateUser(User obj)
        {
            _repo.Create(obj);
        }
        public void UpdateUser(User obj)
        {
            _repo.Update(obj);
        }
        public List<User> Search(string StaffName, string Email_) => _repo.Search(StaffName, Email_);
    }
}
