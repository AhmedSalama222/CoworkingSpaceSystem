using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoworkingSpaceSystem.BLL.DTOs.SpaceDTOs
{
    //DTO is Located to Retrieve&Read
    public class SpaceToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PricePerHour { get; set; }
        public int Capacity { get; set; }
        public bool  IsAvailable { get; set; }
        public string? PictureUrl { get; set; } // مسار أو اسم صورة القاعة
    }
}
