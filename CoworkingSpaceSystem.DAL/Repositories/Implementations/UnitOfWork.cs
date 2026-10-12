using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoworkingSpaceSystem.DAL.Context;
using CoworkingSpaceSystem.DAL.Entities;
using CoworkingSpaceSystem.DAL.Repositories.Interfaces;

namespace CoworkingSpaceSystem.DAL.Repositories.Implementations
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Space> Spaces { get; private set; }
        public IGenericRepository<Member> Members { get; private set; }
        public IGenericRepository<Booking> Bookings { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Spaces = new GenericRepository<Space>(_context);
            Members = new GenericRepository<Member>(_context);
            Bookings = new GenericRepository<Booking>(_context);
        }


        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
        public void Dispose() =>  _context.Dispose();
    }
}
