using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage ="Kullanıcı Adını Griniz.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifrenizi Griniz.")]
        public string Password { get; set; }
    }
}
