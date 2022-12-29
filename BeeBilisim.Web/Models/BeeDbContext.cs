using Microsoft.EntityFrameworkCore;

namespace BeeBilisim.Web.Models
{
    public class BeeDbContext:DbContext
    {
        public BeeDbContext()
        {

        }
        public BeeDbContext(DbContextOptions<BeeDbContext> options) : base(options)
        {
        }

        public DbSet<Kullanicilars> Kullanicilars { get; set; }
        public DbSet<HakkimizdaSliderModel> HakkimizdaSliderModels { get; set; }
        public DbSet<AnasayfaModel> AnasayfaModels { get; set; }
        public DbSet<AnaSayfaSliderModel> AnaSayfaSliderModels { get; set; }
        public DbSet<AnasayfaMusteriYorumlariModel> AnasayfaMusteriYorumlariModels { get; set; }
        public DbSet<HakkimizdaModel> HakkimizdaModels { get; set; }
        public DbSet<IletisimModel> IletisimModels { get; set; }
        public DbSet<BizeUlasinModel> BizeUlasinModels { get; set; }
        public DbSet<ReferasanslarModel> ReferasanslarModels { get; set; }
        public DbSet<EmailData> EmailDatas { get; set; }
        public DbSet<ReCaptchaResult> ReCaptchaResults { get; set; }
    }
}
