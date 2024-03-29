﻿using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        private readonly SignalRContext _context;

        public EfOrderDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public int ActiveOrderCount()
        {
            return _context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
        }

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public decimal LastOrderPrice()
        {
            return _context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
        }

        public decimal TodayTotalPrice()
        {
            var totalPriceForToday = _context.Orders
           .Where(x => x.Date == DateTime.Now.Date) 
           .Sum(y => y.TotalPrice); 
            return totalPriceForToday;

        }

        public int TotalOrderCount()
        {
            return _context.Orders.Count();
        }
    }
}
