using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bahar.DemoApp.InventoryService.AppService.Dtos;
using Bahar.DemoApp.InventoryService.AppService.interfaces;
using Bahar.DemoApp.InventoryService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bahar.DemoApp.InventoryService.Web.API.Controllers
{
    [Route("api/Inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
             

        [HttpGet("{Id}", Name = "GetInventory")]
        public ActionResult<Inventory> GetInventory(int Id)
        {
            var inventory = _inventoryService.FindbyId(Id);
            return Ok(inventory);

        }
        [HttpPost]
        public IActionResult SaveNewInventory(InventoryForCreationDto inventory)
        {
          var InventoryToReturn=  _inventoryService.AddInventory(inventory);
           
            return CreatedAtRoute("GetInventory",
                new { Id = InventoryToReturn.Id }, InventoryToReturn);
        }

  
        [HttpGet]
        public IActionResult GetInventories()
        {
            var inventories = _inventoryService.ReturnAllRows();
            return Ok(inventories);
        }

    }
}
