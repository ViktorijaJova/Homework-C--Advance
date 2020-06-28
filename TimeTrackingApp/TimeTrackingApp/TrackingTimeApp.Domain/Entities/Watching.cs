using System;
using System.Collections.Generic;
using System.Text;
using TrackingTimeApp.Domain.Enums;

namespace TrackingTimeApp.Domain.Entities
{
    public class Watching : BaseEntity
    {

        public WatchingType WatchingType { get; set; }
        public Watching()
        {
            ActivityType = ActivityType.Watching;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"{ActivityType.ToString()} : {Watching}you have enjoyed {WatchingType}  for {TRackedTime.Seconds} seconds from {StartTimer} to {StopTimer}");
        }
    }
}
