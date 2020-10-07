using System;

namespace BusinessLayer.Dtos
{
    public class PharmacyInventoryDto
    {
        public Guid PharmacyInventoryId { get; set; }
        public Guid? PharmacyId { get; set; }
        public Guid? ItemId { get; set; }
        public int? ItemNumber { get; set; }
        public int? QuantityOnHand { get; set; }
        public double? UnitPrice { get; set; }
        public int? ReorderQuantity { get; set; }
        public string SellingUnitOfMeasure { get; set; }
    }
}
