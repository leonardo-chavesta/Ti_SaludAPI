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
    }
}
