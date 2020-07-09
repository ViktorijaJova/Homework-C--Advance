using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TrackingTimeApp.Domain.Entities;
using TrackingTimeApp.Domain.Enums;

namespace TimeTrackingApp.Services.Services
{
     public class ActivityServices: BaseEntity
    {
        public  MenuService menus = new MenuService();

        public override void GetHours()
        {
            throw new NotImplementedException();
        }

        public override void PrintInfo()
        {
            throw new NotImplementedException();
        }

        public void Tracking(ActivityType activity, User user)
        {
            switch (activity)
            {
                case ActivityType.Reading:
                    var reading = new Reading();
                    reading.TrackTimeSpendDoingActivity();
                    user.TotalHours.Add(reading.TRackedTime.TotalSeconds);

                    Console.WriteLine("What kind of book did you read");
                    reading.BookType = (BookType)menus.ShowReadingTypes();
                    string readlino = Console.ReadLine();
                    user.FavoriteType.Add(readlino);
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
                    user.TotalHours.Add(puzzles.TRackedTime.TotalSeconds);

                    Console.WriteLine("What kind of Puzzle did you do?");
                    puzzles.PuzzlesType = (PuzzlesType)menus.ShowPuzzlesTypes();
                    var readlines = Console.ReadLine();
                    user.FavoriteType.Add(readlines);
                    user.Activities.Add(puzzles);
                    Console.WriteLine("Your information has been added to your statistics!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;

                case ActivityType.Watching:
                    var watching = new Watching();
                    watching.TrackTimeSpendDoingActivity();
                    user.TotalHours.Add(watching.TRackedTime.TotalSeconds);

                    Console.WriteLine("What were you watching?");
                    watching.WatchingType = (WatchingType)menus.ShowWatchingTypes();
                    var readline = Console.ReadLine();
                    user.FavoriteType.Add(readline);
                  
                    user.Activities.Add(watching);
                    Console.WriteLine("Your information has been added to your statistics!");
                    Console.Clear();
                    break;
                case ActivityType.OtherHobbies:
                    var otherhobbies = new OtherHobbies();
                    otherhobbies.TrackTimeSpendDoingActivity();
                    user.TotalHours.Add(otherhobbies.TRackedTime.TotalSeconds);
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
