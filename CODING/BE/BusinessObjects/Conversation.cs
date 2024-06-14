using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Conversation
{
    public string ConversationId { get; set; } = null!;

    public DateOnly CreateDay { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<ConversationAccount> ConversationAccounts { get; set; } = new List<ConversationAccount>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
