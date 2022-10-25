using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary.Models.Data
{
    public partial class Card
    {
        public int Id { get; set; }
        public int HolderId { get; set; }
        public string Number { get; set; }
        public string Pin { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Account Holder { get; set; }
    }
}
