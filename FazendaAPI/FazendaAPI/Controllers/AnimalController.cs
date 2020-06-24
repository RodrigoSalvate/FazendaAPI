using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Negocio._Util;
using Negocio.DTOs;
using Negocio.Serviço.Interface;

namespace FazendaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnimalController : Controller
    {
        private IServiceBase<AnimalDTO> _animalService;

        public AnimalController(IServiceBase<AnimalDTO> animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ParametrosBusca parametrosBusca)
        {
            return Ok(_animalService.ObterTodos(parametrosBusca));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
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

        [HttpPut]
        public IActionResult Put(AnimalDTO animalDTO)
        {
            if (animalDTO == null) return BadRequest();

            var validacao = _animalService.Validar(animalDTO);

            if (!validacao.Any())
                return new ObjectResult(_animalService.Atualizar(animalDTO));

            return BadRequest(validacao);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _animalService.Remover(id);
            return NoContent();
        }
        [HttpDelete]
        public IActionResult Delete(AnimalDTO animalDTO)
        {
            _animalService.Remover(animalDTO);
            return NoContent();
        }
    }
}