using MilkTeaShopSaleSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTeaShopSaleSystem.DAL.Repositories
{
    public class DrinksRepository
    {
        private MilkTeaShopSaleDbContext _context;

        public List<Drink> getDrinksList()
        {
            _context = new MilkTeaShopSaleDbContext();
            return _context.Drinks.ToList();
        }
    }
}
