using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Entities.Interfaces;
using Toy.Services.Dto.Input;

namespace Toy.Services.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository productRepo;

        public ProductServices(IProductRepository IProductRepo)
        {
            this.productRepo = IProductRepo;
        }

        public async Task Delete(Product product)
        {
            await productRepo.Delete(product);
        }

        public async Task<Product> Get(int id)
        {
            var output = await productRepo.Get(id);
            return output;
        }

        public async Task<int> Insert(ProductInsertDto productDto)
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
                Brand = productDto.Brand,
                AgeRestriction = productDto.AgeRestriction,
                IsMale = productDto.IsMale,
                InfluenceCategory = productDto.InfluenceCategory
            };
            return await productRepo.Insert(product);
        }

        public async Task Update(Product product)
        {
            await productRepo.Update(product);
        }
    }
}
