using System.Collections.Generic;
using Turismall.Models;

namespace Turismall.Services
{
    public interface IViajeService
    {
        List<Viaje> GetByUser(string userId);
        Viaje GetById(int? viajeId);
        void Create(Viaje viaje);
        void Update(Viaje viaje);
        void Save();
    }
}
