using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bahar.DemoApp.InventoryService.AppService;
using Bahar.DemoApp.InventoryService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bahar.DemoApp.InventoryService.AppService.ResourceParameters;

namespace Bahar.DemoApp.InventoryService.Web.API.Controllers
{
    [Route("api/InventoryItem")]
    //  [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        readonly IInventoryItemService _inventoryItemService;
        public InventoryItemController(IInventoryItemService inventoryItemService)
        {
            _inventoryItemService = inventoryItemService;
        }


        [HttpPost("{InventoryId}")]
        public IActionResult SaveNewInventoryItem(int Inventoryid, InventoryItemForCreationDto inventoryItem)
        {
            var inventoryItemToreturn = _inventoryItemService.AddInventoryItem(Inventoryid, inventoryItem);
            return CreatedAtRoute("GetInventoryItem", new { Id = inventoryItemToreturn.id }, inventoryItemToreturn);
           
        }

      
        [HttpGet()]
        public ActionResult GetInventoryItems(InventoryItemResourceParameters inventoryItemResourceParameters)
        {
            var InventoryItems = _inventoryItemService.GetInventoryItems(inventoryItemResourceParameters);
            return Ok(InventoryItems);
        }
            
        [HttpGet("{Id}",Name = "GetInventoryItem")]
        public ActionResult<InventoryItemDto> GetInventoryItem(int InventoryItemId)
        {
            var inventoryItem = _inventoryItemService.FindbyId(InventoryItemId);
            return Ok(inventoryItem);

        }


    }
}
