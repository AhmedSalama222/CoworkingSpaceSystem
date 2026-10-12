using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoworkingSpaceSystem.DAL.Entities;

namespace CoworkingSpaceSystem.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Space> Spaces { get; }
        IGenericRepository<Member> Members { get; }
        IGenericRepository<Booking> Bookings { get; }

        Task<int> CompleteAsync();
    }
}
