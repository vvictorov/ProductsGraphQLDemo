﻿using GraphQL.Types;
using RestaurantGraphQL.Core.Models;
using RestaurantGraphQL.Data.Repositories;

namespace RestaurantGraphQL.Api.Models
{
    public class ProductImageType : ObjectGraphType<ProductImage>
    {
        public ProductImageType()
        {
            Field(x => x.Id);
            Field(x => x.Path);
        }
    }
}