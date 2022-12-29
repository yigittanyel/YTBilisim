using BeeBilisim.Web.Models;
using BeeBilisim.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeBilisim.Web.Controllers
{
    [AllowAnonymous]
    public class AnaSayfaController : Controller
    {
        private readonly BeeDbContext _dbContext;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public AnaSayfaController(BeeDbContext dbContext, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            AnasayfaViewModel vm=new AnasayfaViewModel();
            vm.AnasayfaModels = _dbContext.AnasayfaModels.ToList();
            vm.AnaSayfaSliderModels = _dbContext.AnaSayfaSliderModels.ToList();
            vm.ReferasanslarModels=_dbContext.ReferasanslarModels.ToList();
            vm.AnasayfaMusteriYorumlariModel=_dbContext.AnasayfaMusteriYorumlariModels.ToList();
            return View(vm);
        }


        public PartialViewResult AnaSayfaSlider()
        {
            AnasayfaViewModel vm = new AnasayfaViewModel();
            var sliderlar = vm.AnaSayfaSliderModels.OrderBy(x => x.Sira).ToList();
            return PartialView(sliderlar);
        }

        public PartialViewResult Referanslar()
        {
            AnasayfaViewModel vm = new AnasayfaViewModel();
            var referanslar=vm.ReferasanslarModels.OrderBy(x => x.Sira).ToList();
            return PartialView(referanslar);
        }

        public PartialViewResult MusteriYorumlari()
        {
            AnasayfaViewModel vm = new AnasayfaViewModel();
            var musteriYorumlari = vm.AnasayfaMusteriYorumlariModel.ToList();
            return PartialView(musteriYorumlari);
        }

        #region wwwroottan çekme

        //public PartialViewResult GetImages()
        //{
        //    string[] filePaths = Directory.GetFiles(Path.Combine(hostingEnvironment.WebRootPath, "images/"));
        //    List<ReferasanslarModel> files = new List<ReferasanslarModel>();
        //    foreach (string filePath in filePaths)
        //    {
        //        files.Add(new ReferasanslarModel { ImageName = Path.GetFileName(filePath) });
        //    }

        //    return PartialView(files);
        //}
        #endregion
    }
}
