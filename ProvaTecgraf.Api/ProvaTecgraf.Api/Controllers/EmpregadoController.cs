﻿using Microsoft.AspNetCore.Http;
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
    [ApiController]
    [Route("[controller]")]
    public class EmpregadoController : ControllerBase
    {
        private readonly IEmpregadoService _empregadoService;

        public EmpregadoController(IEmpregadoService empregadoService)
        {
            _empregadoService = empregadoService;
        }

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

        [HttpGet]
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
