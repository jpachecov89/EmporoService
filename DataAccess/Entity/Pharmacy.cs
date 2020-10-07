using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entity
{
    public class Pharmacy
    {
        [Key]
        public Guid PharmacyId { get; set; }
        public Hospital Hospital { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
