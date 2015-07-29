using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebAPIDemo.Models
{
    public class WebAPIDemoContextInitializer : DropCreateDatabaseAlways<WebAPIDemoContext>
    {
        protected override void Seed(WebAPIDemoContext context)
        {
            var books = new List<BookData>()
            {
                new BookData() {Name="Book1", Author="Author 1", Price=10.01m },
                new BookData() {Name="Book2", Author="Author 2", Price=10.02m },
                new BookData() {Name="Book3", Author="Author 3", Price=10.03m },
                new BookData() {Name="Book4", Author="Author 4", Price=10.04m },
                new BookData() {Name="Book5", Author="Author 5", Price=10.05m },
                new BookData() {Name="Book6", Author="Author 6", Price=10.06m },
                new BookData() {Name="Book7", Author="Author 7", Price=10.07m }
            };

            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();

            var order = new OrderData() { Customer = "Customer 1", OrderDate = new DateTime(2015, 1, 1) };

            var orderDetails = new List<OrderDetailData>
            {
                new OrderDetailData() {Book=books[0], Quantity=1, Order= order},
                new OrderDetailData() {Book=books[2], Quantity=2, Order= order},
                new OrderDetailData() {Book=books[1], Quantity=3, Order= order}
            };

            context.Orders.Add(order);
            orderDetails.ForEach(od => context.OrderDetails.Add(od));
            context.SaveChanges();

            order = new OrderData() { Customer = "Customer 2", OrderDate = new DateTime(2015, 1, 2) };

            orderDetails = new List<OrderDetailData>
            {
                new OrderDetailData() {Book=books[1], Quantity=1, Order= order},
                new OrderDetailData() {Book=books[1], Quantity=1, Order= order},
                new OrderDetailData() {Book=books[3], Quantity=12, Order= order},
                new OrderDetailData() {Book=books[4], Quantity=3, Order= order}
            };

            context.Orders.Add(order);
            orderDetails.ForEach(od => context.OrderDetails.Add(od));
            context.SaveChanges();

            order = new OrderData() { Customer = "Customer 3", OrderDate = new DateTime(2015, 1, 3) };

            orderDetails = new List<OrderDetailData>
            {
                new OrderDetailData() {Book=books[2], Quantity=1, Order= order},
                new OrderDetailData() {Book=books[4], Quantity=1, Order= order},
                new OrderDetailData() {Book=books[3], Quantity=1, Order= order},
                new OrderDetailData() {Book=books[1], Quantity=3, Order= order}
            };

            context.Orders.Add(order);
            orderDetails.ForEach(od => context.OrderDetails.Add(od));
            context.SaveChanges();


            base.Seed(context);
        }
    }
}