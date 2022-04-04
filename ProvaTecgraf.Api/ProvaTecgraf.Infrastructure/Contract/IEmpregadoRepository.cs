using ProvaTecgraf.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecgraf.Infrastructure
{
    public interface IEmpregadoRepository
    {
        Task<Empregado[]> GelAllEmpregados();
        Task<Empregado> GelEmpregadoById(Guid id);
    }
}
