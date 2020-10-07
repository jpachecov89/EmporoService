using System;

namespace BusinessLayer.Dtos
{
    public class HospitalDto
    {
        public Guid HospitalId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
