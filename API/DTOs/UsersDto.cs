using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class UsersDto
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public string RoleId { get; set; }
    }
}