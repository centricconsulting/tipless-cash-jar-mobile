using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TiplessCashJar.Models
{
    class Recipient : UserProfile
    {
        public DateTime DateOfBirth { get; set; }
        public Image RecipientPhoto { get; set; }
    }
}
