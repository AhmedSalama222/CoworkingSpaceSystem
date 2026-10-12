using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoworkingSpaceSystem.DAL.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime JoinedDate { get; set; } = DateTime.Now;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
