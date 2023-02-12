using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeBilisim.Web.Models
{
    public class EmailData : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Bu alanın doldurulması zorunludur.")]
        public string? From { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]

        public string? To { get; set; }
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]

        public string? Subject { get; set; }
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]

        public string? Body { get; set; }

        public string Password { get; set; }
        public string Ad { get; set; }

        [StringLength(11)]
        public string Telefon { get; set; }
        public DateTime GonderilmeTarihi { get; set; } = DateTime.Now;

        [Required]
        public string Captcha { get; set; }
        public EmailData()
        {
            From = "tanyelyigit@gmail.com";
            Password = "my-password";
        }
    }
}


