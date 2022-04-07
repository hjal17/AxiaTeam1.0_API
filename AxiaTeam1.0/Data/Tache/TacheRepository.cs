using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AxiaTeam1._0.Models;
namespace AxiaTeam1._0.Data.Tache
{
    public class TacheRepository : ITacheRepository
    {
        private readonly DataContext _tacheContext;

        public TacheRepository(DataContext TacheContext)
        {
            _tacheContext = TacheContext;
        }
        public TTache Create(TTache tache)
        {
            _tacheContext.Taches.Add(tache);
            _tacheContext.SaveChanges();
            return (tache);
        }

        public TTache Get(int id)
        {
            var tache = _tacheContext.Taches.FirstOrDefault(t => t.Id == id);
            return tache;
        }

        public List<TTache> GetAll()
        {
            return _tacheContext.Taches.ToList();
        }

       
    }
}
