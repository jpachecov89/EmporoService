using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entity
{
    public class ItemVendor
    {
        [Key]
        public Guid ItemVendorId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
