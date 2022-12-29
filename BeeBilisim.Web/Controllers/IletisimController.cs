using BeeBilisim.Web.Models;
using BeeBilisim.Web.ViewModels;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace BeeBilisim.Web.Controllers
{
    [AllowAnonymous]
    public class IletisimController : Controller
    {
        private readonly BeeDbContext _dbContext;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;


        public IletisimController(BeeDbContext dbContext, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            IletisimViewModel vm = new IletisimViewModel();
            vm.IletisimModels = _dbContext.IletisimModels.ToList();
            vm.BizeUlasinModels = _dbContext.BizeUlasinModels.ToList();
            vm.EmailDatas = _dbContext.EmailDatas.ToList();
            return View(vm);
        }

        [HttpGet]
        public PartialViewResult YorumYap()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<PartialViewResult> YorumYap(EmailData emailData)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(emailData.From));
            email.To.Add(MailboxAddress.Parse(emailData.From));

            email.Subject = "Konu: " + emailData.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) 
            {Text = "Mesajı Gönderen: " +emailData.Ad + "<br> Mail Adresi: " +emailData.To +"<br> Telefon: "+emailData.Telefon+ "<br> Mesaj: " + emailData.Body };


            if (emailData.Body != null)
            {
                using var smtp = new SmtpClient();
                //smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(emailData.From, emailData.Password);
                smtp.Send(email);
                smtp.Disconnect(true);

                Response.Redirect("/Iletisim/Index", true);
               emailData.Aktif = true;
               emailData.Catalog = "";
               emailData.CreatedDate = DateTime.Now;
               emailData.DeletedDate = null;
               emailData.DeletedUser = "";
               emailData.Entegrasyon = "";
               emailData.FlagTipi = 0;
               emailData.Kilitli = false;
               emailData.LastupDate = null;
               emailData.LastupUser = "";
               emailData.Special1 = "";
               emailData.Special2 = "";
               emailData.Special3 = "";
               emailData.İptal = false;
                await _dbContext.EmailDatas.AddAsync(emailData);
                await _dbContext.SaveChangesAsync();
            }

            return PartialView(new EmailData());
        }
    }
}
