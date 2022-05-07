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
    [Route("api/backlog")]
    [ApiController]
    public class BackLogController : ControllerBase
    {
        private readonly IBackLogRepository _backlogRepository;

        public BackLogController(IBackLogRepository backLogRepository)
        {
            _backlogRepository = backLogRepository;
        }


        [HttpGet("{id}")]
        public ActionResult getBackLog(int id)
        {
            var backLog = _backlogRepository.Get(id);
            if (backLog == null)
                return NotFound();
            return Ok(backLog);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(BackLog b)
        {


            var backLog = new BackLog
            {
               Version = b.Version,
               Description = b.Description,
               ProjectId = b.ProjectId

            };

            return Created("succes ", _backlogRepository.create(backLog));
        }

        
      
    }
}
