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
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        readonly IInventoryService _inventoryService; 
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }


       
        [HttpPost]
        public IActionResult SaveNewInventory(Inventory inventory)
        {
        //    throw new Exception("Test Exception");
            _inventoryService.AddInventory(inventory);
            return Ok();
            }
    }
}
