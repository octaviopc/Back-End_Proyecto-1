using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_End.Dtos.Inventory;
using Back_End.Services.IventoryService;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IInventoryService _itemService;
        public ItemController(IInventoryService itemService)
        {
            _itemService = itemService;

        }

        [HttpGet("GetAllItems")]
        public async Task<ActionResult<ServiceResponse<List<GetInventoryDto>>>> Get()
        {
            return Ok(await _itemService.GetAllItems());
        }

        [HttpPost("NewItem")]
        public async Task<ActionResult<ServiceResponse<List<GetInventoryDto>>>> AddItem(AddInventoryDto newItem)
        {
            return Ok(await _itemService.AddItem(newItem));
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<ServiceResponse<List<GetInventoryDto>>>> GetItemByUserID(int id)
        {
            return Ok(await _itemService.GetItemByUserId(id));
        }
    }
}