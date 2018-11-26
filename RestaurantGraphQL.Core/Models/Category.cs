using System.Collections.Generic;

namespace RestaurantGraphQL.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public virtual List<Product> Products { get; private set; }
    }
}