using ProvaTecgraf.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecgraf.Application.Contract
{
    public interface IEmpregadoService
    {
        Task<EmpregadoDto> AddEmpregado(EmpregadoDto model);
        Task<EmpregadoDto> UpdateEmpregado(Guid id, EmpregadoUpdateDto model);
        Task<EmpregadoDto[]> GetAllEmpregados();
    }
}
