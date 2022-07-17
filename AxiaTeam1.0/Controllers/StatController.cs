using AxiaTeam1._0.Data;
using AxiaTeam1._0.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Controllers
{
    [Route("api/stat")]
    [ApiController]
    public class StatController : ControllerBase
    {
        private readonly DataContext _context;

        public StatController(DataContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        public ActionResult getAdminStat(int id)
        {
            var _users = _context.Users.Select(u => u.Id).Count();
            var _teams = _context.equipes.Select(e => e.Id).Count();
            var _projects = _context.Projects.Select(p => p.Id).Count();
            var _clients = _context.Clients.Select(c => c.Id).Count();
           // var _finishedProject = (from x in _context.Projects where x.EquipeId == 2 select x.Id).Count();
            var stat = new AdminStatDto
            {
                users = _users,
                teams =_teams,
                projects =_projects,
                clients =_clients
            
            };

            return Ok(stat);
        }


    }
}
