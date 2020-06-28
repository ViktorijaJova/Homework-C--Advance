using System;
using System.Collections.Generic;
using System.Text;
using TrackingTimeApp.Domain.Entities;
using TrackingTimeApp.Domain.Enums;

namespace TrackingTimeApp.Domain.Interfaces
{
    public interface IBaseEntity
    {


        public TimeSpan TRackedTime { get; set; }

        public DateTime StartTimer { get; set; }
        public DateTime StopTimer  { get; set; }


        public Reading Reading { get; set; }

        public Puzzles Puzzles { get; set; }


        public Watching Watching { get; set; }

        public OtherHobbies OtherHobbies { get; set; }


        public ActivityType ActivityType { get; set; }
    }
}
