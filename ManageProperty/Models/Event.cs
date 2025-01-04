using System;
using System.Collections.Generic;

namespace ManageProperty.Models;

public partial class Event
{
    public int EventId { get; set; }

    public int ManagerId { get; set; }

    public int OwnerId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime ReportedAt { get; set; }
}
