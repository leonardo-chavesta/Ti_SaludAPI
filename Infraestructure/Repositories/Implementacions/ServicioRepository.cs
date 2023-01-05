using Domain;
using Infraestructure.Context;
using Infraestructure.Repositories.Abstracions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories.Implementacions
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly ApplicationDbContext _context;
        public ServicioRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<Servicio?> ActivarXDesactivar(int id)
        {
            var model = await _context.Servicios.FindAsync(id);
            if(model != null)
            {
                model.Estado = (model.Estado == 0) ? 1 : 0;

                _context.Servicios.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Servicio?> Buscar(int id)
        {
            var response = await _context.Servicios.FirstOrDefaultAsync(e => e.Id == id);

            return response;
        }

        public async Task<Servicio> CrearServicio(Servicio entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Servicio?> EditarServicio(int id, Servicio entity)
        {
            var model = await _context.Servicios.FindAsync(id);
            if(model != null)
            {
                model.Nombre = entity.Nombre;
                model.Codigo = entity.Codigo;

                _context.Servicios.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<IList<Servicio>> ListarServicio()
        {
           var response = await _context.Servicios.OrderByDescending(e => e.Id).ToListAsync();

           return response;
        }
    }
}
