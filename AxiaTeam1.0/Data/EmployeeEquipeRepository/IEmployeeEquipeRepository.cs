using AxiaTeam1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Data.EmployeeEquipeRepository
{
    interface IEmployeeEquipeRepository
    {
        EmployeeEquipe create(EmployeeEquipe e);
       
    }
}
