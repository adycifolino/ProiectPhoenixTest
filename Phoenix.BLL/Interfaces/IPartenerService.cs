using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoenix.DAL.Entities;
using Phoenix.BLL.Models;


namespace Phoenix.BLL.Interfaces
{
    public interface IPartenerService
    {
        List<Partener> GetAll();
        Partener GetById(int id);
        void Add(Partener partener);
        void Update(Partener partener);
        void Delete(int id);
    }
}
