using AutoMapper;
using CoworkingSpaceSystem.BLL.DTOs.SpaceDTOs;
using CoworkingSpaceSystem.BLL.Helpers;
using CoworkingSpaceSystem.BLL.Services.Interfaces;
using CoworkingSpaceSystem.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoworkingSpaceSystem.Web.Controllers
{
    public class SpaceController : Controller
    {
        private readonly ISpaceService _spaceService;
        private readonly IDocumentSettings _documentSettings;
        private readonly IMapper _mapper;
        public SpaceController(ISpaceService spaceService , IDocumentSettings documentSetting , IMapper mapper)
        {
            _spaceService = spaceService;
            _documentSettings = documentSetting;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var spaceDto = await _spaceService.GetAllSpacesAsync();
            return View(spaceDto);
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var spaceDto = await _spaceService.GetSpaceByIdAsync(id);
            if (spaceDto == null) return NotFound();
            return View (spaceDto);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpaceViewModel model)
        {
            // 1. الفحص التلقائي للـ Validation
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // 2. رفع الصورة إن وجدت
            string? imageFileName = null;
            if (model.Image != null)
            {
                imageFileName = await _documentSettings.UploadFileAsync(model.Image, "spaces");
            }

            // 3. تجهيز الـ DTO
            var spaceDto = new SpaceCreateUpdateDto
            {
                Name = model.Name,
                Description = model.Description,
                PricePerHour = model.PricePerHour,
                Capacity = model.Capacity,
                IsAvailable = model.IsAvailable,
                PictureUrl = imageFileName
            };

            // 4. استدعاء الخدمة
            bool isCreated = await _spaceService.CreateSpaceAsync(spaceDto);

            // ⚠️ التأكد من هذا الشرط: لو النجاح صح، اعمل Redirect فوراً!
            if (isCreated)
            {
                TempData["SuccessMessage"] = "تم إضافة القاعة بنجاح!";
                return RedirectToAction(nameof(Index)); // 👈 لازم يحولك لـ Index وما ينزلش لتحت!
            }

            // لو فشل فقط يوصل للسطرين دول
            ModelState.AddModelError(string.Empty, "حدث خطأ أثناء حفظ البيانات.");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var spaceDto = await _spaceService.GetSpaceByIdAsync(id);
            if (spaceDto == null) return NotFound();

            var viewModel = new SpaceViewModel
            {
                Id = spaceDto.Id,
                Name = spaceDto.Name,
                Description = spaceDto.Description,
                PricePerHour = spaceDto.PricePerHour,
                Capacity = spaceDto.Capacity,
                IsAvailable = spaceDto.IsAvailable,
                PictureUrl = spaceDto.PictureUrl
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id , SpaceViewModel model)
        {
            if (id != model.Id) return BadRequest();
            if (!ModelState.IsValid) return View(model);
            string? imageFileName = model.PictureUrl;
            if(model.Image!=null)
            {
                if(!string.IsNullOrEmpty(model.PictureUrl))
                {
                    _documentSettings.DeletedFile(model.PictureUrl, "spaces");

                }
                imageFileName = await _documentSettings.UploadFileAsync(model.Image, "spaces");
            }
            var spaceDto = new SpaceCreateUpdateDto
            {
                Name = model.Name,
                Description = model.Description,
                PricePerHour=model.PricePerHour,
                Capacity=model.Capacity,
                IsAvailable=model.IsAvailable,
                PictureUrl=model.PictureUrl,

            };
            bool IsUpdated = await _spaceService.UpdateSpaceAsync(id, spaceDto);

            if(IsUpdated)
            {
                TempData["SuccessMessage"] = "Updated is Done";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var spaceDto = await _spaceService.GetSpaceByIdAsync(id);
            if(spaceDto !=null)
            {
                if(!string.IsNullOrEmpty(spaceDto.PictureUrl))
                {
                    _documentSettings.DeletedFile(spaceDto.PictureUrl, "spaces");
                }
                await _spaceService.DeleteSpaceAsync(id);
                TempData["SuccessMessage"] = "Sapce is Deleted Done";
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
