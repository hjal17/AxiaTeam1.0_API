using AxiaTeam1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Data
{
    public interface IUserStoryRepository
    {
        UserStory create(UserStory us);
        UserStory Get(int id);
        List<UserStory> GetAll(int backlogId);

        UserStory edit(UserStory us);
        void delete(int id);
    }
}
