using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiplessCashJar.Models
{
    class CreditCard
    {
        public string NameAsAppearsOnCard { get; set; }
        public int CardNumber { get; set; }
        public string ExpDate { get; set; }
        public int CSVNumber { get; set; }
    }
}
