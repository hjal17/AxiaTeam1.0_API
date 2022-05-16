using AxiaTeam1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Data.EmployeeEquipeRepository
{
    public class EmployeeEquipeRepository : IEmployeeEquipeRepository
    {
        private readonly DataContext _eeContext;

        public EmployeeEquipeRepository(DataContext dataContext)
        {
            _eeContext = dataContext;
        }
        public EmployeeEquipe create(EmployeeEquipe e)
        {
            _eeContext.employeeEquipes.Add(e);
            _eeContext.SaveChanges();
            return e;
        }

       
    }
}
