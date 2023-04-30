using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class DepartmentDto
    {
        [Required]
        [MaxLength(50)]
        public string DepartmentName { get; set; }
    }
}