namespace API.Entities
{
    public class Incident
    {
        public int IncidentId { get; set; }
        public string IncidentGroupId { get; set; }
        public int SiteId { get; set; }
        public int DepartmentId { get; set; }
        public int ReporterId { get; set; }
        public float SeverityLevel { get; set; }
        public DateTime IncidentDatetime { get; set; } = DateTime.Now;
        public DateTime IncidentCreationDatetime { get; set; } = DateTime.Now;
        public DateTime? IncidentResolutionDatetime { get; set; }
    }
}