using System;
using System.Collections.Generic;
using Turismall.Models;

namespace Turismall.Data
{
    public interface INotaRepository : IDisposable
    {
        IEnumerable<Nota> GetNotasByViaje(int? ViajeId);
        Nota GetNotaByID(int? NotaId);
        void InsertNota(Nota Nota);
        void DeleteNota(int NotaID);
        void UpdateNota(Nota Nota);
        void Save();
    }
}
