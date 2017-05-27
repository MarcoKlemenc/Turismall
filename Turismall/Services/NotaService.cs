using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using Turismall.Data;
using Turismall.Models;

namespace Turismall.Services
{
    public class NotaService : INotaService
    {
        private readonly INotaRepository _repository;
        private IHostingEnvironment _env;

        public NotaService(INotaRepository repository, IHostingEnvironment env)
        {
            _repository = repository;
            _env = env;
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

        public void UploadFile(Nota nota, IFormFileCollection files)
        {
            var folder = Path.Combine("uploads", nota.ViajeID.ToString());
            var destination = Path.Combine(_env.WebRootPath, folder);
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    if (!Directory.Exists(destination))
                    {
                        Directory.CreateDirectory(destination);
                    }
                    var name = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".jpg";
                    using (var fileStream = new FileStream(Path.Combine(destination, name), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                        nota.Foto = Path.Combine(folder, name);
                    }
                }
            }
        }
    }
}
