using GraphQL.Types;

namespace RestaurantGraphQL.Api.Models
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Name = "ProductInput";

            Field<NonNullGraphType<StringGraphType>>("Title", Description = "Име");
            Field<NonNullGraphType<FloatGraphType>>("Stock", Description = "Количество");
            Field<NonNullGraphType<UnitEnumType>>("Unit", Description = "Мярка");
            Field<NonNullGraphType<IntGraphType>>("Category", Description = "Категория");
        }
    }
}