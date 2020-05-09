using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public interface IOrderService
    {
        Order CreateOrder(
            CreateOrderOptions options);
    }
}
