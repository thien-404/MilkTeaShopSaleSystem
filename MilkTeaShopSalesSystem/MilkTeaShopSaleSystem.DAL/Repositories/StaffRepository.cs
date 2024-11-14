using MilkTeaShopSaleSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTeaShopSaleSystem.DAL.Repositories
{
    public  class StaffRepository
    {
        private MilkTeaShopSaleDbContext _context; 

        public List<User> GetAll()
        {
            _context = new();
            return _context.Users.ToList();
        }
        public void Create(User obj)
        {
            _context = new();
            _context.Users.Add(obj);
            _context.SaveChanges();
        }
        public void Update(User obj)
        {
            _context = new();
            _context.Users.Update(obj);
            _context.SaveChanges();
        }
        public List<User> Search(string StaffName, string Email_)
        {
            _context = new();
            List<User> result = _context.Users.ToList();

            
            if (string.IsNullOrWhiteSpace(StaffName) && string.IsNullOrWhiteSpace(Email_))
                return result;

            
            if (!string.IsNullOrWhiteSpace(StaffName) && !string.IsNullOrWhiteSpace(Email_))
                return result.Where(x => x.UserName.ToLower().Contains(StaffName.ToLower()) || x.Email.ToLower().Contains(Email_.ToLower())).ToList();

            
            if (!string.IsNullOrWhiteSpace(StaffName))
                return result.Where(x => x.UserName.ToLower().Contains(StaffName.ToLower())).ToList();

            //4.Tình huống user gõ số và k gõ text
            return result.Where(x => x.Email.ToLower().Contains(Email_.ToLower())).ToList();


            return null;
        }

    }
}
