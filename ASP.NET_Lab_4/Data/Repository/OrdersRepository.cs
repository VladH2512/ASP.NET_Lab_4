using ASP.NET_Lab_4.Data.Interfaces;
using ASP.NET_Lab_4.Data.Models;

namespace ASP.NET_Lab_4.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;
        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;

            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();

            var items = shopCart.listShopItems;

            foreach (var el in items)
            {
                appDBContent.SaveChanges();

                var orderDetail = new OrderDetail()
                {
                    clothID = el.cloth.Id,
                    orderID = order.id,
                    price = el.cloth.Price
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }

        }
    }
}
