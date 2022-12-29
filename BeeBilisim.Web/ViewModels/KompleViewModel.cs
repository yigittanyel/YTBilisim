using BeeBilisim.Web.Models;

namespace BeeBilisim.Web.ViewModels
{
    public class KompleViewModel
    {
        public IEnumerable<IletisimModel> IletisimModels { get; set; }
        public IEnumerable<BizeUlasinModel> BizeUlasinModels { get; set; }
    }
}
