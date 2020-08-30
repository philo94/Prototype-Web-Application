
using Myshop.Core.Contracts;
using Myshop.Core.Models;
using Myshop.Core.ViewModels;
using MyShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyShop.Services
{
    public class OrderService: IOrderService
    {
        IRepository<Order> orderContext;
        public OrderService(IRepository<Order> OrderContext)
        {
            this.orderContext = OrderContext;
        }

        public void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems)
        {
            foreach(var item in basketItems)
            {
                baseOrder.OrderItems.Add(new OrderItem(){
                    ProductId = item.Id,
                    Image =item.Image,
                    Price =item.Price,
                    ProductName =item.ProductName,
                    Quantity =item.Quantity

                });
            }

            orderContext.Insert(baseOrder);
            orderContext.Commit();
        }

        //Method to return List of Orders
        public List<Order> GetOrderList()
        {
            return orderContext.Collection().ToList();
        }

        public Order GetOrder(string Id)
        {
            return orderContext.Find(Id);
        }

        public void UpdateOrder(Order updatedOrder)
        {
            orderContext.Update(updatedOrder);
            orderContext.Commit();
        }
    }

   
}
