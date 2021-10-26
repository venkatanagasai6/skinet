using System;
using System.Reflection;
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


        //use to retrive the data from the constructor and
        //this is the name of the table
        public DbSet<Product> Products { get; set; }

        // table of all products brands
        public DbSet<ProductBrand> ProductBrands {get; set;}

        // table of all products type
        public DbSet<ProductType> ProductTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder); // pass the modelBuilder to base constructor

            // apply the configurations 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}

