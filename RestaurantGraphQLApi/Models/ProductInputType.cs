using GraphQL.Types;

namespace RestaurantGraphQL.Api.Models
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Name = "ProductInput";

            Field<NonNullGraphType<StringGraphType>>("Title");
            Field<NonNullGraphType<FloatGraphType>>("Stock");
            Field<NonNullGraphType<UnitEnumType>>("Unit");
            Field<NonNullGraphType<IntGraphType>>("Category");
        }
    }
}