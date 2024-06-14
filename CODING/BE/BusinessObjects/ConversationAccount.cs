using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects;

public partial class ConversationAccount
{
    public string ConversationId { get; set; } = null!;

    public string AccountId { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Conversation Conversation { get; set; } = null!;
}
