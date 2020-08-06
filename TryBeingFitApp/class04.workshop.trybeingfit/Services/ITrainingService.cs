using System;
using System.Collections.Generic;
using System.Text;
using workshop.TryBeingFit.Domain.Enteties;

namespace class04.workshop.trybeingfit.Services.Services
{
    public interface ITrainingService<T> where T : Training
    {
        List<T> GetTrainings();
        T GetSingleTraining(int id);
        void AddTraining(T training);
    }
}
