using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Wallet
{
    public string WalletId { get; set; } = null!;

    public DateOnly CreateDay { get; set; }

    public float Balance { get; set; }

    public string BankName { get; set; } = null!;

    public int BankNumber { get; set; }

    public string AccountId { get; set; } = null!;

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
