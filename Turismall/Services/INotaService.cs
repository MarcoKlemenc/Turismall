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
        List<Destino> GetDestinos();
        String GetNombreDestino(int? destinoId);
        void Create(Nota nota);
        void Update(Nota nota);
        void Save();
        string GetViajeName(int? idViaje);
        void UpdateFechas(Nota nota);
        void UploadFile(Nota nota, IFormFileCollection files);
    }
}
