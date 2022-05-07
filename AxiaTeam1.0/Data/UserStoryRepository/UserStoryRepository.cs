using AxiaTeam1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Data.UserStoryRepository
{
    public class UserStoryRepository : IUserStoryRepository
    {
        private readonly DataContext _userstoryContext;

        public UserStoryRepository(DataContext UserStoryContext)
        {
            _userstoryContext = UserStoryContext;
        }
        public UserStory create(UserStory us)
        {
            _userstoryContext.UserStorys.Add(us);
            _userstoryContext.SaveChanges();
            return us;
        }

        public UserStory Get(int id)
        {
            return _userstoryContext.UserStorys.FirstOrDefault(us => us.Id == id);
           
        }

        public List<UserStory> GetAll()
        {
            return _userstoryContext.UserStorys.ToList();
        }
    }
}
