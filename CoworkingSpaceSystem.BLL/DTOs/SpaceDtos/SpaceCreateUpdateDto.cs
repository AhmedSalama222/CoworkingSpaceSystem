using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoworkingSpaceSystem.BLL.DTOs.SpaceDTOs
{
    public class SpaceCreateUpdateDto
    {
        [Required(ErrorMessage = "Space Name is Required")]
        [StringLength(100,ErrorMessage = "Space Name Mustn't Exceed 100 Character ")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Range(1,1000 , ErrorMessage = "PricePerHour Range Must Between 1 and 1000")]
        public decimal PricePerHour { get; set; }
        [Range(1, 500, ErrorMessage = "Capacity Range Must Between 1 and 500")]

        public int Capacity { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string? PictureUrl { get; set; } // مسار أو اسم صورة القاعة
    }
}
