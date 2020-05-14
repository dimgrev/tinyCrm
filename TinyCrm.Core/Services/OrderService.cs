using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Interfaces;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public class OrderService : IOrderService
    {
        private TinyCrmDbContext context_;
        private ICustomerService customers_;
        private IProductService products_;

        public OrderService(
            TinyCrmDbContext context,
            ICustomerService customer,
            IProductService product)
        {
            context_ = context;
            customers_ = customer;
            products_ = product;
        }

        public Order CreateOrder(CreateOrderOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var customer = customers_.GetCustomerById(options.CustomerId).SingleOrDefault();

            if (customer == null)
            {
                return null;
            }

            var order = new Order()
            {
                DeliveryAddress = options.DeliveryAddress,
            };

            //var products = new List<Product>();

            foreach (var item in options.ProductIds)
            {
                var pResult = products_.GetProductById(item).SingleOrDefault();

                if (pResult != null)
                {
                    var orderProduct = new OrderProduct()
                    {
                        Product = pResult,
                    };

                    order.TotalAmount += pResult.Price;

                    order.OrderProducts.Add(orderProduct);
                }
                else
                {
                    return null;
                }
            }
            if (order.OrderProducts.Count == 0)
            {
                return null;
            }

            customer.Orders.Add(order);

            context_.Update(customer);


            return context_.SaveChanges() > 0 ? order : null;
        }

        public IQueryable<Order> SearchOrders(SearchOrderOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = context_
                .Set<Order>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.DeliveryAddress))
            {
                query = query.Where(c => c.DeliveryAddress.Contains(options.DeliveryAddress));
            }

            if (options.OrderId != null)
            {
                query = query.Where(c => c.OrderId == options.OrderId);
            }

            if (options.CreatedFrom != null)
            {
                query = query.Where(c => c.Created >= options.CreatedFrom);
            }

            if (options.CreatedTo != null)
            {
                query = query.Where(c => c.Created <= options.CreatedTo);
            }

            if (options.PriceFrom >= 0)
            {
                query = query.Where(c => c.TotalAmount >= options.PriceFrom);
            }

            if (options.PriceTo >= 0)
            {
                query = query.Where(c => c.TotalAmount <= options.PriceTo);
            }

            return query;
        }

        public bool UpdateOrder(UpdateOrderOptions options)
        {
            if (options == null)
            {
                return false;
            }

            var order = context_
                .Set<Order>()
                .Where(x => x.OrderId == options.OrderId)
                .Include(o => o.OrderProducts)
                .SingleOrDefault();

            if (order == null)
            {
                return false;
            }

            if (options.DeliveryAddress != null)
            {
                order.DeliveryAddress = options.DeliveryAddress;
            }

            order.OrderProducts.Clear();

            order.TotalAmount = 0M;

            foreach (var id in options.ProductIds)
            {
                var product = products_.GetProductById(id).SingleOrDefault();

                if (product == null)
                {
                    return false;
                }

                order.OrderProducts.Add(new OrderProduct()
                {
                    Product = product,
                });

                order.TotalAmount += product.Price;
            }

            return context_.SaveChanges() > 0 ? true : false;
        }
    }
}
