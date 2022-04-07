using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProvaTecgraf.Application.Contract;
using ProvaTecgraf.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaTecgraf.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmpregadoController : ControllerBase
    {
        private readonly IEmpregadoService _empregadoService;

        public EmpregadoController(IEmpregadoService empregadoService)
        {
            _empregadoService = empregadoService;
        }
        /// <summary>
        /// Método para criação dos colaboradores
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Retorna o empregado após inclusão no banco de dados.</returns>
        [HttpPost]
        public async Task<IActionResult> CriaEmpregado(EmpregadoDto model)
        {
            try
            {
                var empregado = await _empregadoService.AddEmpregado(model);
                if (empregado == null) return NoContent();

                return Ok(empregado);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Post: Erro ao criar empregado. Erro: {ex.Message}");
            }
        }
        /// <summary>
        /// Método para alteração em qualquer dado do colaborador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>Retorna o colaborador escolhido pelo guid e seus dados alterados no banco de dados.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizaEmpregado(Guid id, EmpregadoUpdateDto model)
        {
            try
            {
                var empregado = await _empregadoService.UpdateEmpregado(id, model);
                if (empregado == null) return NoContent();

                return Ok(empregado);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Post: Erro ao atualizar o empregado. Erro: {ex.Message}");
            }
        }
        /// <summary>
        /// Método para listar todos os empregados ou algum, dependendo do termo que entrar, podendo ser FirstName, SecondName ou  Email.
        /// </summary>
        /// <param name="termo"></param>
        /// <returns>Retorna uma lista todos os empregados ou algum, dependendo do termo que entrar, podendo ser FirstName, SecondName ou  Email.</returns>
        [HttpGet("ListaEmpregados")]
        public async Task<IActionResult> ListaEmpregados(string termo)
        {
            try
            {
                var empregados = await _empregadoService.GetAllEmpregados(termo);
                if (empregados == null) return null;

                return Ok(empregados);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Post: Erro ao listar os empregados. Erro: {ex.Message}");
            }
        }
    }
}
