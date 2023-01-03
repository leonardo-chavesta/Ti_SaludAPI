using Domain;
using Infraestructure.Context;
using Infraestructure.Repositories.Abstracions;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories.Implementacions
{
    public class TipoEmpleadoRepository : ITipoEmpleadoRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoEmpleadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<TipoEmpleado>> ListaEmpleado()
         => await _context.TipoEmpleados.OrderByDescending(e => e.Id).ToListAsync();

        public async Task<TipoEmpleado> CrearTipoEmpleado(TipoEmpleado entity)
        {
            _context.TipoEmpleados.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TipoEmpleado?> EditTipoEmpleado(int id, TipoEmpleado entity)
        {
            var model = await _context.TipoEmpleados.FindAsync(id);
            if (model != null)
            {
                model.Nombre = entity.Nombre;
                model.Codigo= entity.Codigo;

                _context.TipoEmpleados.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<TipoEmpleado?> ActivarODesactivar(int id)
        {
            var model = await _context.TipoEmpleados.FindAsync(id);
            if (model != null)
            {
                model.Estado = (model.Estado == 0) ? 1 : 0;
                _context.TipoEmpleados.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<TipoEmpleado?> Buscar(int id)
         => await _context.TipoEmpleados.FindAsync(id);

        
    }
}
