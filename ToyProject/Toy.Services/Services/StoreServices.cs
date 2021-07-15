using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Entities.Interfaces;
using Toy.Services.Dto.Input;

namespace Toy.Services.Services
{
    public class StoreServices : IStoreServices
    {
        private readonly IStoreRepository storeRepo;
        private readonly IUnitOfWork unitOfWork;
        public StoreServices(IStoreRepository IStoreRepo, IUnitOfWork unitOfWork)
        {
            this.storeRepo = IStoreRepo;
            this.unitOfWork = unitOfWork;
        }
        public async Task Delete(Store store)
        {
            storeRepo.Delete(store);
            await unitOfWork.SaveAsync();
        }

        public async Task<Store> Get(int id)
        {
            var output = await storeRepo.Get(id);
            return output;
        }

        public async Task<int> Insert(StoreInsertDto storeDto)
        {
            var store = new Store()
            {
                Name = storeDto.Name,
                Address = storeDto.Address,
               PhoneNumber=storeDto.PhoneNumber,
                AddedDate = storeDto.AddedDate,
                IsActive = storeDto.IsActive

            };
            var output = storeRepo.Insert(store);
            await unitOfWork.SaveAsync();
            return (output);
        }

        public async Task Update(Store store)
        {
            storeRepo.Update(store);
            await unitOfWork.SaveAsync();
        }
    }
}
