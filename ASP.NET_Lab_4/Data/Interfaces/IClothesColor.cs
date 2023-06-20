using ASP.NET_Lab_4.Data.Models;
using System.Collections.Generic;

namespace ASP.NET_Lab_4.Data.Interfaces
{
    public interface IClothesColor
    {
        IEnumerable<Color> AllColors { get; }
    }
}
