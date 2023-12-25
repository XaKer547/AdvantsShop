using System.ComponentModel.DataAnnotations;

namespace AdvantShop.Web.Models
{
    public class AuthorizationViewModel
    {
#nullable disable
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
