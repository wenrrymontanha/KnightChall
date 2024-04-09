using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KnightChall.Domain.Interfaces;
using KnightChall.Service.Services;
using Microsoft.AspNetCore.Identity;
using KnightChall.Domain.DBModels;
using KnightChall.Service.Validator;
using MongoDB.Bson;
using KnightChall.Domain.DTO;
using Microsoft.AspNetCore.Cors;
using System.Net;

namespace KnightChall.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class KnightsController : ControllerBase
    {
        private IKnightService _KnightService;

        public KnightsController(IKnightService baseKnightService)
        {
            _KnightService = baseKnightService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] DTOKnight knight)
        {
            if (knight == null)
                return NotFound();

            return Execute(() => _KnightService.Add(knight));
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] DTOKnightName dtoKnightName)
        {
            if (dtoKnightName.name == "")
                return NotFound();

            return Execute(() =>
            {
                Knight knight = _KnightService.Update(id, dtoKnightName.name);
                if (knight._id == null) return NotFound();
            return true;
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (id == "")
                return NotFound();

            Execute(() =>
            {
                _KnightService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult GetKnights([FromQuery(Name = "filter")] string filter = "")
        {
            if (!string.IsNullOrWhiteSpace(filter) && filter.ToLower() == "heroes")
            {
                // Se o filtro for "heroes", retorna a lista de heróis
                return Execute(() => _KnightService.Get(filter));
            }
            else
            {
                // Caso contrário, retorna a lista de cavaleiros
                return Execute(() => _KnightService.Get("knights"));
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            // Retorna o cavaleiro por ID
            return Execute(() => _KnightService.GetId(id));
        }


        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
