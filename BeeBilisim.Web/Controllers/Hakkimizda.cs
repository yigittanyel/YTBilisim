using BeeBilisim.Web.Models;
using BeeBilisim.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeeBilisim.Web.Controllers
{
    [AllowAnonymous]
    public class Hakkimizda : Controller
    {
        private readonly BeeDbContext _dbContext;

        public Hakkimizda(BeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            HakkimizdaViewModel vm = new HakkimizdaViewModel();
            vm.HakkimizdaModels = _dbContext.HakkimizdaModels.ToList();
            vm.HakkimizdaSliderModels = _dbContext.HakkimizdaSliderModels.ToList();
            return View(vm);
        }

        public PartialViewResult HakkimizdaSlider()
        {
            HakkimizdaViewModel vm = new HakkimizdaViewModel();
            var sliderlar = vm.HakkimizdaSliderModels.OrderBy(x =>x.Sira).ToList();
            return PartialView(sliderlar);
        }
    }
}
