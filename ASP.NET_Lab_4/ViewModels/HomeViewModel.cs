using ASP.NET_Lab_4.Data.Models;

namespace ASP.NET_Lab_4.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Clothes> favCloth { get; set; }
    }
}
