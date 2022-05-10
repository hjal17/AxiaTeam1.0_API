using AxiaTeam1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public Models.User Create(Models.User user)
        {
            _context.Users.Add(user);
            user.Id = _context.SaveChanges();

            return user;
        }

        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User editPassword(User _user)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == _user.Id);
            user.Password = BCrypt.Net.BCrypt.HashPassword(_user.Password);
            _context.SaveChanges();
            return user;
        }

        public User editUser(User dtoUser)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == dtoUser.Id);
            if (!(dtoUser.Name is  null) && !(dtoUser.Name == user.Name))
                user.Name = dtoUser.Name;
            if (!(dtoUser.Email is null) && !(dtoUser.Email == user.Email))
                user.Email = dtoUser.Email;
            
            if (!(dtoUser.Role is null) && !(dtoUser.Role == user.Role))
                user.Role = dtoUser.Role;
            _context.SaveChanges();
            return user;
        }

        public List<User> getAll(int id)
        {
            return _context.Users.Where(u =>u.Id != id).ToList();
        }

        public Models.User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public Models.User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
