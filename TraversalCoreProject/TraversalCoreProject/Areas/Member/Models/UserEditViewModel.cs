using Microsoft.AspNetCore.Http;

namespace TraversalCoreProject.Areas.Member.Models
{
    public class UserEditViewModel
    {
        public string name { get; set; }
        public string surName { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string phonenumber { get; set; }
        public string mail { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image {  get; set; } //Bir HTML formundan gelen dosyaları işlemek için kullanılır. 

    }
}
