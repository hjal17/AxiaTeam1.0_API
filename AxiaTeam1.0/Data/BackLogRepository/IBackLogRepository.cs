using AxiaTeam1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Data
{
    public interface IBackLogRepository
    {
        BackLog create(BackLog b);
        BackLog Get(int id);
        List<BackLog> GetAll();
         BackLog editBackLog(BackLog b);
        List<BackLog> getProjectBacklog(int projectId);
        void delete(int backlogId);
    }
}
