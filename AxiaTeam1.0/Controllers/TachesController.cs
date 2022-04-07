using AxiaTeam1._0.Data.Tache;
using AxiaTeam1._0.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AxiaTeam1._0.Controllers
{
    [Route("api/taches")]
    [ApiController]
    public class TachesController : ControllerBase
    {
        private readonly ITacheRepository _tacheRepository;

        public TachesController( ITacheRepository tacheRepository)
        {
            _tacheRepository = tacheRepository;
        }

        // GET: api/<TachesController>
        [HttpGet]
        public IActionResult Get()
        {
            var taches = _tacheRepository.GetAll();
            return Ok(taches);
        }

        // GET api/<TachesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tache = _tacheRepository.Get(id);
            if (tache == null)
                return NotFound();
            return Ok(tache);
        }

        [HttpPost("create")]
        public IActionResult Create(TTache t)
        {
            var tache = new TTache
            {
                Description = t.Description,
                Name = t.Name,
                status = t.status,
                Periority = t.Periority,
                DateDebut = t.DateDebut,
                DateLimite = t.DateLimite,
                Avancement = t.Avancement,
                TempEstimer = t.TempEstimer
            };
            return Created("succes ", _tacheRepository.Create(tache));
        }

    }
}
