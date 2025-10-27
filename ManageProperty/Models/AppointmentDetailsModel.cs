namespace ManageProperty.Models
{
    public class AppointmentDetailsModel
    {
        public int AppointmentId { get; set; }

        public String? TenantName { get; set; }
        public int ScheduleId { get; set; }
        public int TenantId { get; set; }
        public string? Status { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }

}
