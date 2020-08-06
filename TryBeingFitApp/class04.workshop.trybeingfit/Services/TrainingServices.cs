using System;
using System.Collections.Generic;
using System.Text;
using workshop.TryBeingFit.Domain.Db;
using workshop.TryBeingFit.Domain.Enteties;

namespace class04.workshop.trybeingfit.Services.Services
{
    public class TrainingService<T> : ITrainingService<T>
           where T : Training
    {
        private IDb<T> _db;

        public TrainingService()
        {
            _db = new LocalDb<T>();
        }
        public void AddTraining(T training)
        {
            _db.Insert(training);
        }

        public T GetSingleTraining(int id)
        {
            T training = _db.GetById(id);
            return training;
        }

        public List<T> GetTrainings()
        {
            return _db.GetAll();
        }
    }
}

