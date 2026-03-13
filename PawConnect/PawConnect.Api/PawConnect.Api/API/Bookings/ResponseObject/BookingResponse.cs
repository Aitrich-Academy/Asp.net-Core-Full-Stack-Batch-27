namespace PawConnect.Api.API.Bookings.ResponseObject
{
    public class BookingResponse
    {
        public Guid Id { get; set; }
        public int ServiceId { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; } = string.Empty;

        // service details
        public string? ServiceName { get; set; }
        public decimal? Price { get; set; }
    }
}
