using MilkTeaShopSaleSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTeaShopSaleSystem.DAL.Repositories
{
    public class PriceRepository
    {
        private MilkTeaShopSaleDbContext _context;

        public List<Price> getPrice(Drink drink)
        {
            _context = new MilkTeaShopSaleDbContext();
            return _context.Prices.Where(p => p.DrinkId.ToString() == drink.DrinkId.ToString()).ToList();
        }
        public void changeStatusPrice(Price price)
        {
          
            _context = new MilkTeaShopSaleDbContext();
            if (price.PriceStatus == 1)
                _context.Prices.FirstOrDefault(p => p.Size == price.Size && p.DrinkId.ToString()==price.DrinkId.ToString()).PriceStatus = 2;
         
            if (price.PriceStatus == 2)
                _context.Prices.FirstOrDefault(p => p.Size == price.Size && p.DrinkId.ToString() == price.DrinkId.ToString()).PriceStatus = 1;
       
            _context.SaveChanges();
        }
        public void CreatePrice(Price price)
        {
            _context = new MilkTeaShopSaleDbContext();
            _context.Prices.Add(price);
            _context.SaveChanges();
        }
        public void UpdatePrice(Price price)
        {
            _context = new MilkTeaShopSaleDbContext();
            _context.Prices.Update(price);
            _context.SaveChanges();
        }

    }
}
