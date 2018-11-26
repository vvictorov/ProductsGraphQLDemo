using System;
using System.Collections.Generic;
using RestaurantGraphQL.Core.Enums;

namespace RestaurantGraphQL.Core.Models
{
    public class Product
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public double Stock { get; set; }
        
        public UnitEnum UnitEnum { get; set; }

        public string Unit
        {
            get => UnitEnum.ToString();
            set => UnitEnum = Enum.Parse<UnitEnum>(value);
        }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        public int? CoverId { get; set; }
        public ProductImage Cover { get; set; }
        
        public virtual List<ProductImage> ProductImages { get; private set; }
    }
}