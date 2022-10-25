using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary.Models.Data
{
    public partial class BankWorker
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public decimal Salary { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Person Person { get; set; }
    }
}
