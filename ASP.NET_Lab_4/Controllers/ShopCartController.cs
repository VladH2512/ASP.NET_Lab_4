using ASP.NET_Lab_4.Data.Interfaces;
using ASP.NET_Lab_4.Data.Models;
using ASP.NET_Lab_4.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Lab_4.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllClothes _clothRep;
        private readonly ShopCart _shopCart;
        public ShopCartController(IAllClothes clothRep, ShopCart shopCart)
        {
            _clothRep = clothRep;
            _shopCart = shopCart;
        }
        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;
            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }
        public RedirectToActionResult AddToCart(int id)
        {
            var item = _clothRep.Clothes.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }

    }
}
