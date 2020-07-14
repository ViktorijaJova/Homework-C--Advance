using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TrackingTimeApp.Domain.Enums;
using TrackingTimeApp.Domain.Interfaces;

namespace TrackingTimeApp.Domain.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {

        public TimeSpan TRackedTime { get; set; }

        public DateTime StartTimer { get; set; }

        public DateTime StopTimer { get; set; }

        public ActivityType ActivityType { get; set; }

        


        public void TrackTimeSpendDoingActivity()
        {
            StartTimer = DateTime.Now;
            Console.WriteLine("Your tracking has started ");

            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("If you want to stop doing your activity press Enter!");
            ConsoleKeyInfo key = Console.ReadKey();

            if(key.Key == ConsoleKey.Enter)
            {
                timer.Stop();
                StopTimer = DateTime.Now;
                TRackedTime = StopTimer - StartTimer;
                Console.WriteLine($" You have been doing your activity for {TRackedTime.TotalSeconds} seconds");
                

            }
            else
            {
                Console.WriteLine("[Error!!!]");
            }
        }

       
     
    }
}
