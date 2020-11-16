using Microsoft.AspNetCore.Mvc;
using Bahar.DemoApp.InventoryService.Model.Repository;
using Bahar.DemoApp.InventoryService.AppService.Dtos;
using Bahar.DemoApp.InventoryService.AppService.interfaces;
using System;
using Bahar.DemoApp.InventoryService.Repository.SQLServer;

namespace Bahar.DemoApp.InventoryService.Web.API.Controllers
{
    [Route("api/InventoryItem")]
    //  [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        private readonly IInventoryItemService _inventoryItemService;
        private readonly IInventoryService _inventoryService;

        public InventoryItemController(IInventoryItemService inventoryItemService, IInventoryService inventoryService)
        {
            _inventoryItemService = inventoryItemService ?? throw new ArgumentNullException(nameof(inventoryItemService));
            _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
        }

        [HttpPost("{InventoryId}")]
        public IActionResult SaveNewInventoryItem(int inventoryid, InventoryItemForCreationDto inventoryItem)
        {
            try
            {
                var inventoryItemToreturn = _inventoryItemService.AddInventoryItem(inventoryid, inventoryItem);
                return CreatedAtRoute("GetInventoryItem", new { Id = inventoryItemToreturn.id }, inventoryItemToreturn);
            }
            catch (InventoryNotFoundException)
            {
                return NotFound();
            }
           
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
