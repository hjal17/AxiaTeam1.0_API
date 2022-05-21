using AxiaTeam1._0.Data.EmployeeEquipeRepository;
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
    public class EmployeeEquipeConteoller : ControllerBase
    {
        private IEmployeeEquipeRepository _repository;

        public EmployeeEquipeConteoller(IEmployeeEquipeRepository equipeRepository)
        {
            _repository = equipeRepository;
        }

        [HttpGet("equipeMembre/{id}")]
        public IActionResult getEquipeMembre(int id)
        {
            var users = _repository.getEquipeMembre(id);
            return Ok(users);
        }
    }
}
