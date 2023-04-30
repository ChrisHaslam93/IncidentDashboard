using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class SiteDto
    {
        [Required]
        [MaxLength(100)]
        public string Address1 { get; set; }
        [MaxLength(100)]
        public string? Address2 { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
    }
}