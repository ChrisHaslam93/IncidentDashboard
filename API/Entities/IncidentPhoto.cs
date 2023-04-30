namespace API.Entities
{
    public class IncidentPhoto
    {
        public int PhotoId { get; set; }
        public int IncidentId { get; set; }
        public bool IsMain { get; set; }
        public string PhotoUrl { get; set; }
    }
}