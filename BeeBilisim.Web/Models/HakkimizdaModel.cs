using System.ComponentModel.DataAnnotations;

namespace BeeBilisim.Web.Models
{
    public class HakkimizdaModel : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string BizKimizMetin1 { get; set; }
        public string BizKimizMetin2 { get; set; }
        public string Vizyonumuz { get; set; }
        public string Misyonumuz { get; set; }
        public string Telefon { get; set; }
        public string KendimiziTanitalim1 { get; set; }
        public string KendimiziTanitalim2 { get; set; }
    }
}
