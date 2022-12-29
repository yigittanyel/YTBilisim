using BeeBilisim.Web.Models;
using NuGet.DependencyResolver;

namespace BeeBilisim.Web.ViewModels
{
    public class AnasayfaViewModel
    {
        public IEnumerable<AnasayfaModel> AnasayfaModels { get; set; }
        public IEnumerable<AnaSayfaSliderModel> AnaSayfaSliderModels { get; set; }
        public IEnumerable<ReferasanslarModel> ReferasanslarModels { get; set; }
        public IEnumerable<AnasayfaMusteriYorumlariModel> AnasayfaMusteriYorumlariModel { get; set; }
    }
}
