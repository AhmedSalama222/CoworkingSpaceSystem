using System.ComponentModel.DataAnnotations;

namespace CoworkingSpaceSystem.Web.ViewModels
{
    public class SpaceViewModel
    {
        [Required(ErrorMessage = "Name of Space is Required")]
        [Display(Name = "Name of Space")]
        public string Name { get; set; } = string.Empty;
        public int Id { get; set; }
        [Display(Name = "Discripion of Space")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage ="The Price of Hour is Required")]
        [Range(1,1000,ErrorMessage ="The Price of Hour is Must be requied Range 1 --> 1000")]
        [Display(Name="Price of Hour")]
        public decimal PricePerHour { get; set; }
        [Required(ErrorMessage = "سعة القاعة مطلوبة")]
        [Range(1, 500, ErrorMessage = "السعة يجب أن تكون بين 1 و 500 شخص")]
        [Display(Name = "سعة القاعة (أفراد)")]
        public int Capacity { get; set; }
        [Display(Name = "متاحة للحجز")]
        public bool IsAvailable { get; set; } = true;

        public string? PictureUrl { get; set; }

        // خاصية استقبال صورة القاعة المرفوعة من الشاشة
        [Display(Name = "صورة القاعة")]
        public IFormFile? Image { get; set; }

    }

}
