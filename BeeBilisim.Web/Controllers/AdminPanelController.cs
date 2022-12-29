using BeeBilisim.Web.Helpers;
using BeeBilisim.Web.Models;
using BeeBilisim.Web.Services;
using Hash;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MimeKit;
using Newtonsoft.Json;
using System.IO;
using System.Net.Mail;
using System.Security;
using System.Security.Claims;
using System.Web;
using System.Xml.Linq;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace BeeBilisim.Web.Controllers
{
    public class AdminPanelController : Controller
    {

        private readonly BeeDbContext _dbContext;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;
        public AdminPanelController(BeeDbContext dbContext, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {

            return View();
        }
        //KULLANICI İŞLEMLERİ
        #region Kisi Bilgileri(User)
        [HttpGet]
        public IActionResult KisiBilgileri()
        {
            var kullaniciAdi = HttpContext.User.Identity.Name;
            var kullanici = _dbContext.Kullanicilars.FirstOrDefault(q => q.Ad == kullaniciAdi);

            ViewBag.Kullanici = kullanici;

            var kisiler = _dbContext.Kullanicilars.Where(x=>x.Aktif==true).ToList();
            return View(kisiler);
        }

        public IActionResult KisiSil(int id)
        {
            var silinecekKisi = _dbContext.Kullanicilars.Where(x => x.Id == id).FirstOrDefault();
            var identity = (ClaimsIdentity)User.Identity;
            var role = identity.FindFirst(ClaimTypes.Email).Value;

            silinecekKisi.DeletedUser = role;
            silinecekKisi.Aktif = false;
            
            if(silinecekKisi.DeletedUser!=null|| silinecekKisi.DeletedUser != "")
            {
                silinecekKisi.DeletedDate = DateTime.Now;
            }

            _dbContext.SaveChanges();
            return RedirectToAction("KisiBilgileri");
        }

        public IActionResult KisiGetir(int id)
        {
            var d = _dbContext.Kullanicilars.Find(id);
            return View("KisiGetir", d);
        }

        [HttpPost]
        public IActionResult KisiGuncelle(Kullanicilars admin)
        {
            var x = _dbContext.Kullanicilars.FirstOrDefault(a => a.Id == admin.Id);
            x.Id = admin.Id;
            x.Ad = admin.Ad;
            x.Soyad = admin.Soyad;
            x.Email = admin.Email;
            x.LastupUser = admin.LastupUser;
           
            if(admin.LastupUser!=null || x.LastupUser != "")
            {
                x.LastupDate = DateTime.Now;
            }


            if(admin.Sifre==null || admin.Sifre2==null) {
                goto A;
            }
            x.Sifre = Sifreleme.sha1(admin.Sifre.Trim());
            x.Sifre2 = Sifreleme.sha1(admin.Sifre2.Trim());

            if (x.Sifre != x.Sifre2)
            {
                ViewBag.hata = "Şifreler uyuşmuyor. Lütfen tekrar deneyin!";
                return View("KisiGetir", admin);
            }
            A:
            x.Telefon = admin.Telefon;
            _dbContext.SaveChanges();
            return RedirectToAction("KisiBilgileri");
        }

        [HttpGet]
        public IActionResult YeniKisiEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniKisiEkle(Kullanicilars admin)
        {
            admin.Sifre= Sifreleme.sha1(admin.Sifre.Trim());
            admin.Sifre2= Sifreleme.sha1(admin.Sifre2.Trim());

            if (admin.Sifre != admin.Sifre2)
            {
                ViewBag.hata = "Şifreler uyuşmuyor. Lütfen tekrar giriniz.";
                return View();
            }


            admin.Aktif = true;
            admin.Catalog = "";
            admin.CreatedDate = DateTime.Now;
            admin.DeletedDate = null;
            admin.DeletedUser = "";
            admin.Entegrasyon = "";
            admin.FlagTipi = 0;
            admin.Kilitli = false;
            admin.LastupDate = null;
            admin.LastupUser = "";
            admin.Special1 = "";
            admin.Special2 = "";
            admin.Special3 = "";
            admin.İptal = false;

            _dbContext.Kullanicilars.Add(admin);
            _dbContext.SaveChanges();
            return RedirectToAction("KisiBilgileri");
        }
        #endregion

        //ANA SAYFA
        #region Slider Bilgileri
        public IActionResult SliderListesi()
        {
            var sliderlar = _dbContext.AnaSayfaSliderModels.OrderBy(x => x.Sira).ToList();
            return View(sliderlar);
        }

        [HttpGet]
        public IActionResult YeniSliderEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniSliderEkle(AnaSayfaSliderModel slider)
        {
            _dbContext.AnaSayfaSliderModels.Add(slider);
            _dbContext.SaveChanges();
            return RedirectToAction("SliderListesi");

            //string fileName = Guid.NewGuid().ToString();
            //if (Getfile != null)
            //{
            //    var Upload = Path.Combine(_environment.WebRootPath, "Dosya Yolu", fileName);
            //    Getfile.CopyTo(new FileStream(Upload, FileMode.Create));

            //}
            //_dbContext.AnaSayfaSliderModels.Add(Getfile;
            //_dbContext.SaveChanges();
            //return RedirectToAction("SliderListesi");

        }
        public IActionResult SliderSil(int id)
        {
            var silinecekSlider = _dbContext.AnaSayfaSliderModels.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.AnaSayfaSliderModels.Remove(silinecekSlider);
            _dbContext.SaveChanges();

            return RedirectToAction("SliderListesi");
        }

        //ID'YE GÖRE KİŞİ GETİRME
        public IActionResult SliderGetir(int id)
        {
            var d = _dbContext.AnaSayfaSliderModels.Find(id);
            return View("SliderGetir", d);
        }

        [HttpPost]
        public IActionResult SliderGuncelle(AnaSayfaSliderModel slider)
        {
            var x = _dbContext.AnaSayfaSliderModels.FirstOrDefault(a => a.Id == slider.Id);
            x.Id = slider.Id;
            x.FotoUrl = slider.FotoUrl;
            x.Sira = slider.Sira;

            _dbContext.SaveChanges();
            return RedirectToAction("SliderListesi");
        }
        #endregion

        #region Referans Bilgileri
        public IActionResult ReferansListesi()
        {
            var referanslar = _dbContext.ReferasanslarModels.OrderBy(x => x.Sira).Where(x=>x.Aktif==true).ToList();
            return View(referanslar);
        }
        public async Task<IActionResult> ReferansSil(int id)
        {
            var silinecekReferans = await _dbContext.ReferasanslarModels.FindAsync(id);
            var identity = (ClaimsIdentity)User.Identity;
            var role = identity.FindFirst(ClaimTypes.Email).Value;

            var imagePath = Path.Combine(hostingEnvironment.WebRootPath, "images", silinecekReferans.ImageName);
            if (System.IO.File.Exists(imagePath)) 
                System.IO.File.Delete(imagePath);

            silinecekReferans.DeletedUser = role;
            silinecekReferans.Aktif = false;
            if (silinecekReferans.DeletedUser != null || silinecekReferans.DeletedUser != "")
            {
                silinecekReferans.DeletedDate = DateTime.Now;
            }

            await _dbContext.SaveChangesAsync();
            return RedirectToAction("ReferansListesi");
        }

        public IActionResult ReferansEkle()
        {
            var deger = _dbContext.ReferasanslarModels.Select(x => x.Sira).DefaultIfEmpty().Max();
            ViewBag.SonSira = deger + 1;
            return View(new ReferasanslarModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReferansEkle(ReferasanslarModel model)
        {
            var deger = _dbContext.ReferasanslarModels.Select(x => x.Sira).DefaultIfEmpty().Max();
            ViewBag.SonSira = deger + 1;
            model.Aktif = true;
            model.Catalog = "";
            model.CreatedDate = DateTime.Now;
            model.DeletedDate = null;
            model.DeletedUser = "";
            model.Entegrasyon = "";
            model.FlagTipi = 0;
            model.Kilitli = false;
            model.LastupDate = null;
            model.LastupUser = "";
            model.Special1 = "";
            model.Special2 = "";
            model.Special3 = "";
            model.İptal = false;
            if (ModelState.IsValid)
            {
                //Save image to wwroot/image
                string wwwRootPath = hostingEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                model.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                using(var fileStream=new FileStream(path, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);
                }
                //Insert to database
                _dbContext.Add(model);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("ReferansListesi");
            }
            return View();
        }

        public async Task<IActionResult> ReferanslariGetir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var deger = await _dbContext.ReferasanslarModels.FirstOrDefaultAsync(x => x.Id == id);
            if (deger == null)
            {
                return NotFound();
            }
            return View(deger);
        }

        [HttpPost]
        public async Task<IActionResult> ReferanslariGuncelle(ReferasanslarModel model)
        {
            var deger = await _dbContext.ReferasanslarModels.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            deger.Id = model.Id;
            deger.ReferansWebsite = model.ReferansWebsite;
            deger.Sira = model.Sira;

            deger.LastupUser = model.LastupUser;

            if (model.LastupUser != null || model.LastupUser != "")
            {
                deger.LastupDate = DateTime.Now;
            }

            if (String.IsNullOrEmpty(model.ImageName))
            {
                if (ModelState.IsValid)
                {
                    if (model.ImageFile == null)
                    {
                        goto A;
                    }

                    //Save image to wwroot/image
                    string wwwRootPath = hostingEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string extension = Path.GetExtension(model.ImageFile.FileName);
                    model.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(fileStream);
                    }
                  
                    deger.ImageName = model.ImageName;
                }
            }

        A:
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("ReferansListesi");
        }
        #endregion

        #region Slogan
        public PartialViewResult SloganGoruntulePartial()
        {
            var deger = _dbContext.AnasayfaModels.ToList();
            return PartialView(deger);
        }

        public IActionResult SloganGetir(int id)
        {
            var d = _dbContext.AnasayfaModels.Find(id);
            return View("SloganGetir", d);
        }

        [HttpPost]
        public IActionResult SloganGuncelle(AnasayfaModel deger)
        {
            var x = _dbContext.AnasayfaModels.FirstOrDefault(a => a.Id == deger.Id);
            x.Id = deger.Id;
            x.Slogan = deger.Slogan;
            x.SloganAciklama = deger.SloganAciklama;
            x.LastupUser = deger.LastupUser;
            
            if (deger.LastupUser != null || x.LastupUser != "")
            {
                x.LastupDate = DateTime.Now;
            }
            _dbContext.SaveChanges();
            return RedirectToAction("GenelDuzenleme");
        }
        #endregion

        #region Telefon-Fax-Email
        public PartialViewResult TelefonFaxEmailGoruntule()
        {
            var deger = _dbContext.AnasayfaModels.ToList();
            return PartialView(deger);
        }

        public IActionResult TelefonFaxEmailGetir(int id)
        {
            var d = _dbContext.AnasayfaModels.Find(id);
            return View("TelefonFaxEmailGetir", d);
        }

        [HttpPost]
        public IActionResult TelefonFaxEmailGuncelle(AnasayfaModel deger)
        {
            var x = _dbContext.AnasayfaModels.FirstOrDefault(a => a.Id == deger.Id);
            x.Id = deger.Id;
            x.Telefon = deger.Telefon;
            x.Fax = deger.Fax;
            x.Email = deger.Email;
            x.LastupUser = deger.LastupUser;

            if (deger.LastupUser != null || x.LastupUser != "")
            {
                x.LastupDate = DateTime.Now;
            }

            _dbContext.SaveChanges();
            return RedirectToAction("GenelDuzenleme");
        }
        #endregion

        #region Gövde Metni Düzenle
        public PartialViewResult GovdeMetniGoruntule()
        {
            var deger = _dbContext.AnasayfaModels.ToList();
            return PartialView(deger);
        }

        public IActionResult GovdeMetniGetir(int id)
        {
            var d = _dbContext.AnasayfaModels.Find(id);
            return View("GovdeMetniGetir", d);
        }

        [HttpPost]
        public IActionResult GovdeMetniGuncelle(AnasayfaModel deger)
        {
            var x = _dbContext.AnasayfaModels.FirstOrDefault(a => a.Id == deger.Id);
            x.Id = deger.Id;
            x.GovdeMetinBasligi = deger.GovdeMetinBasligi;
            x.GovdeMetinAciklama1 = deger.GovdeMetinAciklama1;
            x.GovdeMetinAciklama2 = deger.GovdeMetinAciklama2;
            x.LastupUser = deger.LastupUser;

            if (deger.LastupUser != null || x.LastupUser != "")
            {
                x.LastupDate = DateTime.Now;
            }

            _dbContext.SaveChanges();
            return RedirectToAction("GenelDuzenleme");
        }
        #endregion

        #region Neden Biz
        public PartialViewResult NedenBizGoruntule()
        {
            var deger = _dbContext.AnasayfaModels.ToList();
            return PartialView(deger);
        }

        public IActionResult NedenBizGetir(int id)
        {
            var d = _dbContext.AnasayfaModels.Find(id);
            return View("NedenBizGetir", d);
        }

        [HttpPost]
        public IActionResult NedenBizGuncelle(AnasayfaModel deger)
        {
            var x = _dbContext.AnasayfaModels.FirstOrDefault(a => a.Id == deger.Id);
            x.Id = deger.Id;
            x.NedenBizMetin = deger.NedenBizMetin;
            x.NedenBizSol1 = deger.NedenBizSol1;
            x.NedenBizSol2 = deger.NedenBizSol2;
            x.NedenBizSol3 = deger.NedenBizSol3;
            x.NedenBizSag1 = deger.NedenBizSag1;
            x.NedenBizSag2 = deger.NedenBizSag2;
            x.NedenBizSag3 = deger.NedenBizSag3;
            x.NedenBizSag4 = deger.NedenBizSag4;
            x.LastupUser = deger.LastupUser;

            if (deger.LastupUser != null || x.LastupUser != "")
            {
                x.LastupDate = DateTime.Now;
            }
            _dbContext.SaveChanges();
            return RedirectToAction("GenelDuzenleme");
        }
        #endregion

        #region  Genel Düzenlemeler
        public IActionResult GenelDuzenleme() //ANASAYFA
        {
            var deger = _dbContext.AnasayfaModels.ToList();
            return View(deger);
        }

        public IActionResult HakkimizdaGenelDuzenleme() //HAKKIMIZDA
        {
            var deger = _dbContext.HakkimizdaModels.ToList();
            return View(deger);
        }

        public IActionResult IletisimGenelDuzenleme() //ILETİSİM
        {
            var deger = _dbContext.IletisimModels.ToList();
            return View(deger);
        }
        #endregion

        #region Müşteri Yorumları
        public IActionResult GelenYorumlarListesi()
        {
            var yorumlar = _dbContext.AnasayfaMusteriYorumlariModels.Where(x=>x.Aktif==true).ToList();
            return View(yorumlar);
        }

        [HttpGet]
        public IActionResult YeniYorumEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniYorumEkle(AnasayfaMusteriYorumlariModel yorumlar)
        {
            yorumlar.Aktif = true;
            yorumlar.Catalog = "";
            yorumlar.CreatedDate = DateTime.Now;
            yorumlar.DeletedDate = null;
            yorumlar.DeletedUser = "";
            yorumlar.Entegrasyon = "";
            yorumlar.FlagTipi = 0;
            yorumlar.Kilitli = false;
            yorumlar.LastupDate = null;
            yorumlar.LastupUser = "";
            yorumlar.Special1 = "";
            yorumlar.Special2 = "";
            yorumlar.Special3 = "";
            yorumlar.İptal = false;

            _dbContext.AnasayfaMusteriYorumlariModels.Add(yorumlar);
            _dbContext.SaveChanges();
            return RedirectToAction("GelenYorumlarListesi");
        }
        public IActionResult YorumSil(int id)
        {
            var silinecekYorum = _dbContext.AnasayfaMusteriYorumlariModels.Where(x => x.Id == id).FirstOrDefault();

            var identity = (ClaimsIdentity)User.Identity;
            var role = identity.FindFirst(ClaimTypes.Email).Value;

            silinecekYorum.DeletedUser = role;
            silinecekYorum.Aktif = false;

            if (silinecekYorum.DeletedUser != null || silinecekYorum.DeletedUser != "")
            {
                silinecekYorum.DeletedDate = DateTime.Now;
            }
            _dbContext.SaveChanges();

            return RedirectToAction("GelenYorumlarListesi");
        }

        public IActionResult YorumGetir(int id)
        {
            var d = _dbContext.AnasayfaMusteriYorumlariModels.Find(id);
            return View("YorumGetir", d);
        }

        [HttpPost]
        public IActionResult YorumGuncelle(AnasayfaMusteriYorumlariModel yorumlar)
        {
            var x = _dbContext.AnasayfaMusteriYorumlariModels.FirstOrDefault(a => a.Id == yorumlar.Id);
            x.Id = yorumlar.Id;
            x.Yorum = yorumlar.Yorum;
            x.MusteriAdi = yorumlar.MusteriAdi;
            x.MusteriTitle = yorumlar.MusteriTitle;
            x.LastupUser = yorumlar.LastupUser;
            if (yorumlar.LastupUser != null || x.LastupUser != "")
            {
                x.LastupDate = DateTime.Now;
            }

            _dbContext.SaveChanges();
            return RedirectToAction("GelenYorumlarListesi");
        }
        #endregion

        //HAKKIMIZDA
        #region Hakkımızda Biz Kimiz 
        public PartialViewResult BizKimizPartial()
        {
            var deger = _dbContext.HakkimizdaModels.ToList();
            return PartialView(deger);
        }

        public IActionResult BizKimizGetir(int id)
        {
            var d = _dbContext.HakkimizdaModels.Find(id);
            return View("BizKimizGetir", d);
        }

        [HttpPost]
        public IActionResult BizKimizGuncelle(HakkimizdaModel deger)
        {
            var x = _dbContext.HakkimizdaModels.FirstOrDefault(a => a.Id == deger.Id);
            x.Id = deger.Id;
            x.BizKimizMetin1 = deger.BizKimizMetin1;
            x.BizKimizMetin2 = deger.BizKimizMetin2;
            x.LastupUser = deger.LastupUser;

            if (deger.LastupUser != null || x.LastupUser != "")
            {
                x.LastupDate = DateTime.Now;
            }
            _dbContext.SaveChanges();
            return RedirectToAction("HakkimizdaGenelDuzenleme");
        }
        #endregion

        #region Hakkımızda Vizyonumuz 
        public PartialViewResult VizyonumuzPartial()
        {
            var deger = _dbContext.HakkimizdaModels.ToList();
            return PartialView(deger);
        }

        public IActionResult VizyonumuzGetir(int id)
        {
            var d = _dbContext.HakkimizdaModels.Find(id);
            return View("VizyonumuzGetir", d);
        }

        [HttpPost]
        public IActionResult VizyonumuzGuncelle(HakkimizdaModel deger)
        {
            var x = _dbContext.HakkimizdaModels.FirstOrDefault(a => a.Id == deger.Id);
            x.Id = deger.Id;
            x.Vizyonumuz = deger.Vizyonumuz;

            x.LastupUser = deger.LastupUser;

            if (deger.LastupUser != null || x.LastupUser != "")
            {
                x.LastupDate = DateTime.Now;
            }

            _dbContext.SaveChanges();
            return RedirectToAction("HakkimizdaGenelDuzenleme");
        }
        #endregion

        #region Hakkımızda Misyonumuz 
        public PartialViewResult MisyonumuzPartial()
        {
            var deger = _dbContext.HakkimizdaModels.ToList();
            return PartialView(deger);
        }

        public IActionResult MisyonumuzGetir(int id)
        {
            var d = _dbContext.HakkimizdaModels.Find(id);
            return View("MisyonumuzGetir", d);
        }

        [HttpPost]
        public IActionResult MisyonumuzGuncelle(HakkimizdaModel deger)
        {
            var x = _dbContext.HakkimizdaModels.FirstOrDefault(a => a.Id == deger.Id);
            x.Id = deger.Id;
            x.Misyonumuz = deger.Misyonumuz;

            x.LastupUser = deger.LastupUser;

            if (deger.LastupUser != null || x.LastupUser != "")
            {
                x.LastupDate = DateTime.Now;
            }

            _dbContext.SaveChanges();
            return RedirectToAction("HakkimizdaGenelDuzenleme");
        }
        #endregion

        #region Hakkımızda Telefon 
        public PartialViewResult TelefonPartial()
        {
            var deger = _dbContext.HakkimizdaModels.ToList();
            return PartialView(deger);
        }

        public IActionResult TelefonGetir(int id)
        {
            var d = _dbContext.HakkimizdaModels.Find(id);
            return View("TelefonGetir", d);
        }

        [HttpPost]
        public IActionResult TelefonGuncelle(HakkimizdaModel deger)
        {
            var x = _dbContext.HakkimizdaModels.FirstOrDefault(a => a.Id == deger.Id);
            x.Id = deger.Id;
            x.Telefon = deger.Telefon;

            x.LastupUser = deger.LastupUser;

            if (deger.LastupUser != null || x.LastupUser != "")
            {
                x.LastupDate = DateTime.Now;
            }
            _dbContext.SaveChanges();
            return RedirectToAction("HakkimizdaGenelDuzenleme");
        }
        #endregion

        #region Hakkımızda Kendimizi Tanitalim 
        public PartialViewResult KendimiziTanitalimPartial()
        {
            var deger = _dbContext.HakkimizdaModels.ToList();
            return PartialView(deger);
        }

        public IActionResult KendimiziTanitalimGetir(int id)
        {
            var d = _dbContext.HakkimizdaModels.Find(id);
            return View("KendimiziTanitalimGetir", d);
        }

        [HttpPost]
        public IActionResult KendimiziTanitalimGuncelle(HakkimizdaModel deger)
        {
            var x = _dbContext.HakkimizdaModels.FirstOrDefault(a => a.Id == deger.Id);
            x.Id = deger.Id;
            x.KendimiziTanitalim1 = deger.KendimiziTanitalim1;
            x.KendimiziTanitalim2 = deger.KendimiziTanitalim2;
            x.LastupUser = deger.LastupUser;

            if (deger.LastupUser != null || x.LastupUser != "")
            {
                x.LastupDate = DateTime.Now;
            }
            _dbContext.SaveChanges();
            return RedirectToAction("HakkimizdaGenelDuzenleme");
        }
        #endregion

        //İLETİŞİM
        #region İletişim Biz Kimiz 
        public PartialViewResult IletisimPartial()
        {
            var deger = _dbContext.IletisimModels.ToList();
            return PartialView(deger);
        }

        public IActionResult IletisimGetir(int id)
        {
            var d = _dbContext.IletisimModels.Find(id);
            return View("IletisimGetir", d);
        }

        [HttpPost]
        public IActionResult IletisimGuncelle(IletisimModel deger)
        {
            var x = _dbContext.IletisimModels.FirstOrDefault(a => a.Id == deger.Id);
            x.Id = deger.Id;
            x.AdresMetin = deger.AdresMetin;
            x.AdresIFrame = deger.AdresIFrame;
            x.Email = deger.Email;
            x.Fax = deger.Fax;
            x.Telefon = deger.Telefon;
            x.LastupUser = deger.LastupUser;

            if (deger.LastupUser != null || x.LastupUser != "")
            {
                x.LastupDate = DateTime.Now;
            }
            _dbContext.SaveChanges();
            return RedirectToAction("IletisimGenelDuzenleme");
        }
        #endregion

        #region Iletisim Gelen Mesajlar
        
        public IActionResult GelenMesajlar()
        {
            var mesajlar = _dbContext.EmailDatas.OrderByDescending(x=>x.GonderilmeTarihi).Where(x=>x.Aktif==true).ToList();
            return View(mesajlar);
        }
        
        public IActionResult GelenMesajSil(int id)
        {
            var silinecekMesaj = _dbContext.EmailDatas.Where(x => x.Id == id).FirstOrDefault();
            var identity = (ClaimsIdentity)User.Identity;
            var role = identity.FindFirst(ClaimTypes.Email).Value;

            silinecekMesaj.DeletedUser = role;
            silinecekMesaj.Aktif = false;

            if (silinecekMesaj.DeletedUser != null || silinecekMesaj.DeletedUser != "")
            {
                silinecekMesaj.DeletedDate = DateTime.Now;
            }
            _dbContext.SaveChanges();

            return RedirectToAction("GelenMesajlar");
        }

        public IActionResult MesajDetayi(int id)
        {
            var d = _dbContext.EmailDatas.Find(id);
           
            return View("MesajDetayi", d);
        }

        #endregion

        //EMAIL GONDERME
        #region Mail Gönderme

        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailData emailData)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(emailData.From));
            email.To.Add(MailboxAddress.Parse(emailData.To));
            email.Subject = emailData.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailData.Body };

            using var smtp = new SmtpClient();
            //smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(emailData.From, emailData.Password);
            smtp.Send(email);
            smtp.Disconnect(true);

            return RedirectToAction("SentEmail");
        }

        public IActionResult SentEmail()
        {
            ViewData["Success"] = "Email başarıyla gönderildi.";
            return View();
        }

        #endregion
    }
}
