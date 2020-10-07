using BusinessLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IItemManager
    {
        Task<ActionResult<IEnumerable<ItemDto>>> GetAllItems();
        Task<ActionResult<ItemDto>> GetItem(Guid id);
        Task<ActionResult<ItemDto>> Create(ItemDto item);
        Task<ActionResult<ItemDto>> Update(ItemDto item);
    }
}
