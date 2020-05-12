using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public interface IOrderService
    {
        Order CreateOrder(
            CreateOrderOptions options);

        bool UpdateOrder(
            UpdateOrderOptions options);

        List<Order> SearchOrders(
            SearchOrdersOptions options);
    }
}
