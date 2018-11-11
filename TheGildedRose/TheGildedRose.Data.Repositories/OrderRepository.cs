using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGildedRose.Data.Models;

namespace TheGildedRose.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        /// <summary>
        /// Creates a new Order.
        /// </summary>
        /// <param name="item">The item to be purchased.</param>
        /// <param name="quantity">The desired quantity.</param>
        /// <returns></returns>
        public Order Create(Item item, int quantity)
        {
            if (item is null)
                throw new ArgumentNullException("item");

            if (quantity < 1)
                throw new ArgumentException("quantity must be greater than or equal to 1.");

            // TODO: Insert some logic here to actally enque or persist the order...

            return new Order() { Id = Guid.NewGuid(), Total = item.Price * quantity };
        }
    }
}
