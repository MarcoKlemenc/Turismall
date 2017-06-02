using System.Collections.Generic;
using Turismall.Data;
using Turismall.Models;

namespace Turismall.Services
{
    public class ViajeService : IViajeService
    {
        private readonly IRepository<Viaje> _repository;

        public ViajeService(IRepository<Viaje> repository)
        {
            _repository = repository;
        }

        public void Create(Viaje viaje)
        {
            _repository.Insert(viaje);
        }

        public Viaje GetById(int? notaId)
        {
            return notaId == null ? null : _repository.GetOne(x => x.ID == notaId);
        }

        public List<Viaje> GetByUser(string userId)
        {
            return _repository.GetSorted(x => x.Usuario == userId, x => x.FechaInicio);
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(Viaje viaje)
        {
            _repository.Update(viaje);
        }
    }
}
