using AxiaTeam1._0.Data;
using AxiaTeam1._0.Helpers;
using AxiaTeam1._0.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    { 
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;





        public ProjectController( IProjectRepository projectRepository, IUserRepository repository, JwtService jwtService) 
        {
            _projectRepository = projectRepository;
            _repository = repository;
            _jwtService = jwtService;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ProjectAsync(int id)
        {
         
            var project = _projectRepository.Get(id);
            if (project == null)
                return NotFound();
            return Ok(project);
        }



        [HttpPost("create")]
        public async Task<IActionResult> Create(Project p)
        {
            //var jwt = Request.Cookies["jwt"];
           // var token = _jwtService.Verify(jwt);
           // int userId = int.Parse(token.Issuer);
            var project = new Project
            {
                Name = p.Name,
                Description = p.Description,
                Version = p.Version,
                DateDebut = p.DateDebut,
                DateLimite = p.DateLimite,
                TempEstimer = p.TempEstimer,
                UserId = p.UserId,
                ClientId = p.ClientId

        };
           
            return Created("succes ", _projectRepository.create(project));
        }

        [HttpGet]
        public ActionResult get()
        {
            var project = _projectRepository.GetAll();
            return Ok(project);
        }

        [HttpGet("equipe/{id}")]
        public ActionResult get(int id)
        {
            var project = _projectRepository.GetAll(id);
            return Ok(project);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            try
            {
                var project = _projectRepository.Get(id);

                if (project == null)
                {
                    return NotFound($"project with Id = {id} not found");
                }
                _projectRepository.Delete(id);

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
