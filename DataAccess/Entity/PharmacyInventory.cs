using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entity
{
    public class PharmacyInventory
    {
        [Key]
        public Guid PharmacyInventoryId { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public Guid PharmacyId { get; set; }
        public Item Item { get; set; }
        public Guid ItemId { get; set; }
        public int ItemNumber { get; set; }
        public int QuantityOnHand { get; set; }
        public double UnitPrice { get; set; }
        public int ReorderQuantity { get; set; }
        public string SellingUnitOfMeasure { get; set; }
    }
}
