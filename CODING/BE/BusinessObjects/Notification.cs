using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Notification
{
    public string NotificationId { get; set; } = null!;

    public DateOnly CreateDay { get; set; }

    public string Description { get; set; } = null!;

    public bool Status { get; set; }

    public bool IsActive { get; set; }

    public string AccountId { get; set; } = null!;

    public virtual Account Account { get; set; } = null!;
}
