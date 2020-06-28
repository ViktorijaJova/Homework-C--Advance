using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TrackingTimeApp.Domain.Entities;
using TrackingTimeApp.Domain.Enums;

namespace TimeTrackingApp.Services.Services
{
     public class ActivityServices<T> where T: BaseEntity
    {
        public  MenuService menus = new MenuService();
        public void Tracking(ActivityType activity, User user)
        {
            switch (activity)
            {
                case ActivityType.Reading:
                    var reading = new Reading();
                    reading.TrackTimeSpendDoingActivity();

                    Console.WriteLine("What kind of book did you read");
                    reading.BookType = (BookType)menus.ShowReadingTypes();
                    var readlino = Console.ReadLine();
                    Console.WriteLine("And how many pages:");
                    reading.Pages = int.Parse(Console.ReadLine());

                    user.Activities.Add(reading);
                    Console.WriteLine("Added...");
                    Thread.Sleep(2000);
                    Console.Clear();
              
                    break;

                case ActivityType.Puzzles:
                    var puzzles = new Puzzles();
                    puzzles.TrackTimeSpendDoingActivity();
                    Console.WriteLine("What kind of Puzzle did you do?");
                    puzzles.PuzzlesType = (PuzzlesType)menus.ShowPuzzlesTypes();
                    var readlines = Console.ReadLine();
                    user.Activities.Add(puzzles);
                    Console.WriteLine("Your information has been added to your statistics!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;

                case ActivityType.Watching:
                    var watching = new Watching();
                    watching.TrackTimeSpendDoingActivity();
                    Console.WriteLine("What were you watching?");
                    watching.WatchingType = (WatchingType)menus.ShowWatchingTypes();
                    var readline = Console.ReadLine();
                  
                    user.Activities.Add(watching);
                    Console.WriteLine("Your information has been added to your statistics!");
                    Console.Clear();
                    break;
                case ActivityType.OtherHobbies:
                    var otherhobbies = new OtherHobbies();
                    otherhobbies.TrackTimeSpendDoingActivity();
                    Console.WriteLine("Please enter what hobby were you doing");
                    otherhobbies.Hobby = Console.ReadLine();
                    user.Activities.Add(otherhobbies);
                    Console.WriteLine("Your information has been added to your statistics!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
                default:
                    break;
            }

        }
    }
}
