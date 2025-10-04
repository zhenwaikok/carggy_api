namespace CarggyAPI.Models
{
    public class Vehicle
    {
        public int? VehicleId { get; set; }
        public string? VehicleName { get; set; }
        public string? VehicleType { get; set; }
        public string? VehicleBrand { get; set; }
        public string? PlateNo { get; set; }
        public string? Year { get; set; }
        public string? VehicleImageURL { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
