using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGildedRose.WebAPI.Models
{
    public class OrderRequest
    {
        public string MerchantId { get; set; }

        public string ItemId { get; set; }

        public int Quantity { get; set; }

    }
}
