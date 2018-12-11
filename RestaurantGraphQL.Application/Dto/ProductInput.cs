using RestaurantGraphQL.Core.Enums;

namespace RestaurantGraphQL.Application.Dto
{
    public class ProductInput
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Stock { get; set; }
        public UnitEnum Unit { get; set; }
        public int Category { get; set; }
    }
}