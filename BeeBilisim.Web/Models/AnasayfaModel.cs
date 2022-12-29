using System.ComponentModel.DataAnnotations;

namespace BeeBilisim.Web.Models
{
    public class AnasayfaModel : BaseEntity
    {
        public int Id { get; set; }
        public string Slogan { get; set; }
        public string  SloganAciklama{ get; set; }
        [StringLength(11)]
        public string  Telefon{ get; set; }

        [StringLength(72)]
        public string Fax { get; set; }
        [StringLength(72)]
        public string Email { get; set; }
        public string GovdeMetinBasligi { get; set; }
        public string GovdeMetinAciklama1 { get; set; }
        public string GovdeMetinAciklama2 { get; set; }
        public string NedenBizMetin { get; set; }
        public string NedenBizSol1 { get; set; }
        public string NedenBizSol2 { get; set; }
        public string NedenBizSol3 { get; set; }
        public string NedenBizSag1 { get; set; }
        public string NedenBizSag2 { get; set; }
        public string NedenBizSag3 { get; set; }
        public string NedenBizSag4 { get; set; }


    }
}
