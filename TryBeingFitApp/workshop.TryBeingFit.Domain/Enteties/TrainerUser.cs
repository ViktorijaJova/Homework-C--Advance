using System;
using System.Collections.Generic;
using System.Text;
using workshop.TryBeingFit.Domain.Enums;
using workshop.TryBeingFit.Domain.Interfaces;

namespace workshop.TryBeingFit.Domain.Enteties
{
    public class TrainerUser : User, ITrainerUser
    {
        public int YearsExperience { get; set; }

        public TrainerUser()
        {
            Role = UserRole.Trainer;
        }

        public bool ChangeSchedule(LiveTraining liveTraining, int days)
        {
            if (days <= 0)
            {
                return false;
            }
            liveTraining.NextSession = liveTraining.NextSession.AddDays(days);
            return true;
        }

        public override string PrintInfo()
        {
            throw new NotImplementedException();
        }

      
    }
}
