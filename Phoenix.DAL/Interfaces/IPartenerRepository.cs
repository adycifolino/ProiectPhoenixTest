using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Phoenix.DAL.Entities;
namespace Phoenix.DAL.Interfaces
{
    public interface IPartenerRepository
    {
        List<PartenerEntity> GetAll();
        PartenerEntity GetById(int id);
        void Add(PartenerEntity p);
        void Update(PartenerEntity p);
        void Delete(int id);
    }
}
