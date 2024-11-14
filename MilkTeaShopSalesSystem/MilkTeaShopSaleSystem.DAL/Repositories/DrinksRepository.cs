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
        public void DeleteDrink(Drink drink)
        {
            _context = new MilkTeaShopSaleDbContext();
            if (drink.DrinkStatus == 1)
                _context.Drinks.FirstOrDefault(d => d.DrinkId == drink.DrinkId).DrinkStatus = 2;
            if (drink.DrinkStatus == 2)
                _context.Drinks.FirstOrDefault(d => d.DrinkId == drink.DrinkId).DrinkStatus = 1;
            _context.SaveChanges();
        }
        public void UpdateDrink(Drink drink)
        {
            _context = new MilkTeaShopSaleDbContext();
            _context.Drinks.Update(drink);
            _context.SaveChanges();
        }
        public void CreateDrink(Drink drink)
        {
            _context = new MilkTeaShopSaleDbContext();
            _context.Drinks.Add(drink);
            _context.SaveChanges();
        }
        public List<Drink> SearchDrinksByName(string name)
        {

            return _context.Drinks.Where(d => d.DrinkName.Contains(name)).ToList();
        }
        public List<Drink> GetDrinksByStatus(int? status)
        {
            _context = new MilkTeaShopSaleDbContext();

           
            if (status == null)
            {
               
                return _context.Drinks.ToList();
            }
            return _context.Drinks.Where(d => d.DrinkStatus == status).ToList();
        }

    }
}
