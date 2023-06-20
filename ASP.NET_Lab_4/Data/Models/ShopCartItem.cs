namespace ASP.NET_Lab_4.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public Clothes cloth { get; set; }
        public decimal price { get; set; }
        public string ShopCartId { get; set; }
    }
}
