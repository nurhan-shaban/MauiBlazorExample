using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorExample.Model.WebModel
{
    internal class VatResponse
    {
        public long id { get; set; }
        public string name { get; set; }
        public decimal value { get; set; }
    }
}
