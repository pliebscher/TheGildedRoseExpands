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
        /// Creates a new order for the specified Merchant and Item.
        /// </summary>
        /// <param name="merchantId">The Id of the Merchant.</param>
        /// <param name="item">The item to be ordered.</param>
        /// <param name="quantity">How many of said item?</param>
        /// <returns></returns>
        public Order Create(Guid merchantId, Item item, int quantity)
        {
            if (merchantId == Guid.Empty)
                throw new ArgumentException("Invalid or Missing MerchantId!");

            if (item is null)
                throw new ArgumentNullException("item");

            if (quantity < 1)
                throw new ArgumentException("Quantity must be greater than or equal to 1.");

            // TODO: Insert some logic here to enque or persist the order...

            return new Order() { Id = Guid.NewGuid(), Total = item.Price * quantity };
        }
    }
}
