using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EmporoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly IItemManager _iItemManager;
        public ItemController(IItemManager iItemManager)
        {
            _iItemManager = iItemManager;
        }

        [HttpGet("GetAllItems")]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAllItems()
        {
            try
            {
                return await _iItemManager.GetAllItems();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("GetItem")]
        public async Task<ActionResult<ItemDto>> GetItem([FromBody]JObject request)
        {
            try
            {
                dynamic catRequest = (dynamic)request;
                Guid id = catRequest.Id;
                return await _iItemManager.GetItem(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("CreateItem")]
        public async Task<ActionResult<ItemDto>> CreateItem(ItemDto item)
        {
            try
            {
                return await _iItemManager.Create(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateItem")]
        public async Task<ActionResult<ItemDto>> UpdateItem(ItemDto item)
        {
            try
            {
                return await _iItemManager.Update(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
