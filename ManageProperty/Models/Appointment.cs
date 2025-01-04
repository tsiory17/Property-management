using System;
using System.Collections.Generic;

namespace ManageProperty.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int ScheduleId { get; set; }

    public int TenantId { get; set; }

    public string Status { get; set; } = null!;
}
