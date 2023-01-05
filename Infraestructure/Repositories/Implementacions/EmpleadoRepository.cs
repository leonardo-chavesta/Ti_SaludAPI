using Domain;
using Infraestructure.Context;
using Infraestructure.Repositories.Abstracions;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories.Implementacions
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Empleado?> ActivarODesactivar(int id)
        {
            var model = await _context.Empleados.FindAsync(id);
            if (model != null)
            {
                model.Estado = (model.Estado == 0 ) ? 1: 0;

                _context.Empleados.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Empleado?> Buscar(int id)
         => await _context.Empleados.Include(e => e.TipoEmpleado)
            .FirstOrDefaultAsync(e => e.Id == id);

        public async Task<Empleado> CrearEmpleado(Empleado entity)
        {
             _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Empleado?> EditEmpleado(int id, Empleado entity)
        {
            var model = await _context.Empleados.FindAsync(id);
            if (model != null)
            {
                model.Nombre = entity.Nombre;
                model.Apellido= entity.Apellido;    
                model.Direccion= entity.Direccion;
                model.Documento= entity.Documento;
                model.TipoEmpleadoId= entity.TipoEmpleadoId;

                _context.Empleados.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<IList<Empleado>> ListaEmpleado()
        {
            var response = await _context.Empleados.Include(e => e.TipoEmpleado).OrderByDescending(e => e.Id).ToListAsync();

            return response;   
        }


        public async Task<IList<Empleado>> ListarAsync(string nombre, string apellido, string tipoEmpleado)
        {
            
            var response = await _context.Empleados
                .Include(e => e.TipoEmpleado)
                .Where(e => (e.Estado == 1 ) &&
                            (string.IsNullOrWhiteSpace(tipoEmpleado) || e.TipoEmpleado.Nombre.ToUpper().Contains(tipoEmpleado.ToUpper())) &&
                            (string.IsNullOrWhiteSpace(nombre) || e.Nombre.ToUpper().Contains(nombre.ToUpper())) &&
                            (string.IsNullOrWhiteSpace(apellido) || e.Apellido.ToUpper().Contains(apellido.ToUpper()))
                    )
                    .ToListAsync();

            if (response == null)
            {
                return null;
            }

            return response;
        }
    }
}
