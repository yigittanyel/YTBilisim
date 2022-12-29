using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeBilisim.Web.Models
{
    public class BizeUlasinModel : BaseEntity
    {
        public int Id { get; set; }
        [StringLength(144)]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        public string Ad { get; set; }

        [StringLength(144)]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        public string Email { get; set; }

        [StringLength(11)]
        public string Telefon { get; set; }

        [StringLength(144)]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]

        public string Konu { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]

        public string Mesaj { get; set; }

        public DateTime GonderilmeTarihi { get; set; }= DateTime.Now;
    }
}
