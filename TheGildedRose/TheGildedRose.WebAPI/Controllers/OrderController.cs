using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TheGildedRose.Data.Repositories;
using TheGildedRose.Data.Models;
using TheGildedRose.WebAPI.Models;

namespace TheGildedRose.WebAPI.Controllers
{
    public class OrderController : ApiController
    {
        private IOrderRepository _orderRepository;
        private IInventoryRepository _inventoryRepository;

        public OrderController(IOrderRepository orderRepository, IInventoryRepository inventoryRepository)
        {
            _orderRepository = orderRepository;
            _inventoryRepository = inventoryRepository;
        }

        // POST: api/Order
        public HttpResponseMessage Post([FromBody]OrderRequest order)
        {
            if (string.IsNullOrWhiteSpace(order.ItemId))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Item item = _inventoryRepository.GetItem(Guid.Parse(order.ItemId));

            if (item == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            Order newOrder = _orderRepository.Create(item, order.Quantity);

            return Request.CreateResponse<OrderResponse>(HttpStatusCode.OK, new OrderResponse() { OrderId = newOrder.Id.ToString(), OrderTotal = newOrder.Total });
        }

    }
}
