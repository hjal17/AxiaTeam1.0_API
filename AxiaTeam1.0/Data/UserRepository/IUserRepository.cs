using AxiaTeam1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Data
{
     public interface IUserRepository
    {
        Models.User Create(Models.User user);
        Models.User GetByEmail(string email);
        Models.User GetById(int id);
    }
}
