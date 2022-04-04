using Microsoft.EntityFrameworkCore;
using ProvaTecgraf.Domain;
using ProvaTecgraf.Infrastructure.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaTecgraf.Infrastructure
{
    public class EmpregadoRepository : IEmpregadoRepository
    {
        private readonly TecgrafContext _context;

        public EmpregadoRepository(TecgrafContext context)
        {
            _context = context;
        }

        public async Task<Empregado[]> GelAllEmpregados()
        {
            IQueryable<Empregado> query = _context.tblEmpregado;
            query = query.AsNoTracking().OrderBy(e => e.Id);
            return query.ToArray();
        }

        public async Task<Empregado> GelEmpregadoById(Guid id)
        {
            IQueryable<Empregado> query = _context.tblEmpregado;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == id);
            return query.FirstOrDefault();
        }

        public async Task<Empregado[]> FindEmpregadosByTerm(string termo)
        {
            IQueryable<Empregado> query = _context.tblEmpregado;
            query = query.AsNoTracking()
                         .Where(e => e.FirstName.ToLower().Contains(termo) ||
                                     e.SecondName.ToLower().Contains(termo) ||
                                     e.Email.ToLower().Contains(termo) ||
                                     termo == null)
                         .OrderBy(e => e.Id);

            return query.ToArray();
        }
    }
}
