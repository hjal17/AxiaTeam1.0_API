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
        [HttpGet("projectId={id}")]
        public ActionResult getByProjectId(int id)
        {
            var backLog = _backlogRepository.getProjectBacklog(id);
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

        [HttpPut("edit/{id}")]
        public IActionResult updateUser(int id, BackLog b)
        {
            try
            {
                if (id != b.Id)
                    return BadRequest("user ID mismatch");

                var userToUpdate = _backlogRepository.Get(id);

                if (userToUpdate == null)
                    return NotFound($"backlog with Id = {id} not found");

                return Ok(_backlogRepository.editBackLog(b));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult deleteBacklog(int id)
        {
            try
            {
                var backlogToDelete = _backlogRepository.Get(id);

                if (backlogToDelete == null)
                {
                    return NotFound($"Backlog with Id = {id} not found");
                }
                _backlogRepository.delete(id);

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
