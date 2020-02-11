using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RobotStore.WebAPI.Models
{
    public class User : IdentityUser
    {
        //[Key]
        //public int Id { get; set; }
        //[Required]
        //public string Login { get; set; }
        //[Required]
        //public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
        //[Required]
        //public string Email { get; set; }
        [Required] 
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }
    }
}