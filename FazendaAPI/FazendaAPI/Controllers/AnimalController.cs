using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Negocio._Util;
using Negocio.DTOs;
using Negocio.HATOAS;
using Negocio.Serviço.Interface;
using Swashbuckle.AspNetCore.Annotations;

namespace FazendaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnimalController : Controller
    {
        private IServiceBase<AnimalDTO> _animalService;
        private readonly IUrlHelper _urlHelper;

        public AnimalController(IServiceBase<AnimalDTO> animalService, IUrlHelper urlHelper)
        {
            _animalService = animalService;
            _urlHelper = urlHelper;
        }

        [HttpGet(Name = "GetAnimais")]
        [SwaggerResponse((200))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        // [SwaggerResponse(401)]
        public IActionResult Get([FromQuery] ParametrosBusca parametrosBusca)
        {
            var animais = _animalService.ObterTodos(parametrosBusca).ToList();

            if (!animais.Any())
                return NoContent();

            animais.ForEach(x => GerarLinks(x));

            var resultado = new ColecaoRecursos<AnimalDTO>(animais);
            resultado.links.Add(new Link(_urlHelper.Link("GetAnimais", new { }), rel: "self", metodo: "GET"));
            resultado.links.Add(new Link(_urlHelper.Link("PostAnimal", new { }), rel: "post-animal", metodo: "POST"));

            return Ok(resultado);
        }

        [HttpGet("{id}", Name = "GetAnimal")]
        [SwaggerResponse((200), Type = typeof(AnimalDTO))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        //[SwaggerResponse(401)]
        public IActionResult Get(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var animal = _animalService.ObterPorId(id);

            if (animal != null)
                return NoContent();

            return Ok(animal);
        }

        [HttpPost(Name = "PostAnimal")]
        [SwaggerResponse((201), Type = typeof(AnimalDTO))]
        [SwaggerResponse(400)]
        //[SwaggerResponse(401)]
        public IActionResult Post(AnimalDTO animalDTO)
        {
            if (animalDTO == null) return BadRequest();

            var validacao = _animalService.Validar(animalDTO);

            if (!validacao.Any())
            {
                return new ObjectResult(_animalService.Inserir(animalDTO));
            }

            return BadRequest(validacao);
        }

        [HttpPut(Name = "PutAnimal")]
        [SwaggerResponse((202), Type = typeof(AnimalDTO))]
        [SwaggerResponse(400)]
        //[SwaggerResponse(401)]
        public IActionResult Put([FromQuery] Guid id, [FromBody]AnimalDTO animalDTO)
        {
            if (animalDTO == null || id == Guid.Empty) return BadRequest();

            var validacao = _animalService.Validar(animalDTO);

            animalDTO.Id = id;

            if (!validacao.Any())
                return new ObjectResult(_animalService.Atualizar(animalDTO));

            return BadRequest(validacao);
        }

        [HttpDelete("{id}", Name = "DeleteAnimal")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        //[SwaggerResponse(401)]
        public IActionResult Delete(Guid id)
        {
            _animalService.Remover(id);
            return NoContent();
        }
        [HttpDelete]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        //[SwaggerResponse(401)]
        public IActionResult Delete(AnimalDTO animalDTO)
        {
            _animalService.Remover(animalDTO);
            return NoContent();
        }

        private void GerarLinks(AnimalDTO animalDTO)
        {
            animalDTO.links.Add(new Link(_urlHelper.Link("GetAnimal", new { id = animalDTO.Id }), rel: "self", metodo: "GET"));
            animalDTO.links.Add(new Link(_urlHelper.Link("PutAnimal", new { id = animalDTO.Id }), rel: "update-animal", metodo: "PUT"));
            animalDTO.links.Add(new Link(_urlHelper.Link("DeleteAnimal", new { id = animalDTO.Id }), rel: "delete-animal", metodo: "DELETE"));
        }
    }
}