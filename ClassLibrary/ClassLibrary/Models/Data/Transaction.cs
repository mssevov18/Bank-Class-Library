using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary.Models.Data
{
    public partial class Transaction
    {
        public Transaction()
        {
            TransactionAccountsConnections = new HashSet<TransactionAccountsConnection>();
        }

        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public string Reason { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<TransactionAccountsConnection> TransactionAccountsConnections { get; set; }
    }
}
