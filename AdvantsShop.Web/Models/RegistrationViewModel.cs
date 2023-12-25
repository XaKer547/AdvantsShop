using System.ComponentModel.DataAnnotations;

namespace AdvantShop.Web.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [RegularExpression(@"\+7 \([0-9]{3}\) [0-9]{3}-[0-9]{2}-[0-9]{2}", ErrorMessage = "Введите номер телефона полностью")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [MinLength(6, ErrorMessage = "Минимальная длинна пароля 6 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Compare(nameof(Password), ErrorMessage = "Пароли должны совпадать")]
        public string RepeatPassword { get; set; }
    }
}
