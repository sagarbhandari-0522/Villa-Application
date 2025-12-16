using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Villa.Application.Interface;
using Villa.Domain.Entities;
using Villa.Infrastructure.Data;

namespace Villa.Infrastructure.Repository
{
    public class RoomRepository : IRoomRepository
    {
        public readonly ApplicationDbContext _context;
        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public void Add(Room room)
        {
            _context.Villas.Add(room);
            _context.SaveChanges();
        }

        public IEnumerable<Room> GetAll(Expression<Func<Room, bool>>? filter = null, params Expression<Func<Room, object>>[] includeProperties)
        {

            IQueryable<Room> query = _context.Villas;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {

                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.ToList();
        }

        public Room GetById(int id, params Expression<Func<Room, object>>[] includeProperties)
        {
            IQueryable<Room> query = _context.Villas;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault(v => v.Id == id);
        }

        public void Remove(Room room)
        {
            _context.Villas.Remove(room);
            _context.SaveChanges();

        }

        public void Update(Room room)
        {
            _context.Villas.Update(room);
            _context.SaveChanges();
        }
    }
}
