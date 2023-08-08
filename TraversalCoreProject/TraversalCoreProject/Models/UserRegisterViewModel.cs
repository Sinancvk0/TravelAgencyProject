using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProject.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen Adınızı Giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen SoyAdınızı Giriniz")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        public string Mail   { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Giriniz")]
        [Compare("Password",ErrorMessage ="Şifreler Uyumlu Değil")]
        public string ConfirmPassword { get; set; }
    }
}
