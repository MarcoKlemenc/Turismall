using System.Collections.Generic;
using Turismall.Models;

namespace Turismall.Services
{
    public interface IDestinoService
    {
        List<Destino> GetAll();
        Destino GetById(int? destinoId);
    }
}
