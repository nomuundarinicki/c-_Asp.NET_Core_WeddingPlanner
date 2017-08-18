using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models
{
    public class RegisterViewModel : BaseEntity
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Display(Name="Last Name")]
        public string LastName { get; set; }
 
        [Required]
        [EmailAddress]
        [Display(Name="Email Address")]
        public string Email { get; set; }
 
        [Required]
        [MinLength(8)]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
 
        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        [Display(Name="Confirm Password")]
        public string Confirm { get; set; }
    }
}