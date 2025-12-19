using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Villa.Application.DTO;
using Villa.Domain.Entities;

namespace Villa.Application.Interface
{
    public interface IRoomRepository :IRepository<Room>
    {
        IEnumerable<IdNameDto> LoadVillaList();
     
        void Remove(Room room);
        void Update(Room room);
        void Add (Room room);

    }
}
