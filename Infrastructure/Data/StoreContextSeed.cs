using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task seedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {

            try
            {
                // FOR PRODUCT BRANDS TABLE 
                 if (!context.ProductBrands.Any()) // if the ProductBrands table was empty then
                 {
                     //read the json file
                     var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    // convert the json files into lists of productBrand objects 
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    // add them to database via context 
                    foreach(var item in brands){
                        context.ProductBrands.Add(item);
                    }

                    // save the changes of database 
                    await context.SaveChangesAsync();
                 }

                 // ---------------------------------FOR PRODUCT TYPE TABLE ----------------------------------------------
                 if (!context.ProductTypes.Any()) // if the ProductBrands table was empty then
                 {
                     //read the json file
                     var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    // convert the json files into lists of productBrand objects 
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    // add them to database via context 
                    foreach(var item in types){
                        context.ProductTypes.Add(item);
                    }

                    // save the changes of database 
                    await context.SaveChangesAsync();
                 }

                 // ------------------------------- FOR PRODUCTS TABLE -------------------------------------------
                 if (!context.Products.Any()) // if the ProductBrands table was empty then
                 {
                     //read the json file
                     var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    // convert the json files into lists of productBrand objects 
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    // add them to database via context 
                    foreach(var item in products){
                        context.Products.Add(item);
                    }

                    // save the changes of database 
                    await context.SaveChangesAsync();
                 }
            }
            catch (Exception ex)
            {
                // log the exception from the current class StoreContextSeed
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
            
        }
    }
}