using System;
using System.Collections.Generic;
using System.Text;
using workshop.TryBeingFit.Domain.Enums;

namespace workshop.TryBeingFit.Domain.Enteties
{
    public class StandarUser : User
    {
        public List<VideoTraining> VideoTrainings { get; set; }

        public StandarUser()
        {
            Role = UserRole.Standard;
            VideoTrainings = new List<VideoTraining>();
        }
        public override string PrintInfo()
        {
            throw new NotImplementedException();
        }
    }
}
