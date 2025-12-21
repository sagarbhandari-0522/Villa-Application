using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.Application.Interface
{
    public interface IUnitOfWork
    {
        public IRoomRepository roomRepository { get;  }
        public IVillaNumberRepository villaNumberRepository { get; }
        public void Commit();
    }
}
