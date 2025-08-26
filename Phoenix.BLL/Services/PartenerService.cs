using Phoenix.BLL.Models;
using Phoenix.BLL.Interfaces;
using Phoenix.DAL.Entities;
using Phoenix.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.BLL.Services
{
    public class PartenerService:IPartenerService
    {
        private readonly IPartenerRepository _repository;
        public PartenerService(IPartenerRepository repository)
        {
            _repository = repository;
        }
        public List<Partener> GetAll()
        {
            var entities = _repository.GetAll();
            return entities.Select(e => new Partener
            {
                Id = e.Id,
                Denumire = e.Denumire
            }).ToList();

        }

        public Partener GetById(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) return null;

            return new Partener
            {
                Id = entity.Id,
                Denumire = entity.Denumire
            };
        }
        public void Add(Partener partener)
        {
            if (string.IsNullOrWhiteSpace(partener.Denumire))
                throw new ArgumentException("Denumirea nu poate fi goală");

            var entity = new PartenerEntity
            {
                Denumire = partener.Denumire
            };

            _repository.Add(entity);
        }

        public void Update(Partener partener)
        {
            var entity = new PartenerEntity
            {
                Id = partener.Id,
                Denumire = partener.Denumire
            };
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        private Partener ToModel(PartenerEntity entity)
        {
            return new Partener
            {
                Id = entity.Id,
                Denumire = entity.Denumire
            };
        }

        private PartenerEntity ToEntity(Partener model)
        {
            return new PartenerEntity
            {
                Id = model.Id,
                Denumire = model.Denumire
            };
        }


    }
}
