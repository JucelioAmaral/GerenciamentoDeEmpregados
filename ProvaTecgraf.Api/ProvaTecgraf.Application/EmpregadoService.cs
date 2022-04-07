using AutoMapper;
using ProvaTecgraf.Application.Contract;
using ProvaTecgraf.Application.Dto;
using ProvaTecgraf.Domain;
using ProvaTecgraf.Infrastructure;
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
        private readonly IEmpregadoRepository _empregadoRepo;

        public EmpregadoService(IMapper mapper, IGeralRepository geralRepo, IEmpregadoRepository empregadoRepo)
        {
            _mapper = mapper;
            _geralRepo = geralRepo;
            _empregadoRepo = empregadoRepo;
        }

        public async Task<EmpregadoDto> AddEmpregado(EmpregadoDto model)
        {
            var empregado = _mapper.Map<Empregado>(model);
            empregado.Id = Guid.NewGuid();
            empregado.UserId = model.UserdId;
            _geralRepo.Add<Empregado>(empregado);
            if (await _geralRepo.SaveChangesAsync())
            {
                return _mapper.Map<EmpregadoDto>(empregado);
            }
            return null;
        }

        public async Task<EmpregadoDto> UpdateEmpregado(Guid id, EmpregadoUpdateDto model)
        {
            var empregado = await _empregadoRepo.GelEmpregadoById(id);
            if (empregado == null) return null;

            model.Id = empregado.Id;
            _mapper.Map(model, empregado);

            _geralRepo.Update<Empregado>(empregado);

            if (await _geralRepo.SaveChangesAsync())
            {
                var empregadoReturn = await _empregadoRepo.GelEmpregadoById(id);
                return _mapper.Map<EmpregadoDto>(empregadoReturn);
            }
            return null;
        }

        public async Task<EmpregadoDto[]> GetAllEmpregados(string termo)
        {
            var empregados = await _empregadoRepo.FindEmpregadosByTerm(termo);
            if (empregados == null) return null;

            var resultado = _mapper.Map<EmpregadoDto[]>(empregados);
            return resultado;
        }
    }
}
