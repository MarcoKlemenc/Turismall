using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Turismall.Models;

namespace Turismall.Services
{
    public interface INotaService
    {
        IEnumerable<Nota> GetByViaje(int? viajeId);
        Nota GetById(int? notaId);
        void Create(Nota nota);
        void Update(Nota nota);
        void Save();
        void UploadFile(Nota nota, IFormFileCollection files);
    }
}
