using Microsoft.EntityFrameworkCore;
using Taller.FullStack.Service.Infrastructure.Entities;

namespace Taller.FullStack.Service.Infrastructure.Contexts;
public partial class BikestoresContext : DbContext
{
    private Brand Electra;
    private Brand Haro;
    private Brand Heller;
    private Brand Pure_Cycles;
    private Brand Ritchey;
    private Brand Strider;
    private Brand Sun_Bicycles;
    private Brand Surly;
    private Brand Trek;

    private Category Children_Bicycles;
    private Category Comfort_Bicycles;
    private Category Cruisers_Bicycles;
    private Category Cyclocross_Bicycles;
    private Category Electric_Bikes;
    private Category Mountain_Bikes;

    public void SeeData()
    {
        Database.EnsureCreated();
        EnsureBrands();
        EnsureCategories();
        EnsureProducts();
    }

    private void EnsureBrands()
    {
        Electra = new Brand { BrandName = "Electra" };
        Haro = new Brand { BrandName = "Haro" };
        Heller = new Brand { BrandName = "Heller" };
        Pure_Cycles = new Brand { BrandName = "Pure Cycles" };
        Ritchey = new Brand { BrandName = "Ritchey" };
        Strider = new Brand { BrandName = "Strider" };
        Sun_Bicycles = new Brand { BrandName = "Sun Bicycles" };
        Surly = new Brand { BrandName = "Surly" };
        Trek = new Brand { BrandName = "Trek" };

        if (!Brands.Where(b => b.BrandName == Electra.BrandName).Any()) { Brands.Add(Electra); }
        if (!Brands.Where(b => b.BrandName == Haro.BrandName).Any()) { Brands.Add(Haro); }
        if (!Brands.Where(b => b.BrandName == Heller.BrandName).Any()) { Brands.Add(Heller); }
        if (!Brands.Where(b => b.BrandName == Pure_Cycles.BrandName).Any()) { Brands.Add(Pure_Cycles); }
        if (!Brands.Where(b => b.BrandName == Ritchey.BrandName).Any()) { Brands.Add(Ritchey); }
        if (!Brands.Where(b => b.BrandName == Strider.BrandName).Any()) { Brands.Add(Strider); }
        if (!Brands.Where(b => b.BrandName == Sun_Bicycles.BrandName).Any()) { Brands.Add(Sun_Bicycles); }
        if (!Brands.Where(b => b.BrandName == Surly.BrandName).Any()) { Brands.Add(Surly); }
        if (!Brands.Where(b => b.BrandName == Trek.BrandName).Any()) { Brands.Add(Trek); }

        SaveChanges();
    }
    private void EnsureCategories()
    {
        Children_Bicycles = new Category { CategoryName = "Children Bicycles" };
        Comfort_Bicycles = new Category { CategoryName = "Comfort Bicycles" };
        Cruisers_Bicycles = new Category { CategoryName = "Cruisers Bicycles" };
        Cyclocross_Bicycles = new Category { CategoryName = "Cyclocross Bicycles" };
        Electric_Bikes = new Category { CategoryName = "Electric Bikes" };
        Mountain_Bikes = new Category { CategoryName = "Mountain Bikes" };

        if (!Categories.Where(c => c.CategoryName == Children_Bicycles.CategoryName).Any()) { Categories.Add(Children_Bicycles); }
        if (!Categories.Where(c => c.CategoryName == Comfort_Bicycles.CategoryName).Any()) { Categories.Add(Comfort_Bicycles); }
        if (!Categories.Where(c => c.CategoryName == Cruisers_Bicycles.CategoryName).Any()) { Categories.Add(Cruisers_Bicycles); }
        if (!Categories.Where(c => c.CategoryName == Cyclocross_Bicycles.CategoryName).Any()) { Categories.Add(Cyclocross_Bicycles); }
        if (!Categories.Where(c => c.CategoryName == Electric_Bikes.CategoryName).Any()) { Categories.Add(Electric_Bikes); }
        if (!Categories.Where(c => c.CategoryName == Mountain_Bikes.CategoryName).Any()) { Categories.Add(Mountain_Bikes); }

        SaveChanges();
    }
    private void EnsureProducts()
    {
        List<Product> products = new List<Product>()
        {
            new Product { ProductName="Trek 820 - 2016",BrandId=9,CategoryId=6,ModelYear=2016,ListPrice=379_99 },
            new Product { ProductName="Ritchey Timberwolf Frameset - 2016",BrandId=5,CategoryId=6,ModelYear=2016,ListPrice=749_99 },
            new Product { ProductName="Electra Cruiser 1 (24-Inch) - 2016",BrandId=1,CategoryId=3,ModelYear=2016,ListPrice=269_99 },
            new Product { ProductName="Heller Bloodhound Trail - 2018",BrandId=3,CategoryId=6,ModelYear=2018,ListPrice=2599_00 },
            new Product { ProductName="Surly Straggler - 2016",BrandId=8,CategoryId=4,ModelYear=2016,ListPrice=1549_00 },
            new Product { ProductName="Trek CrossRip+ - 2018",BrandId=9,CategoryId=5,ModelYear=2018,ListPrice=4499_99 },
            new Product { ProductName="Sun Bicycles Drifter 7 - Women's - 2017",BrandId=7,CategoryId=2,ModelYear=2017,ListPrice=470_99 },
            new Product { ProductName="Sun Bicycles Cruz 7 - 2017",BrandId=7,CategoryId=3,ModelYear=2017,ListPrice=416_99 },
            new Product { ProductName="Pure Cycles Vine 8-Speed - 2016",BrandId=4,CategoryId=3,ModelYear=2016,ListPrice=429_00 },
            new Product { ProductName="Electra Treasure 1 20 - 2018",BrandId=1,CategoryId=1,ModelYear=2018,ListPrice=319_99 }
        };

        products.ForEach(product =>
        {
            if (!Products.Where(p => p.ProductName == product.ProductName).Any()) { Products.Add(product); }
        });

        SaveChanges();
    }
}

