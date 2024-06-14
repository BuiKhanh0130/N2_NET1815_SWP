using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Transaction
{
    public string TransactionId { get; set; } = null!;

    public DateOnly CreateDay { get; set; }

    public float TransactionMoney { get; set; }

    public string Description { get; set; } = null!;

    public bool Status { get; set; }

    public string WalletId { get; set; } = null!;

    public virtual Wallet Wallet { get; set; } = null!;
}
