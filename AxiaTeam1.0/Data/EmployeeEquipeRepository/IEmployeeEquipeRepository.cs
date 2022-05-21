using AxiaTeam1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Data.EmployeeEquipeRepository
{
   public interface IEmployeeEquipeRepository
    {
      EmployeeEquipe create(EmployeeEquipe e);
        public List<User> getEquipeMembre(int equipeId);
        public List<Equipe> getUserEquipe(int userId);
        public EmployeeEquipe changeEmployeeEquipe(int employeeId,int EquipeId, int newEquipeId);
        public void DeleteEmployeFromEquipe(int employeeId,int equipeId);
    }
}
