using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoworkingSpaceSystem.BLL.DTOs.SpaceDTOs;

namespace CoworkingSpaceSystem.BLL.Services.Interfaces
{
    public interface ISpaceService
    {

        Task<IEnumerable<SpaceToReturnDto>> GetAllSpacesAsync();
        Task<SpaceToReturnDto?> GetSpaceByIdAsync(int id);
        Task<bool> CreateSpaceAsync(SpaceCreateUpdateDto spaceCreateUpdateDto);
        Task<bool> UpdateSpaceAsync(int id, SpaceCreateUpdateDto spaceCreateUpdateDto);
        Task<bool> DeleteSpaceAsync(int id);
    }
}
