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


        public ActivityType ActivityType { get; set; }
    }
}
