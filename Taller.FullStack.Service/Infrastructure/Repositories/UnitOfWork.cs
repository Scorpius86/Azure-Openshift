using Taller.FullStack.Service.Infrastructure.Contexts;
using Taller.FullStack.Service.Infrastructure.Entities;

namespace Taller.FullStack.Service.Infrastructure.Repositories;

public class UnitOfWork : IDisposable
{
    private BikestoresContext _context;
    private GenericRepository<Brand> _brandRepository;
    private GenericRepository<Category> _categoryRepository;
    private GenericRepository<Product> _productRepository;

    public UnitOfWork(BikestoresContext context)
    {
        _context = context;
    }
    public GenericRepository<Brand> Brands
    {
        get
        {

            if (this._brandRepository == null)
            {
                this._brandRepository = new GenericRepository<Brand>(_context);
            }
            return _brandRepository;
        }
    }

    public GenericRepository<Category> Categories
    {
        get
        {

            if (this._categoryRepository == null)
            {
                this._categoryRepository = new GenericRepository<Category>(_context);
            }
            return _categoryRepository;
        }
    }

    public GenericRepository<Product> Products
    {
        get
        {

            if (this._productRepository == null)
            {
                this._productRepository = new GenericRepository<Product>(_context);
            }
            return _productRepository;
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
