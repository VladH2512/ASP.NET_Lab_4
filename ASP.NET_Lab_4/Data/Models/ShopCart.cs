using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Lab_4.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;
        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDBContent>();

            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Clothes cloth)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                cloth = cloth,
                price = cloth.Price
            });
            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> getShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.cloth).ToList();
        }

    }

}
