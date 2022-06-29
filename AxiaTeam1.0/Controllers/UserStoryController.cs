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
    [Route("api/userstory")]
    [ApiController]
    public class UserStoryController : ControllerBase
    {
        private readonly IUserStoryRepository _userStoryRepository;

        public UserStoryController(IUserStoryRepository userStoryRepository)
        {
            _userStoryRepository = userStoryRepository;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> getUs(int id)
        {

            var userStory = _userStoryRepository.Get(id);
            if (userStory == null)
                return NotFound();
            return Ok(userStory);
        }



        [HttpPost("create")]
        public async Task<IActionResult> Create(UserStory us)
        {


            var userStory = new UserStory
            {
                Name = us.Name,
                Description = us.Description,
                TemEstimer = us.TemEstimer,
                BackLogId = us.BackLogId

            };

            return Created("succes ", _userStoryRepository.create(userStory));
        }

        [HttpGet("backlog/{id}")]
        public ActionResult getAll(int id)
        {
            var project = _userStoryRepository.GetAll(id);
            return Ok(project);
        }
    }
}
