using AxiaTeam1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Data.EquipeRepository
{
    interface IEquipeRepository
    {

        Equipe Create(Equipe equipe);

        Equipe GetById(int id);
        List<Equipe> getAll();
        Equipe EditClient(Equipe equipe);

        void Delete(int id);
    }
}
