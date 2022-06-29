using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AxiaTeam1._0.Models;
namespace AxiaTeam1._0.Data.Tache
{
    public interface ITacheRepository
    {
         TTache Create(TTache tache);
        TTache Get(int id);
        List<TTache> GetAll();
        List<TTache> getUserStoryTaches(int usId);
    }
}
