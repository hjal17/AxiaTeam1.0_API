using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Models
{
    public class Equipe
    {
        public int Id { get; set; }
        public string name { get; set; }
        public ICollection<EmployeeEquipe> employeeEquipes { get; set; }


    }
}
