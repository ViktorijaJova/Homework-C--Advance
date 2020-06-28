using System;
using System.Collections.Generic;
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
            Console.WriteLine($"{ActivityType.ToString()} : {Reading} you have enjoyed {BookType} and read {Pages}  for {TRackedTime.Seconds} seconds from {StartTimer} to {StopTimer}");
        }
    }
}
