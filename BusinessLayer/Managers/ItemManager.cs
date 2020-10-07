using AutoMapper;
using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using DataAccess;
using DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BusinessLayer.Managers
{
    public class ItemManager : IItemManager
    {
        private readonly EmporoContext _context;
        private readonly IMapper _mapper;
        public ItemManager(EmporoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAllItems()
        {
            try
            {
                List<ItemDto> itemDtos = new List<ItemDto>();
                List<Item> items = await _context.Item.ToListAsync();
                foreach (Item item in items)
                {
                    ItemDto itemDto = _mapper.Map<ItemDto>(item);
                    itemDtos.Add(itemDto);
                }
                return itemDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult<ItemDto>> GetItem(Guid id)
        {
            try
            {
                Item item = await _context.Item.FirstOrDefaultAsync(x => x.ItemId == id);
                if (item == null)
                {
                    return new NotFoundObjectResult("Id doesn't exist");
                }

                return _mapper.Map<ItemDto>(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult<ItemDto>> Create(ItemDto item)
        {
            try
            {
                if (string.IsNullOrEmpty(item.Upc))
                {
                    return new NotFoundObjectResult("UPC must have a value");
                }
                else
                {
                    if (item.Upc.Length != 12)
                    {
                        return new NotFoundObjectResult("UPC must have 12 digits");
                    }
                    else
                    {
                        long isNumeric;
                        if (!long.TryParse(item.Upc, out isNumeric))
                        {
                            return new NotFoundObjectResult("UPC must contain only numbers");
                        }
                    }
                }

                bool itemVendorExists = await _context.ItemVendor.AnyAsync(x => x.ItemVendorId == item.ItemVendorId);
                if (!itemVendorExists)
                {
                    return new NotFoundObjectResult("ItemVendor doesn't exist");
                }

                Item newItem = _mapper.Map<Item>(item);
                newItem.ItemId = Guid.NewGuid();
                await _context.Item.AddAsync(newItem);
                await _context.SaveChangesAsync();
                return _mapper.Map<ItemDto>(newItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult<ItemDto>> Update(ItemDto item)
        {
            try
            {
                bool exists = await _context.Item.AnyAsync(x => x.ItemId == item.ItemId);
                if (!exists)
                {
                    return new NotFoundObjectResult("Id doesn't exist");
                }

                if (string.IsNullOrEmpty(item.Upc))
                {
                    return new NotFoundObjectResult("UPC must have a value");
                }
                else
                {
                    if (item.Upc.Length != 12)
                    {
                        return new NotFoundObjectResult("UPC must have 12 digits");
                    }
                    else
                    {
                        long isNumeric;
                        if (!long.TryParse(item.Upc, out isNumeric))
                        {
                            return new NotFoundObjectResult("UPC must contain only numbers");
                        }
                    }
                }

                bool itemVendorExists = await _context.ItemVendor.AnyAsync(x => x.ItemVendorId == item.ItemVendorId);
                if (!itemVendorExists)
                {
                    return new NotFoundObjectResult("ItemVendor doesn't exist");
                }

                Item updateItem = _mapper.Map<Item>(item);
                _context.Entry(updateItem).State = EntityState.Modified;
                _context.Item.Update(updateItem).Property(x => x.ItemNumber).IsModified = false;
                await _context.SaveChangesAsync();
                return _mapper.Map<ItemDto>(updateItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
