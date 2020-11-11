using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bahar.DemoApp.InventoryService.AppService;
using Bahar.DemoApp.InventoryService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bahar.DemoApp.InventoryService.Web.API.Controllers
{
    [Route("api/Inventories")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        readonly IInventoryService _inventoryService; 
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("{Id}", Name ="GetInventory")]
        public ActionResult <Inventory> GetInventory(int Id)
        {
            var inventory= _inventoryService.GetInventory(Id);
            return Ok(inventory);

        }      
        [HttpPost]
        public IActionResult SaveNewInventory(Inventory inventory)
        {
           _inventoryService.AddInventory(inventory);
            var InventoryToReturn = inventory;
            return   CreatedAtRoute("GetInventory",
                new { Id = inventory.id }, InventoryToReturn);
            }
    }
}
