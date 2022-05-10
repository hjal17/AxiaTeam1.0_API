using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AxiaTeam1._0.Models;
namespace AxiaTeam1._0.Data
{
    public interface IClientRepository
    {
        Models.Client Create(Models.Client client);
       
        Models.Client GetById(int id);
        List<Models.Client> getAll();
        Models.Client EditClient(Models.Client client);

        void Delete(int id);
       
        
    }
}
