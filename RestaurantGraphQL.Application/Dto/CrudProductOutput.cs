using System.Collections.Generic;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.Application.Dto
{
    public class CrudProductOutput
    {
        public bool WasSuccessful { get; set; }
        public Product Entity { get; set; }
        public List<string> Errors { get; private set; }
    }
}