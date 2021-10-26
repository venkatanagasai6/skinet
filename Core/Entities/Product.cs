using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        // the id was present in the BaseEntity class
        public string Name { get; set; }

        public string Description { get; set; }
        
        public decimal Price { get; set; }
    
        public string PictureUrl { get; set; }


        // ProductType class has table of products list 
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }


        //ProductBrand has the brand names as another table 
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}