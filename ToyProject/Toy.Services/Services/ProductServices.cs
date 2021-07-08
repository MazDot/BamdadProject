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
        private readonly IUnitOfWork unitOfWork;

        public ProductServices(IProductRepository IProductRepo, IUnitOfWork unitOfWork)
        {
            this.productRepo = IProductRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task Delete(Product product)
        {
            productRepo.Delete(product);
            await unitOfWork.SaveAsync();
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
            
            var output = productRepo.Insert(product);
            await unitOfWork.SaveAsync();
            return (output);
        }

        public async Task Update(Product product)
        {
            productRepo.Update(product);
            await unitOfWork.SaveAsync();
        }
    }
}
