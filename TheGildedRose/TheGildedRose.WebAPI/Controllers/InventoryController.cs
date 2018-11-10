using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TheGildedRose.Data.Repositories;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "1", "2" };
        }

        // GET: api/Inventory/5
        public string Get(int id)
        {
            return "value";
        }

    }
}
