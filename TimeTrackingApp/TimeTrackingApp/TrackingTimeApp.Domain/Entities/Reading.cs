using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TrackingTimeApp.Domain.Enums;

namespace TrackingTimeApp.Domain.Entities
{
    public class Reading : BaseEntity
    {

        public int Pages { get; set; }

        public BookType BookType { get; set; }

        public Reading()
        {
            ActivityType = ActivityType.Reading;
        }
        public override void PrintInfo()
        {
            
            Console.WriteLine($"Reading :  you have enjoyed {BookType} and read {Pages}  for {TRackedTime.Seconds} seconds from {StartTimer} to {StopTimer}");

            Console.WriteLine($"{TRackedTime.TotalMinutes}  all seconds spend doing this activity in total");

        }


        public override void GetHours()
        {
            Console.WriteLine($"{TRackedTime.Hours}");
        }

    }
}
