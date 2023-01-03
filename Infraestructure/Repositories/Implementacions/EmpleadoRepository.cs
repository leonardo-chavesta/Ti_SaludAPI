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
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Empleado?> ActivarODesactivar(int id)
        {
            throw new NotImplementedException();
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
            var response = await _context.Empleados.OrderByDescending(e => e.Id).ToListAsync();

            return response;   
        }
    }
}
