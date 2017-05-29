using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Turismall.Models;

namespace Turismall.Services
{
    public interface INotaService
    {
        List<Nota> GetByViaje(int? viajeId);
        Nota GetById(int? notaId);
        DateTime GetMinFecha(int? viajeId);
        DateTime GetMaxFecha(int? viajeId);
        void Create(Nota nota);
        void Update(Nota nota);
        void Save();
        void UpdateFechas(Nota nota);
        void UploadFile(Nota nota, IFormFileCollection files);
    }
}
