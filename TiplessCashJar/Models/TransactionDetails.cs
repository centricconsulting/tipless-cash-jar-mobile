using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiplessCashJar.Models
{
    class TransactionDetails
    {
        public int DonationAmount { get; set; }
        public DateTime DonationDate { get; set; }
        public string RecipientUID { get; set; }
        public ILocation Location { get; set; }
    }
}
