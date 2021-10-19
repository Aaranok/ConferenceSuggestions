using System;
using System.Collections.Generic;

#nullable disable

namespace RatingSystem.Models
{
    public partial class BankAccount
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public string Iban { get; set; }
        public string Status { get; set; }
        public decimal? Limit { get; set; }
        public string Type { get; set; }

    }
}
