using System;
using System.Threading.Tasks;
using RestaurantGraphQL.Application.Dto;
using RestaurantGraphQL.Core.Interfaces;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.Application
{
    public class ProductsAppService : IProductsAppService
    {
        private IProductRepository _productRepository;

        public ProductsAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CrudProductOutput> CreateProduct(ProductInput input)
        {
            var product = new Product
            {
                Title = input.Title,
                Stock = input.Stock,
                UnitEnum = input.Unit,
                CategoryId = input.Category
            };

            var output = new CrudProductOutput();

            try
            {
                var result = await _productRepository.Create(product);
                output.Entity = result;
                output.WasSuccessful = true;
            }
            catch (Exception exception)
            {
                output.WasSuccessful = false;
                output.Errors.Add(exception.Message);
            }

            return output;
        }

        public async Task<CrudProductOutput> UpdateProduct(ProductInput input)
        {
            var product = new Product
            {
                Id = input.Id,
                Title = input.Title,
                Stock = input.Stock,
                UnitEnum = input.Unit,
                CategoryId = input.Category
            };

            var output = new CrudProductOutput();

            try
            {
                var result = await _productRepository.Update(product);
                output.Entity = result;
                output.WasSuccessful = true;
            }
            catch (Exception exception)
            {
                output.WasSuccessful = false;
                output.Errors.Add(exception.Message);
            }

            return output;
        }
    }
}