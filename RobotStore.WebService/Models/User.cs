using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RobotStore.WebService.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Login")]
        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }
        [DisplayName("Password")]
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required] 
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }
    }
}