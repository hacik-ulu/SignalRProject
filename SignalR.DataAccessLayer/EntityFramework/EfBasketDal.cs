﻿using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
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
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        private readonly SignalRContext _context;
        public EfBasketDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
            var menuTableNumber = _context.Baskets.Where(x => x.MenuTableID == id).Include(y=>y.Product).ToList();
            return menuTableNumber;
        }
    }
}
