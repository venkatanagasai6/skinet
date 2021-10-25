using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    //DbContext is use to save and query the entities 
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }


        //use to retrive the data from the constructor 
        // name of the table
        public DbSet<Product> Products { get; set; }


    }
}