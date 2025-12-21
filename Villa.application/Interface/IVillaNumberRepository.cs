using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Domain.Entities;

namespace Villa.Application.Interface
{
    public interface IVillaNumberRepository: IRepository<VillaNumber>
    {
        void Remove(VillaNumber room);
        void Update(VillaNumber room);
        void Add(VillaNumber room);
    }
}
