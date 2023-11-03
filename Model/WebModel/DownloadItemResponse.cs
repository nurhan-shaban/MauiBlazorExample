using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorExample.Model.WebModel
{
    internal class DownloadItemResponse
    {
        public long id { get; set; }
        public bool isDeleted { get; set; }
        public string name { get; set; }
        public int poscode { get; set; }
        public long unitId { get; set; }
        public long vatId { get; set; }
        public long itemGroupId { get; set; }
        public long standId { get; set; }
        public int displayOrder { get; set; }
        public string externalCode { get; set; }
        public bool isFavorite { get; set; }
        public bool isBundle { get; set; }
        public decimal sellPrice { get; set; }
        public long packUnitId { get; set; }
        public string picture { get; set; }
        public int statusId { get; set; }
        public int productTypeId { get; set; }
        public int itemTypeId { get; set; }
        public decimal quantity { get; set; } = 1;
    }
}
