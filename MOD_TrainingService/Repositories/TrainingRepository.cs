using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD_TrainingService.Context;
using MOD_TrainingService.Models;

namespace MOD_TrainingService.Repositories
{
    public class TrainingRepository:ITrainingRepository
    {
        private readonly TrainingContext _context;
        public TrainingRepository(TrainingContext context)
        {
            _context = context;
        }

        public void Add(Training item)
        {
            _context.Trainings.Add(item);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var item = _context.Trainings.Find(id);
            _context.Trainings.Remove(item);
            _context.SaveChanges();
        }

        public List<Training> GetTrainings()
        {
            return _context.Trainings.ToList();
        }

        public void Update(Training item)
        {
            _context.Entry(item).State =
               Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
