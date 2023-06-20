using ASP.NET_Lab_4.Data.Interfaces;
using ASP.NET_Lab_4.Data.Models;
using ASP.NET_Lab_4.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Lab_4.Data.Controllers
{
    public class ClothesController: Controller
    {
        private readonly IAllClothes _allClothes;
        private readonly IClothesColor _allColor;

        public ClothesController(IAllClothes allClothes, IClothesColor allColor)
        {
            _allClothes = allClothes;
            _allColor = allColor;
        }

        [Route("Clothes/List")]
        [Route("Clothes/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Clothes> clothes = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                clothes = _allClothes.Clothes.OrderBy(i => i.Id);
            }
            else
            {

                if (string.Equals("baby", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    clothes = _allClothes.Clothes.Where(i => i.Category.CategoryName.Equals("Childish")).OrderBy(i => i.Id);
                    currCategory = "Childish";
                }
                else if (string.Equals("men", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    clothes = _allClothes.Clothes.Where(i => i.Category.CategoryName.Equals("Male")).OrderBy(i => i.Id);
                    currCategory = "Male";
                }
                else if (string.Equals("women", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    clothes = _allClothes.Clothes.Where(i => i.Category.CategoryName.Equals("Female")).OrderBy(i => i.Id);
                    currCategory = "Female";
                }
            }

            currCategory = _category;

            var clothObj = new ClothesListViewModels
            {
                allClothes = clothes,
                currCategory = currCategory
            };

            ViewBag.Title = "Page with Clothes";
            return View(clothObj);
        }
    }
}
