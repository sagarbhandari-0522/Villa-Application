using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Application.Interface;
using Villa.Domain.Entities;
using Villa.Infrastructure.Data;

namespace Villa.Infrastructure.Repository
{

    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _context;
        public VillaNumberRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public void Add(VillaNumber villaNumber)
        {
            _context.Add(villaNumber);
        }

        public void Remove(VillaNumber villaNumber)
        {
            _context.Remove(villaNumber);
        }

        public void Update(VillaNumber villaNumber)
        {
            _context.Update(villaNumber);
        }
    }
}
