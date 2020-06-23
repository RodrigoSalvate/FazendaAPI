﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Negocio.DTOs;
using Negocio.Serviço.Interface;

namespace FazendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : Controller
    {
        private IServiceBase<AnimalDTO> _animalService;

        public AnimalController(IServiceBase<AnimalDTO> animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_animalService.ObterTodos());
        }

        [HttpPost]
        public IActionResult Post(AnimalDTO animalDTO)
        {
            if (animalDTO == null) return BadRequest();

            var validacao = _animalService.Validar(animalDTO);

            if (!validacao.Any())
                return new ObjectResult(_animalService.Inserir(animalDTO));

            return BadRequest(validacao);
        }
    }
}