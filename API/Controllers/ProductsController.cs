using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.interfaces;

namespace API.Controllers
{
    [ApiController]

    [Route("api/[controller]")] // https://localhost:5001/api/products/ => here products is the name of the class 
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }



        // default function to run 
        [HttpGet]
        public async Task< ActionResult<List<Product>> > getListOfProducts(){
            
            
            var products = await _repo.GetProductsAsync();

            return Ok(products);

        }

        // in case if we give any data after name of the controller
        // this function will called 
        [HttpGet("{id}")]
        public async Task< ActionResult<Product> > getProductName(int id){
            
            return await _repo.GetProductByIdAsync(id);

        }


        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> getProductBrands()
        {
            // we need to wrap this into OK because we are returning ReadOnlyList check the error
            // for more explanation
            return Ok(await _repo.GetProductBrandsAsync());
        }


        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> getProductTypes()
        {
            // we need to wrap this into OK because we are returning ReadOnlyList check the error
            // for more explanation
            return Ok(await _repo.GetProductTypesAsync());
        }

     
              
    }
}