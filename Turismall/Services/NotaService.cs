using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismall.Data;
using Turismall.Models;

namespace Turismall.Services
{
    public class NotaService : INotaService
    {
        private readonly INotaRepository _repository;

        public NotaService(INotaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Nota> GetByViaje(int? viajeId)
        {
            if (viajeId == null)
            {
                return null;
            }
            return _repository.GetSeveralByPredicate(x => x.ViajeID == viajeId);
        }

        public Nota GetById(int? notaId)
        {
            if (notaId == null)
            {
                return null;
            }
            return _repository.GetByPredicate(x => x.ID == notaId);
        }

        public void Create(Nota nota)
        {
            _repository.Insert(nota);
        }

        public void Update(Nota nota)
        {
            _repository.Update(nota);
        }

        public void Save()
        {
            _repository.Save();
        }
    }
}
