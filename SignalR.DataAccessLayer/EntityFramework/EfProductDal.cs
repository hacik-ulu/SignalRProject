using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System.Linq;

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

    public decimal ProductAveragePriceByHamburger()
    {
        return _context.Products.Where(x => x.CategoryID == _context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault()).Average(w => w.Price);
    }

    public int ProductCount()
    {
        var productCount = _context.Products.Count();
        return productCount;
    }

    public int ProductCountByCategoryNameDrink()
    {
        return _context.Products.Where(x => x.CategoryID == (_context.Categories.Where(y => y.CategoryName == "İçecek").
        Select(z => z.CategoryID).FirstOrDefault())).Count();
    }

    public int ProductCountByCategoryNameHamburger()
    {
        return _context.Products.Where(x => x.CategoryID == (_context.Categories.Where(y => y.CategoryName == "Hamburger").
       Select(z => z.CategoryID).FirstOrDefault())).Count();
    }

    public string ProductNameByMaxPrice()
    {
        return _context.Products.Where(x => x.Price == (_context.Products.Max(y => y.Price))).
            Select(z => z.ProductName).FirstOrDefault();
    }

    public string ProductNameByMinPrice()
    {
        return _context.Products.Where(x => x.Price == (_context.Products.Min(y => y.Price))).
            Select(z => z.ProductName).FirstOrDefault();
    }

    public decimal ProductPriceAverage()
    {
        return _context.Products.Average(x => x.Price);
    }

    public decimal ProductPriceBySteakBurger()
    {
        return _context.Products.Where(x => x.ProductName == "Steak Burger").Select(y => y.Price).FirstOrDefault();
    }

    public decimal TotalPriceByDrinkCategory()
    {
        int id = _context.Categories.Where(x => x.CategoryName == "İçecek").Select(y => y.CategoryID).FirstOrDefault();
        return _context.Products.Where(x => x.CategoryID == id).Sum(y => y.Price);
    }

    public decimal TotalPriceBySaladCategory()
    {
        int id = _context.Categories.Where(x => x.CategoryName == "Salata").Select(y => y.CategoryID).FirstOrDefault();
        return _context.Products.Where(x => x.CategoryID == id).Sum(y => y.Price);
    }
}
