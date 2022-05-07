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
