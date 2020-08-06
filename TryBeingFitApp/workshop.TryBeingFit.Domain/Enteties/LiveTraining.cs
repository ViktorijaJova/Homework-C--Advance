using System;
using System.Collections.Generic;
using System.Text;
using workshop.TryBeingFit.Domain.Interfaces;

namespace workshop.TryBeingFit.Domain.Enteties
{
    public class LiveTraining : Training,ILiveTraining
    {
        public DateTime NextSession { get; set; }

        public TrainerUser Trainer { get; set; }

        public int HoursToNextSession()
        {
            throw new NotImplementedException();
        }

        public override string PrintInfo()
        {
            throw new NotImplementedException();
        }
    }
}
