using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGildedRose.Data.Models;

namespace TheGildedRose.Data.Repositories
{
    public interface IInventoryRepository
    {
        IEnumerable<Item> GetInventory();

        Item GetItem(Guid itemId);

    }
}
