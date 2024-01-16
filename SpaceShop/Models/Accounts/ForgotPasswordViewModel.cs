using System.ComponentModel.DataAnnotations;

namespace SpaceShop.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email {  get; set; }

    }
}
