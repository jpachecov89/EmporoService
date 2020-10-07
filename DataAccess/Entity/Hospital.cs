using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entity
{
    public class Hospital
    {
        [Key]
        public Guid HospitalId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
