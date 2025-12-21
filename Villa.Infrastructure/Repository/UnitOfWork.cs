using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Application.Interface;
using Villa.Infrastructure.Data;

namespace Villa.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRoomRepository roomRepository { get;  }
        public IVillaNumberRepository villaNumberRepository { get; }
    

        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            roomRepository=new RoomRepository(_context);
            villaNumberRepository=new VillaNumberRepository(_context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
