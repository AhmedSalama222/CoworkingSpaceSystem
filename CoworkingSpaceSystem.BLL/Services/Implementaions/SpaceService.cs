using AutoMapper;
using CoworkingSpaceSystem.BLL.DTOs.SpaceDTOs;
using CoworkingSpaceSystem.BLL.Services.Interfaces;
using CoworkingSpaceSystem.DAL.Entities;
using CoworkingSpaceSystem.DAL.Repositories.Implementations;
using CoworkingSpaceSystem.DAL.Repositories.Interfaces;

namespace CoworkingSpaceSystem.BLL.Services.Implementaions
{
    public class SpaceService : ISpaceService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public SpaceService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }
        public async Task<IEnumerable<SpaceToReturnDto>> GetAllSpacesAsync()
        {
            var spaces = await unitOfWork.Spaces.GetAllAsync();
            return mapper.Map<IEnumerable<SpaceToReturnDto>>(spaces);
        }

        public async Task<SpaceToReturnDto?> GetSpaceByIdAsync(int id)
        {
            var space = await unitOfWork.Spaces.GetByIdAsync(id);
            if (space == null)
                return null;
            return mapper.Map<SpaceToReturnDto>(space);
        }

        public async Task<bool> CreateSpaceAsync(SpaceCreateUpdateDto spaceDto)
        {
            try
            {
                var spaceEntity = mapper.Map<Space>(spaceDto);

                await unitOfWork.Spaces.AddAsync(spaceEntity);

                int result = await unitOfWork.CompleteAsync();

                // result بيكون عدد الصفوف المتأثرة (لو أضاف صف واحد بيرجع 1)
                return result > 0;
            }
            catch (Exception ex)
            {
                // لو حابب تتتبع الإيرور في الـ Console
                Console.WriteLine($"Error in CreateSpaceAsync: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> UpdateSpaceAsync(int id, SpaceCreateUpdateDto spaceDto)
        {
            var existingSpace = await unitOfWork.Spaces.GetByIdAsync(id);
            if (existingSpace == null) return false;
            mapper.Map(spaceDto, existingSpace);
            int rowAffected= await unitOfWork.CompleteAsync();
            return rowAffected > 0;

        }

        public async Task<bool> DeleteSpaceAsync(int id)
        {
            var space = await unitOfWork.Spaces.GetByIdAsync(id);
            if (space == null) return false;
            unitOfWork.Spaces.Delete(space);
            return await unitOfWork.CompleteAsync() > 0;
        }
    }
}
