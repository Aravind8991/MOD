using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD_UserService.Context;
using MOD_UserService.Models;

namespace MOD_UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserServiceContext _context;
        public UserRepository(UserServiceContext context)
        {
            _context = context;
        }

        public void Add(User item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void Update(User item)
        {
            _context.Entry(item).State =
               Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var item = _context.Users.Find(id);
            _context.Users.Remove(item);
            _context.SaveChanges();
        }
        public void ResetPassword(string Email,string NewPass)
        {
            var Rstpass = _context.Users.SingleOrDefault(i => i.Email==Email);
            Rstpass.Password = NewPass;
            _context.SaveChanges();
        }
        public List<Mentor> SearchMentor(string Skill, string TimeSlot)
        {
            var mentors = _context.Mentors.Where(mentors => mentors.Skill == Skill && 
            mentors.TimeSlot == TimeSlot).ToList();
            return mentors;


        }

    }
}

