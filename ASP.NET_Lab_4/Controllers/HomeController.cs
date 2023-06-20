using ASP.NET_Lab_4.Data.Interfaces;
using ASP.NET_Lab_4.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Lab_4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllClothes _clothRep;
        public HomeController(IAllClothes clothRep)
        {
            _clothRep = clothRep;
        }

        [Route("")]
        public ViewResult Index() 
        {
            var homeClothes = new HomeViewModel
            {
                favCloth = _clothRep.ClothesMale
            };
            return View(homeClothes);

        }
    }
}
