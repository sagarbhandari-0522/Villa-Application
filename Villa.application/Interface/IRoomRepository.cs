using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Villa.Domain.Entities;

namespace Villa.Application.Interface
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll(Expression<Func<Room, bool>>? filter = null, params Expression<Func<Room, object>>[] includeProperties);
        Room GetById(int id, params Expression<Func<Room, object>>[] includeProperties);
        void Add(Room room);
        void Remove(Room room);
        void Update(Room room);

    }
}
