using ASP.NET_Lab_4.Data.Models;

namespace ASP.NET_Lab_4.Data.Interfaces
{
    public interface IClothesCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
