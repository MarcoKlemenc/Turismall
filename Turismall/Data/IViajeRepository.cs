using System;
using System.Collections.Generic;
using Turismall.Models;

namespace Turismall.Data
{
    public interface IViajeRepository : IDisposable
    {
        IEnumerable<Viaje> GetViajes();
        IEnumerable<Viaje> GetViajesByUser(String userId);
        Viaje GetViajeByID(int? ViajeId);
        void InsertViaje(Viaje Viaje);
        void DeleteViaje(int ViajeID);
        void UpdateViaje(Viaje Viaje);
        void Save();
    }
}
