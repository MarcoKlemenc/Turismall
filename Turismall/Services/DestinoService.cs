using System.Collections.Generic;
using Turismall.Data;
using Turismall.Models;

namespace Turismall.Services
{
    public class DestinoService : IDestinoService
    {
        private readonly IRepository<Destino> _repository;

        public DestinoService(IRepository<Destino> repository)
        {
            _repository = repository;
        }

        public List<Destino> GetAll()
        {
            return _repository.GetAll();
        }

        public Destino GetById(int? destinoId)
        {
            return destinoId == null ? null : _repository.GetOne(x => x.ID == destinoId);
        }
    }
}
