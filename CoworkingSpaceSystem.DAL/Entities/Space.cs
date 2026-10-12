using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoworkingSpaceSystem.DAL.Entities
{
    public class Space
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PricePerHour { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public string? PictureUrl { get; set; } // مسار أو اسم صورة القاعة
    }
}
