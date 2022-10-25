using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary.Models.Data
{
    public partial class TransactionAccountsConnection
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Account Reciever { get; set; }
        public virtual Account Sender { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
