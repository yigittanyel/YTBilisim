using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BeeBilisim.Web.Models
{
    [Keyless]
    public class ReCaptchaResult
    {
        [Required]
        public string Captcha { get; set; }
    }
}
