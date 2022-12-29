using System.ComponentModel.DataAnnotations;

namespace BeeBilisim.Web.Models
{
    public class IletisimModel : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string AdresMetin { get; set; }
        public string AdresIFrame { get; set; }
        [StringLength(11)]
        public string Telefon { get; set; }
        [StringLength(144)]
        public string Fax { get; set; }
        [StringLength(144)]
        public string Email { get; set; }
    }
}
