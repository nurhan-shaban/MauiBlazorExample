using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorExample.Model
{
    internal class PaymentsResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public Paymenttype paymentType { get; set; }
        public bool isActive { get; set; }

        public class Paymenttype
        {
            public int id { get; set; }
            public string name { get; set; }
            public string nameEn { get; set; }
        }

    }
}
