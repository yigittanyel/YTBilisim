using System.ComponentModel.DataAnnotations;

namespace BeeBilisim.Web.Models
{
    public class Kullanicilars:BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(36)]
        public string Ad { get; set; }

        [StringLength(36)]
        public string Soyad { get; set; }

        [StringLength(72)]
        public string Email { get; set; }
        [StringLength(72)]
        public string Sifre { get; set; }
        [StringLength(72)]
        public string Sifre2 { get; set; }

        [StringLength(11)]
        public string Telefon { get; set; }

    }
}
