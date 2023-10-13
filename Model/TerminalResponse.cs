using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorExample.Model
{
    internal class TerminalResponse
    {
        public long id { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public string store { get; set; }
        public string serialNumber { get; set; }
    }
}
