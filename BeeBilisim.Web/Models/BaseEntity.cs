using System.ComponentModel.DataAnnotations;

namespace BeeBilisim.Web.Models
{
    public abstract class BaseEntity : IBaseEntity
    {
        [StringLength(36)]
        public virtual string? CreateUser { get; set; }
        [StringLength(36)]
        public virtual string? LastupUser { get; set; }
        [StringLength(36)]
        public virtual string? DeletedUser { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? LastupDate { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
        public virtual bool? Aktif { get; set; }
        public virtual bool? Kilitli { get; set; }
        public virtual bool? İptal { get; set; }
        [StringLength(72)]
        public virtual string? Special1 { get; set; }
        [StringLength(72)]
        public virtual string? Special2 { get; set; }
        [StringLength(72)]
        public virtual string? Special3 { get; set; }
        [StringLength(36)]
        public virtual string? Catalog { get; set; }
        [StringLength(36)]
        public virtual string? Entegrasyon { get; set; }
        public virtual int FlagTipi { get; set; }
    }
}
