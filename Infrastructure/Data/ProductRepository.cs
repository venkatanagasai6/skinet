using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        // create a constructor of getting data
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }
        

        // get the product based on given id from the database 
        public async Task<Product> GetProductByIdAsync(int id)
        {
            // return the product data which has the given id 
            return await _context.Products
                .Include(p => p.ProductType) // include productType in table
                .Include(p => p.ProductBrand) // inclue ProductBrand in table 
                .FirstOrDefaultAsync(p => p.Id == id); 
                                // instead of FindAsync use either 
                                //SingleOrDefaultAsync or FirstOrDefaultAsync
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            // get the table from db and convert it into list 
            // the list was named as Products in Context class = StoreContext.cs
            return await _context.Products
                .Include(p => p.ProductType) // include productType in table
                .Include(p => p.ProductBrand) // inclue ProductBrand in table 
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();           
        }
    }
}