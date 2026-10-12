using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoworkingSpaceSystem.DAL.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int SpaceId { get; set; }
        public Space Space { get; set; } = null!;
        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; } = false;
    }
}
