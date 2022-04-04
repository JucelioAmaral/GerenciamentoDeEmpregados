using AutoMapper;
using ProvaTecgraf.Application.Contract;
using ProvaTecgraf.Application.Dto;
using ProvaTecgraf.Domain;
using ProvaTecgraf.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecgraf.Application
{
    public class EmpregadoService : IEmpregadoService
    {
        private readonly IMapper _mapper;
        private readonly IGeralRepository _geralRepo;

        public EmpregadoService(IMapper mapper, IGeralRepository geralRepo)
        {
            _mapper = mapper;
            _geralRepo = geralRepo;
        }

        public async Task<EmpregadoDto> AddEmpregado(EmpregadoDto model)
        {            
            var empregado = _mapper.Map<Empregado>(model);
            empregado.Id = Guid.NewGuid();
            _geralRepo.Add<Empregado>(empregado);
            if (await _geralRepo.SaveChangesAsync())
            {
                return _mapper.Map<EmpregadoDto>(empregado);
            }
            return null;
        }

        public Task<EmpregadoDto> UpdateEmpregado(EmpregadoDto empregado)
        {
            throw new NotImplementedException();
        }

        public Task<EmpregadoDto[]> GetAllEmpregados()
        {
            throw new NotImplementedException();
        }
    }
}
