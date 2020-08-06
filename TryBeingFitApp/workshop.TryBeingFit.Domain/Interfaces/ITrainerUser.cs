using System;
using System.Collections.Generic;
using System.Text;
using workshop.TryBeingFit.Domain.Enteties;

namespace workshop.TryBeingFit.Domain.Interfaces
{
    public interface ITrainerUser
    {
        bool ChangeSchedule(LiveTraining liveTraining, int days);
    }
}
