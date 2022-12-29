using System.ComponentModel.DataAnnotations;

namespace BeeBilisim.Web.Models
{
    public class AnasayfaMusteriYorumlariModel : BaseEntity
    {
        public int Id { get; set; }
        public string Yorum { get; set; }

        [StringLength(72)]
        public string MusteriAdi { get; set; }
        [StringLength(72)]
        public string MusteriTitle { get; set; }
    }
}
