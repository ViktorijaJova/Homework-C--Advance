using System;
using System.Collections.Generic;
using System.Text;
using TrackingTimeApp.Domain.Enums;

namespace TrackingTimeApp.Domain.Entities
{
   public class OtherHobbies:BaseEntity
    {
        public string Hobby { get; set; }

        public OtherHobbies()
        {
            ActivityType = ActivityType.OtherHobbies;
        }

        public override void PrintInfo()
        {
            //finish later
            Console.WriteLine($"{ActivityType.ToString()} : {Hobby} you have enjoyed  {Hobby} for {TRackedTime.Seconds} seconds from {StartTimer} to {StopTimer}");
        }
    }
}
