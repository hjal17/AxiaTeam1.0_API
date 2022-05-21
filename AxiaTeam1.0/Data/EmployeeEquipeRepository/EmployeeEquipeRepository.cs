using AxiaTeam1._0.Models;
using Microsoft.EntityFrameworkCore;
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
        public EmployeeEquipe changeEmployeeEquipe(int employeeId, int equipeId,int newEquipeId)
        {
            var employeeEquipe = _eeContext.employeeEquipes.FirstOrDefault(e => e.EquipeId == equipeId || e.userId == employeeId);
            employeeEquipe.EquipeId = newEquipeId;
            _eeContext.SaveChanges();
            return (employeeEquipe);
        }


        public void DeleteEmployeFromEquipe(int employeeId, int equipeId)
        {
            var employeeEquipe = _eeContext.employeeEquipes.FirstOrDefault(e => e.EquipeId == equipeId || e.userId == employeeId);
            _eeContext.employeeEquipes.Remove(employeeEquipe);
            _eeContext.SaveChanges();
        }

        public List<User> getEquipeMembre(int equipeId)
        {
            return _eeContext.Users.Where(u => u.EmployeeEquipes.Any(e => e.EquipeId == equipeId)).ToList();
        }

        public List<Equipe> getUserEquipe(int userId)
        {
            return _eeContext.equipes.Where(e => e.EmployeeEquipes.Any(u => u.userId == userId)).ToList();
        }

       
    }
}
