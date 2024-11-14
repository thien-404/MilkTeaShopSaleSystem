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
        public void ChangeStatusDrinks(Drink drink)
        {
            _repo.DeleteDrink(drink);
        }
        public void UpdateDrinks(Drink drink)
        {
            _repo.UpdateDrink(drink);   
        }
        public void CreateDrinks(Drink drink)
        {
            _repo.CreateDrink(drink);
        }
        public List<Drink> getDrinksByName(string name)
        {
            return _repo.SearchDrinksByName(name);
        }
        public List<Drink> getDrinkByStatus(int? status)
        {
            return _repo.GetDrinksByStatus(status);
        }
    }
}
