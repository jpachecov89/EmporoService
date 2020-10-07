using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using BusinessLayer.Managers;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmporoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyInventoryManager _iPharmacyInventoryManager;
        public PharmacyController(IPharmacyInventoryManager iPharmacyInventoryManager)
        {
            _iPharmacyInventoryManager = iPharmacyInventoryManager;
        }

        [HttpPost("CreatePharmacyInventory")]
        public async Task<ActionResult<PharmacyInventoryDto>> CreatePharmacyInventory(PharmacyInventoryDto pharmacyInventory)
        {
            try
            {
                return await _iPharmacyInventoryManager.Create(pharmacyInventory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdatePharmacyInventory")]
        public async Task<ActionResult<PharmacyInventoryDto>> UpdatePharmacyInventory(PharmacyInventoryDto pharmacyInventory)
        {
            try
            {
                return await _iPharmacyInventoryManager.Update(pharmacyInventory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("DeletePharmacyInventory/{id}")]
        public async Task<ActionResult<bool>> DeletePharmacyInventory(Guid id)
        {
            try
            {
                return await _iPharmacyInventoryManager.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
