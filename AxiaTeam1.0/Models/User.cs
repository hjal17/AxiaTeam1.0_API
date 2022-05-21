using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace AxiaTeam1._0.Models
{
    public class User
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Role { get; set; }
        [JsonIgnore] public string Password { get; set; }

        public List<Project> Projects { get; set; }
        public List<TacheAFait> tacheAFait { get; set; }


        public  ICollection<EmployeeEquipe> EmployeeEquipes { get; set; }

    }
}
