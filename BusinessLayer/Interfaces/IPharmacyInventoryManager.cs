using BusinessLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IPharmacyInventoryManager
    {
        Task<ActionResult<PharmacyInventoryDto>> Create(PharmacyInventoryDto pharmacyInventory);
        Task<ActionResult<PharmacyInventoryDto>> Update(PharmacyInventoryDto pharmacyInventory);
        Task<ActionResult<bool>> Delete(Guid id);
    }
}
