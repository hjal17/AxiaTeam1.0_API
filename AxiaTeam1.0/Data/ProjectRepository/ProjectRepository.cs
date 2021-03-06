using AxiaTeam1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Data
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _projectContext;

        public ProjectRepository(DataContext projectContext)
        {
            _projectContext = projectContext;
        }
        public Project create(Project p)
        {
            _projectContext.Projects.Add(p);
            p.Id = _projectContext.SaveChanges();
            return p;

        }

     
            public void Delete(int id)
            {
                var project = _projectContext.Projects.FirstOrDefault(p => p.Id == id);
                _projectContext.Projects.Remove(project);
                _projectContext.SaveChanges();
            }
        

        public Project Get(int id)
        {
            return _projectContext.Projects.FirstOrDefault(p => p.Id == id);
        }

        public List<Project> GetAll()
        {
            return _projectContext.Projects.ToList();
        }

        public List<Project> GetAll(int equipeId)
        {
            return _projectContext.Projects.Where(p=>p.EquipeId==equipeId).ToList();
        }
    }
}
