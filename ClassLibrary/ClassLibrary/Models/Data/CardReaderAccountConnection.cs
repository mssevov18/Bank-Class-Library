using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary.Models.Data
{
    public partial class CardReaderAccountConnection
    {
        public int Id { get; set; }
        public int CardReaderId { get; set; }
        public int RecieverId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual CardReader CardReader { get; set; }
        public virtual Account Reciever { get; set; }
    }
}
