using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD_UserService.Context;
using MOD_UserService.Models;

namespace MOD_UserService.Repositories
{
    public class MentorRepository : IMentorRepository
    {
        private readonly UserServiceContext _context;
        public MentorRepository(UserServiceContext context)
        {
            _context = context;
        }

        public void Add(Mentor item)
        {
            _context.Mentors.Add(item);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var item = _context.Mentors.Find(id);
            _context.Mentors.Remove(item);
            _context.SaveChanges();
        }

        public List<Mentor> GetMentors()
        {
            return _context.Mentors.ToList();
        }

        public void ResetPassword(string Email, string NewPass)
        {
            var Rstpass = _context.Mentors.SingleOrDefault(i => i.Email == Email);
            Rstpass.Password = NewPass;
            _context.SaveChanges();
        }

        public void Update(Mentor item)
        {
            _context.Entry(item).State =
               Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
