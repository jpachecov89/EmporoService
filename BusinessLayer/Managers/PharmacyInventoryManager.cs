using AutoMapper;
using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using DataAccess;
using DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers
{
    public class PharmacyInventoryManager : IPharmacyInventoryManager
    {
        private readonly EmporoContext _context;
        private readonly IMapper _mapper;
        public PharmacyInventoryManager(EmporoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<PharmacyInventoryDto>> Create(PharmacyInventoryDto pharmacyInventory)
        {
            try
            {
                bool itemExists = await _context.Item.AnyAsync(x => x.ItemId == pharmacyInventory.ItemId);
                if (!itemExists)
                {
                    return new NotFoundObjectResult("ItemId doesn't exist");
                }

                bool pharmacyExists = await _context.Pharmacy.AnyAsync(x => x.PharmacyId == pharmacyInventory.PharmacyId);
                if (!pharmacyExists)
                {
                    return new NotFoundObjectResult("PharmacyId doesn't exist");
                }

                if (!pharmacyInventory.QuantityOnHand.HasValue)
                {
                    return new NotFoundObjectResult("QuantityOnHand needs a value");
                }
                else
                {
                    if (pharmacyInventory.QuantityOnHand.Value <= 0)
                    {
                        return new NotFoundObjectResult("QuantityOnHand must be non-zero value");
                    }
                }

                int itemNumber = (await _context.Item.FirstOrDefaultAsync(x => x.ItemId == pharmacyInventory.ItemId)).ItemNumber;

                PharmacyInventory newPharmacyInventory = _mapper.Map<PharmacyInventory>(pharmacyInventory);
                newPharmacyInventory.PharmacyInventoryId = Guid.NewGuid();
                newPharmacyInventory.ItemNumber = itemNumber;
                await _context.PharmacyInventory.AddAsync(newPharmacyInventory);
                await _context.SaveChangesAsync();
                return _mapper.Map<PharmacyInventoryDto>(newPharmacyInventory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult<PharmacyInventoryDto>> Update(PharmacyInventoryDto pharmacyInventory)
        {
            try
            {
                bool exists = await _context.PharmacyInventory.AnyAsync(x => x.PharmacyInventoryId == pharmacyInventory.PharmacyInventoryId);
                if (!exists)
                {
                    return new NotFoundObjectResult("Id doesn't exist");
                }

                bool itemExists = await _context.Item.AnyAsync(x => x.ItemId == pharmacyInventory.ItemId);
                if (!itemExists)
                {
                    return new NotFoundObjectResult("ItemId doesn't exist");
                }

                bool pharmacyExists = await _context.Pharmacy.AnyAsync(x => x.PharmacyId == pharmacyInventory.PharmacyId);
                if (!pharmacyExists)
                {
                    return new NotFoundObjectResult("PharmacyId doesn't exist");
                }

                if (!pharmacyInventory.QuantityOnHand.HasValue)
                {
                    return new NotFoundObjectResult("QuantityOnHand needs a value");
                }
                else
                {
                    if (pharmacyInventory.QuantityOnHand.Value <= 0)
                    {
                        return new NotFoundObjectResult("QuantityOnHand must be non-zero value");
                    }
                }

                PharmacyInventory updatePharmacyInventory = _mapper.Map<PharmacyInventory>(pharmacyInventory);
                updatePharmacyInventory.ItemNumber = (await _context.Item.FirstOrDefaultAsync(x => x.ItemId == pharmacyInventory.ItemId)).ItemNumber;
                _context.Entry(updatePharmacyInventory).State = EntityState.Modified;
                _context.PharmacyInventory.Update(updatePharmacyInventory).Property(x => x.ItemNumber).IsModified = false;
                await _context.SaveChangesAsync();
                return _mapper.Map<PharmacyInventoryDto>(updatePharmacyInventory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            try
            {
                bool exists = await _context.PharmacyInventory.AnyAsync(x => x.PharmacyInventoryId == id);
                if (!exists)
                {
                    return new NotFoundObjectResult("Id doesn't exist");
                }

                PharmacyInventory pharmacyInventory = await _context.PharmacyInventory.FirstOrDefaultAsync(x => x.PharmacyInventoryId == id);
                _context.PharmacyInventory.Remove(pharmacyInventory);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
