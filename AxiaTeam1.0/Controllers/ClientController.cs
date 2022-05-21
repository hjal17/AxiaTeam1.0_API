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
    [Route("api/client")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientRepository _repository;

        public ClientController(IClientRepository clientRepository)
        {
            _repository = clientRepository;
        }


        [HttpPost("create")]
        public IActionResult Register(Client c)
        {

            var client = new Models.Client
            {
                Name = c.Name,
                Description = c.Description,
                Website = c.Website,
                Phone = c.Phone,
                Fax = c.Fax,
                Country =c.Country,
                State = c.State,
                Adress = c.Adress
              
            };
            return Created("succes", _repository.Create(client));

        }

        [HttpGet]
        public IActionResult allUsers()
        {
            try
            {
  
                var users = _repository.getAll();

                return Ok(users);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Client(int id)
        {

            var client = _repository.GetById(id);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

        [HttpPut("{id}")]
        public IActionResult updateClient(int id, Client c)
        {
            try
            {
                if (id != c.Id)
                    return BadRequest("user ID mismatch");

                var clientToUpdate = _repository.GetById(id);

                if (clientToUpdate == null)
                    return NotFound($"client with Id = {id} not found");

                return Ok(_repository.EditClient(c));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
            
        }


        [HttpDelete("{id}")]
        public  IActionResult DeleteClient(int id)
        {
            try
            {
                var clienToDelete =  _repository.GetById(id);

                if (clienToDelete == null)
                {
                    return NotFound($"client with Id = {id} not found");
                }
                _repository.Delete(id);

                return Ok(new { message = "succes" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
        [HttpGet("{id}/projects")]

        public IActionResult getClientProjects(int id)
        {
            var projects = _repository.getClientProject(id);
            return Ok(projects);
        }

    }
}
