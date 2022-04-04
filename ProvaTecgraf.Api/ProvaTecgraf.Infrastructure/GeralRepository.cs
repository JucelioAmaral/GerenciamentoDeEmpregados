using ProvaTecgraf.Infrastructure.Context;
using ProvaTecgraf.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecgraf.Infrastructure
{
    public class GeralRepository : IGeralRepository
    {
        private readonly TecgrafContext _context;

        public GeralRepository(TecgrafContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
