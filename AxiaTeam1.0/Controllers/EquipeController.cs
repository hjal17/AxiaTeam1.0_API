using AxiaTeam1._0.Data.EquipeRepository;
using AxiaTeam1._0.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Controllers
{
    [Route("api/equipe")]
    [ApiController]
    public class EquipeController : ControllerBase
    {
        private readonly IEquipeRepository repository;
        public EquipeController( IEquipeRepository equipeRepository )
        {
            repository = equipeRepository;
        }

        [HttpPost("create")]
        public IActionResult create(Equipe e)
        {
            var equipe = new Equipe
            {
                name = e.name
            };
            return Created("succes ", repository.Create(equipe));
        }
        [HttpGet()]
        public IActionResult get()
        {
            var equipe = repository.getAll();
            return Ok(equipe);
        }



        [HttpDelete("{id}")]
        public IActionResult deleteEquipe(int id)
        {
            try
            {
                var equipe = repository.GetById(id);

                if (equipe == null)
                {
                    return NotFound($"equipe with Id = {id} not found");
                }
                repository.Delete(id);

                return Ok(new { message = "succes" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }


    }
}
