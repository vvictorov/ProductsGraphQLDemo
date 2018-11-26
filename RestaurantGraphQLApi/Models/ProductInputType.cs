using GraphQL.Types;

namespace RestaurantGraphQL.Api.Models
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Name = "ProductInput";
            
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<NonNullGraphType<FloatGraphType>>("stock");
            Field<NonNullGraphType<UnitEnumType>>("unitEnum");
            Field<NonNullGraphType<IntGraphType>>("categoryId");
        }
    }
}