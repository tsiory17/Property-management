using System;
using System.Collections.Generic;

namespace ManageProperty.Models;

public partial class Schedule
{
    public int ScheduleId { get; set; }
    public int ManagerId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Status { get; set; } = null!;
}
