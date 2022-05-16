using AxiaTeam1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Data.EquipeRepository
{
    public class EquipeRepository : IEquipeRepository
    {
        private readonly DataContext _equipeContext;

        public EquipeRepository(DataContext dataContext)
        {
            _equipeContext = dataContext;
        }
        public Equipe Create(Equipe equipe)
        {
            _equipeContext.equipes.Add(equipe);
            _equipeContext.SaveChanges();
            return equipe;
        }

        public void Delete(int id)
        {
            var equipe = _equipeContext.equipes.FirstOrDefault(e => e.Id == id);
            _equipeContext.equipes.Remove(equipe);
            _equipeContext.SaveChanges();
        }

        public Equipe EditClient(Equipe _equipe)
        {
            var equipe = _equipeContext.equipes.FirstOrDefault(e => e.Id == _equipe.Id);
            equipe.name = _equipe.name;
            _equipeContext.SaveChanges();
            return equipe;
        }

        public List<Equipe> getAll()
        {
            return _equipeContext.equipes.ToList();
        }

        public Equipe GetById(int id)
        {
            return _equipeContext.equipes.FirstOrDefault(e=> e.Id == id);

        }
    }
}
