using AxiaTeam1._0.Data.EmployeeEquipeRepository;
using AxiaTeam1._0.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Controllers
{
    [Route("api/employeeEquipe")]
    [ApiController]
    public class EmployeeEquipeConteoller : ControllerBase
    {
        private IEmployeeEquipeRepository _repository;

        public EmployeeEquipeConteoller(IEmployeeEquipeRepository equipeRepository)
        {
            _repository = equipeRepository;
        }


     

        [HttpPost("create")]
        public IActionResult create(EmployeeEquipe e)
        {
            var employeeEquipe = new EmployeeEquipe
            {
                userId = e.userId,
                EquipeId = e.EquipeId
            };
            return Created("succes", _repository.create(employeeEquipe));
        }

        [HttpGet("equipeMembre/{equipeId}")]
        public IActionResult getEquipeMembre(int equipeId)
        {
            var users = _repository.getEquipeMembre(equipeId);
            return Ok(users);
        }

        [HttpGet("{userId}/equipeMembre")]
        public IActionResult getMembreEquipe(int userId)
        {
            var equipe = _repository.getUserEquipe(userId);
            return Ok(equipe);
        }
    }
}
