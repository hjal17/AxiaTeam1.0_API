using AxiaTeam1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Data
{
   public interface IProjectRepository
    {
        Project create(Project p);
        Project Get(int id);
       List< Project> GetAll();
        
    }
}
