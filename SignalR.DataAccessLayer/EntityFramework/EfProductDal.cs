using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

public class EfProductDal : GenericRepository<Product>, IProductDal
{
    private readonly SignalRContext _context;

    public EfProductDal(SignalRContext context) : base(context)
    {
        _context = context;
    }

    public List<Product> GetProductsWithCategories()
    {
        var productsWithCategories = _context.Products.Include(x => x.Category).ToList();
        return productsWithCategories;
    }
}
