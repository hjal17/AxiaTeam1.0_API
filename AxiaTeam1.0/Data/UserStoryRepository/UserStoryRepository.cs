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

        public UserStory edit(UserStory us)
        {
            var userStory = _userstoryContext.UserStorys.FirstOrDefault(u => u.Id == us.Id);
            if (!(us.Name is null) && !(us.Name == userStory.Name))
                userStory.Name = us.Name;
            if (!(us.Description is null) && !(us.Description == userStory.Description))
                userStory.Description = us.Description;

            if (!(us.TemEstimer is null) && !(us.TemEstimer == userStory.TemEstimer))
                userStory.TemEstimer = us.Description;
            _userstoryContext.SaveChanges();
            return userStory;
        }

        public UserStory Get(int id)
        {
            return _userstoryContext.UserStorys.FirstOrDefault(us => us.Id == id);
           
        }

        public List<UserStory> GetAll(int backLogId)
        {
            return _userstoryContext.UserStorys.Where(us=>us.BackLogId==backLogId).ToList();

        }
    }
}
