using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary.Models.Data
{
    public partial class Person
    {
        public Person()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string Egn { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Residence { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }

        public virtual BankWorker BankWorker { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
