using System.ComponentModel.DataAnnotations;
using API.Entities;

namespace API.DTOs
{
    public class IncidentDto
    {
        [Required]
        public string IncidentGroupId { get; set; }
        [Required]
        public int SiteId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int ReporterId { get; set; }
        [Required]
        [Range(0, 10)]
        public float SeverityLevel { get; set; }
        public DateTime IncidentDatetime { get; set; } = DateTime.Now;
        public List<IncidentPhoto> IncidentPhotos { get; set; } = new ();
        public List<int> Incidentees { get; set; }
    }
}