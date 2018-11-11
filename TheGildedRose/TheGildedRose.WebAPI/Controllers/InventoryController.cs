using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TheGildedRose.Data.Repositories;
using TheGildedRose.Data.Models;

namespace TheGildedRose.WebAPI.Controllers
{
    public class InventoryController : ApiController
    {

        private IInventoryRepository _inventoryRepository;

        public InventoryController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        // GET: api/Inventory
        public IEnumerable<Item> Get()
        {
            return _inventoryRepository.GetInventory();
        }

     }
}
