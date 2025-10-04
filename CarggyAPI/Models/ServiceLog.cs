namespace CarggyAPI.Models
{
    public class ServiceLog
    {
        public int? ServiceLogId { get; set; }
        public string? ServiceName { get; set; }
        public string? ServiceType { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ServiceDate { get; set; }
        public string? ServicePrice { get; set; }
        public string? ServiceImageURL { get; set; }
        public int? VehicleId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
