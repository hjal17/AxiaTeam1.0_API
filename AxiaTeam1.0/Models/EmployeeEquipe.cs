using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Models
{
    public class EmployeeEquipe
    {
        public int userId { get; set; }
        public User user { get; set; }

        public int EquipeId { get; set; }
        public Equipe equipe { get; set; }
    }
}
