using System;

namespace BusinessLayer.Dtos
{
    public class PharmacyDto
    {
        public Guid PharmacyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
