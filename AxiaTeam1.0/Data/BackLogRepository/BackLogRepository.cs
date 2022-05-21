using AxiaTeam1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Data.BackLogRepository
{
    public class BackLogRepository:IBackLogRepository
    {
        private readonly DataContext _backLogContext;

        public BackLogRepository(DataContext BacklogContext)
        {
            _backLogContext = BacklogContext;
        }
        public BackLog create(BackLog b)
        {
            _backLogContext.BackLogs.Add(b);

            b.Id = _backLogContext.SaveChanges();
            return b;
        }

        public BackLog editBackLog(BackLog newBacklog)
        {
            var backLog = _backLogContext.BackLogs.FirstOrDefault(b => b.Id == newBacklog.Id);
            if (!(newBacklog.Description is null) && !(newBacklog.Description == backLog.Description))
                backLog.Description = newBacklog.Description;
            if (!(newBacklog.Version is null) && !(newBacklog.Version == backLog.Version))
                backLog.Version = newBacklog.Version;

           
            _backLogContext.SaveChanges();
            return backLog;
        }

        public BackLog Get(int id)
        {
            return _backLogContext.BackLogs.FirstOrDefault(b => b.Id == id);
        }

        public List<BackLog> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
