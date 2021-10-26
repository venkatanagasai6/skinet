using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.interfaces
{
    // this interface was implemented at [ Infrastructure > Data > ProductRepository.cs ]
    public interface IProductRepository
    {
        // NOTE : the name of the function ENDS WITH Async was just a naming convention it can be anything


        // create an async interface for getting product Id asynchronously
        Task<Product> GetProductByIdAsync(int id);


    /*   create an async interface for getting list of products asynchronously
         make the return type of the list more understandable like we need to only read the data 
         in the list so we use the ReadOnlyList */
        Task< IReadOnlyList< Product >  > GetProductsAsync();

        Task< IReadOnlyList< ProductBrand >  > GetProductBrandsAsync();

        Task< IReadOnlyList< ProductType >  > GetProductTypesAsync();

    }
}