using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Entities.Interfaces;
using Toy.Services.Dto.Input;

namespace Toy.Services.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository categoryRepo;
        private readonly IUnitOfWork unitOfWork;
        public CategoryServices(ICategoryRepository ICategoryRepo, IUnitOfWork unitOfWork)
        {
            this.categoryRepo = ICategoryRepo;
            this.unitOfWork = unitOfWork;
        }
        public async Task Delete(Category category)
        {
            categoryRepo.Delete(category);
            await unitOfWork.SaveAsync();
        }

        public async Task<Category> Get(int id)
        {
            var output = await categoryRepo.Get(id);
            return output;
        }

        public async Task<int> Insert(CategoryInsertDto categoryDto)
        {
            var category = new Category()
            {
                Name=categoryDto.Name,
                
            };

            var output = categoryRepo.Insert(category);
            await unitOfWork.SaveAsync();
            return (output);
        }

        public async Task Update(Category category)
        {
            categoryRepo.Update(category);
            await unitOfWork.SaveAsync();
        }
    }
}
