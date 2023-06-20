namespace ASP.NET_Lab_4.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderID { get; set; }
        public int clothID { get; set; }
        public decimal price { get; set; }
        public virtual Clothes clothes { get; set; }
        public virtual Order order { get; set; }
    }
}
