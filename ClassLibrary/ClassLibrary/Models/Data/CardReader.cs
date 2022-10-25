using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary.Models.Data
{
    public partial class CardReader
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public virtual CardReaderAccountConnection CardReaderAccountConnection { get; set; }
    }
}
