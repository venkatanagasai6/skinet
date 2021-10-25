using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]

    [Route("api/[controller]")] // https://localhost:5001/api/products/ => here products is the name of the class 
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        // create a constructor of getting data
        public ProductsController(StoreContext context)
        {
            _context = context;
        }


        // default function to run 
        [HttpGet]
        public async Task< ActionResult<List<Product>> > getListOfProducts(){
            
            // get the table from db and convert it into list 
            // the list was named as Products in Context class = StoreContext.cs
            var products = await _context.Products.ToListAsync();

            return Ok(products);

        }

        // in case if we give any data after name of the controller
        // this function will called 
        [HttpGet("{id}")]
        public async Task< ActionResult<Product> > getProductName(int id){
            
            return await _context.Products.FindAsync(id);

        }
              
    }
}