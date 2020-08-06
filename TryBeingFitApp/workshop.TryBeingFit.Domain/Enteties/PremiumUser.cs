using System;
using System.Collections.Generic;
using System.Text;
using workshop.TryBeingFit.Domain.Interfaces;

namespace workshop.TryBeingFit.Domain.Enteties
{
    public class PremiumUser : User, IPremiumUser
    {
        public List<VideoTraining> VideoTrainings { get; set; }
        public LiveTraining LiveTraining { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public PremiumUser()
        {
            Role = Enums.UserRole.Premium;
            VideoTrainings = new List<VideoTraining>();
        }
        public override string PrintInfo()
        {
            throw new NotImplementedException();
        }
    }
}
