using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProject.Models
{
    public class UserSignViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı  Giriniz")]
        public string userName { get; set; }

        [Required(ErrorMessage ="Lütfen Şifrenizi Giriniz")]
        public string password  { get; set; }
    }
}
