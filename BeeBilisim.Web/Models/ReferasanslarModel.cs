
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeBilisim.Web.Models
{
    public class ReferasanslarModel : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string ImageName { get; set; }
        public int Sira { get; set; }

        [Column(TypeName = "nvarchar(100)")]

        public string ReferansWebsite { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
