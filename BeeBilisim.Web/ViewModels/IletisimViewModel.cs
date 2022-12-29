using BeeBilisim.Web.Models;

namespace BeeBilisim.Web.ViewModels
{
    public class IletisimViewModel
    {
        public IEnumerable<IletisimModel> IletisimModels { get; set; }
        public IEnumerable<BizeUlasinModel> BizeUlasinModels { get; set; }
        public IEnumerable<EmailData> EmailDatas { get; set; }
    }
}
