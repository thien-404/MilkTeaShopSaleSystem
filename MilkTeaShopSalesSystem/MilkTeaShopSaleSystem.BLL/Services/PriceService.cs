using MilkTeaShopSaleSystem.DAL.Models;
using MilkTeaShopSaleSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTeaShopSaleSystem.BLL.Services
{
    public class PriceService
    {
        private PriceRepository _repo = new();
        public List<Price> getListPrice(Drink drink)
        {
            return _repo.getPrice(drink);   
        }
        public void changStatusPrice(Price price)
        {
            _repo.changeStatusPrice(price);
        }
        public void UpdatePrice(Price price)
        {
            _repo.UpdatePrice(price);
        }
        public void CreatePrice(Price price)
        {
            _repo.CreatePrice(price);
        }
    }
}
