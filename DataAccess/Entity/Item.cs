using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entity
{
    public class Item
    {
        [Key]
        public Guid ItemId { get; set; }
        public ItemVendor ItemVendor { get; set; }
        public Guid ItemVendorId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemNumber { get; set; }
        public string Upc { get; set; }
        public string ItemDescription { get; set; }
        public int MinimumOrderQuantity { get; set; }
        public string PurchaseUnitOfMeasure { get; set; }
        public double ItemCost { get; set; }
    }
}
