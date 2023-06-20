using ASP.NET_Lab_4.Data.Models;

namespace ASP.NET_Lab_4.Data.Interfaces
{
    public interface IClothesTypes
    {
        IEnumerable<Types> AllTypes { get; }
    }
}
