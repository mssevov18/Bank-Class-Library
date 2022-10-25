using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary.Models.Data
{
    public partial class Account
    {
        public Account()
        {
            Cards = new HashSet<Card>();
            TransactionAccountsConnectionRecievers = new HashSet<TransactionAccountsConnection>();
            TransactionAccountsConnectionSenders = new HashSet<TransactionAccountsConnection>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Iban { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Person Person { get; set; }
        public virtual CardReaderAccountConnection CardReaderAccountConnection { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<TransactionAccountsConnection> TransactionAccountsConnectionRecievers { get; set; }
        public virtual ICollection<TransactionAccountsConnection> TransactionAccountsConnectionSenders { get; set; }
    }
}
