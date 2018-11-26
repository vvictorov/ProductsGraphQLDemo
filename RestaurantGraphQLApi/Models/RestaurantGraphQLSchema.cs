using GraphQL;
using GraphQL.Types;

namespace RestaurantGraphQL.Api.Models
{
    public class RestaurantGraphQLSchema : Schema
    {
        public RestaurantGraphQLSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<RestaurantGraphQLQuery>();
            Mutation = resolver.Resolve<RestaurantGraphQLMutation>();
        }
    }
}