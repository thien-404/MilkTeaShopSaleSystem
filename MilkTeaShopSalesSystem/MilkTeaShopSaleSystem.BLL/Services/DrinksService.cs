using MilkTeaShopSaleSystem.DAL.Models;
using MilkTeaShopSaleSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTeaShopSaleSystem.BLL.Services
{
    public class DrinksService
    {
        private DrinksRepository _repo = new();

        public List<Drink> getAllDrinks()
        {
            return _repo.getDrinksList();
        }
    }
}
