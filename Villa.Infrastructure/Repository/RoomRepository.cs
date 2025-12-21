using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Villa.Application.DTO;
using Villa.Application.Interface;
using Villa.Domain.Entities;
using Villa.Infrastructure.Data;

namespace Villa.Infrastructure.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public readonly ApplicationDbContext _context;
        public RoomRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Add(Room room)
        {
            _context.Villas.Add(room);
        }
        public void Remove(Room room)
        {
            _context.Villas.Remove(room);
        }

        public void Update(Room room)
        {
            _context.Villas.Update(room);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        
        public IEnumerable<IdNameDto> LoadVillaList()
        {
            return _context.Villas.Select(v => new IdNameDto { Id = v.Id, Name = v.Name });
        }

    }
}
