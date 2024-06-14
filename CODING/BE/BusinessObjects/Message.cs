using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Message
{
    public string MessageId { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateOnly Time { get; set; }

    public bool IsActive { get; set; }

    public string AccountId { get; set; } = null!;

    public string ConversationId { get; set; } = null!;

    public virtual Account Account { get; set; } = null!;

    public virtual Conversation Conversation { get; set; } = null!;
}
