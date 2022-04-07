using AxiaTeam1._0.Data;
using AxiaTeam1._0.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController( IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet("{id}")]
        public ActionResult Project(int id)
        {
            var project = _projectRepository.Get(id);
            if (project == null)
                return NotFound();
            return Ok(project);
        }



        [HttpPost("create")]
        public IActionResult Create(Project p)
        {
            var project = new Project
            {
                Name = p.Name,
                Description = p.Description,
                Version = p.Version,
                DateDebut = p.DateDebut,
                DateLimite = p.DateLimite,
                TempEstimer = p.TempEstimer
            };
            return Created("succes", _projectRepository.create(project));
        }

        [HttpGet]
        public ActionResult get()
        {
            var project = _projectRepository.GetAll();
            return Ok(project);
        }



    }
}
