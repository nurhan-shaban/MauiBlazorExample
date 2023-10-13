using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorExample.Model
{
    internal class ReceiptsRequest
    {
        public long storeId { get; set; }
        public long terminalId { get; set; }
        public int receiptTypeId { get; set; }
        public int receiptStatusId { get; set; }
        public int number { get; set; }
        public string zNumber { get; set; }
        public string fiscalReceiptDayNumber { get; set; }
        public string fiscalReceiptNumber { get; set; }
        public string memoryNumber { get; set; }
        public string deviceNumber { get; set; }
        public DateTime fiscalReceiptTimestamp { get; set; }
        public decimal total { get; set; }
        public decimal vatTotal { get; set; }
        public decimal totalDiscount { get; set; }
        public decimal totalSurcharge { get; set; }
        public int itemsCount { get; set; }
        public int originalReceiptId { get; set; }
        public List<Item> items { get; set; } = new();
        public List<Payment> payments { get; set; } = new();

        public class Item
        {
            public long ItemId { get; set; }
            public decimal Quantity { get; set; }
            public decimal Price { get; set; }
            public decimal GrossTotal { get; set; }
            public decimal NetTotal { get; set; }
            public long VatId { get; set; }
            public decimal VatSum { get; set; }
            public string SerialNumber { get; set; }
            public long BarcodeId { get; set; }
            public List<Modifier> modifiers { get; set; } = new();
        }

        public class Modifier
        {
            public int modifierId { get; set; }
            public decimal quantity { get; set; }
            public decimal price { get; set; }
            public decimal total { get; set; }
        }

        public class Payment
        {
            public long paymentId { get; set; }
            public decimal amount { get; set; }
        }
    }
}
