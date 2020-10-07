using System;

namespace BusinessLayer.Dtos
{
    public class ItemDto
    {
        public Guid ItemId { get; set; }
        public Guid? ItemVendorId { get; set; }
        public int? ItemNumber { get; set; }
        public string Upc { get; set; }
        public string ItemDescription { get; set; }
        public int? MinimumOrderQuantity { get; set; }
        public string PurchaseUnitOfMeasure { get; set; }
        public double? ItemCost { get; set; }
    }
}
