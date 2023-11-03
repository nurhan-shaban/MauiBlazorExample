using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorExample.Model.WebModel
{
    internal class GlobalResponse<T>
    {
        public string message { get; set; }
        public T response { get; set; } = default;
    }
}
