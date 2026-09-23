using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Users
    {
        [Key]
        [Required]
        [DisplayName("Email Address")]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required]
        //[Range(9,15)]
        public int Phone { get; set; }
        [Required]
        //[Range(8,16, ErrorMessage ="Password must be between 8 and 16 characters")]
        public string Password { get; set; }
        [Required]
        [DisplayName("User Name")]
        [MaxLength(50)]
        public string Username { get; set; }
    }
}
