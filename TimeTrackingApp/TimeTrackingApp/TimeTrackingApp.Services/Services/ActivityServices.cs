using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using TrackingTimeApp.Domain;
using TrackingTimeApp.Domain.Entities;
using TrackingTimeApp.Domain.Enums;
using TrackingTimeApp.Domain.Interfaces;

namespace TimeTrackingApp.Services.Services
{
     public class ActivityServices: BaseEntity
    {
        public  MenuService menus = new MenuService();

        static IDb<User> _userDb = new Db<User>();


        public void Tracking(ActivityType activity, User user)
        {
            switch (activity)
            {
                case ActivityType.Reading:
                    var reading = new Reading();
                    reading.TrackTimeSpendDoingActivity();
                    user.TotalHoursReading.Add(reading.TRackedTime.TotalSeconds);

                    Console.WriteLine("What kind of book did you read");
                    reading.BookType = (BookType)menus.ShowReadingTypes();
                    var readlino = Console.ReadLine();
                    user.FavoriteTypeBook.Add(readlino);
                    Console.WriteLine("And how many pages:");
                    reading.Pages = int.Parse(Console.ReadLine());

                    user.Activities.Add(reading);
                    Console.WriteLine("Added...");
                    Console.ReadLine();
                    Console.Clear();
              
                    break;

                case ActivityType.Puzzles:
                    var puzzles = new Puzzles();
                    puzzles.TrackTimeSpendDoingActivity();
                    user.TotalHoursPuzzles.Add(puzzles.TRackedTime.TotalSeconds);

                    Console.WriteLine("What kind of Puzzle did you do?");
                    puzzles.PuzzlesType = (PuzzlesType)menus.ShowPuzzlesTypes();
                    var readlines = Console.ReadLine();
                    user.FavoriteTypePuzzle.Add(readlines);
                    user.Activities.Add(puzzles);

                    Console.WriteLine("Your information has been added to your statistics!");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case ActivityType.Watching:
                    var watching = new Watching();
                    watching.TrackTimeSpendDoingActivity();
                    user.TotalHoursWatching.Add(watching.TRackedTime.TotalSeconds);

                    Console.WriteLine("What were you watching?");
                    watching.WatchingType = (WatchingType)menus.ShowWatchingTypes();
                    var readline = Console.ReadLine();
                    user.FavoriteTypToWatch.Add(readline);
                  
                    user.Activities.Add(watching);
                    Console.WriteLine("Your information has been added to your statistics!");
                    Console.Clear();
                    break;
                case ActivityType.OtherHobbies:
                    var otherhobbies = new OtherHobbies();
                    otherhobbies.TrackTimeSpendDoingActivity();
                    user.TotalHoursOtherHobbies.Add(otherhobbies.TRackedTime.TotalSeconds);
                    Console.WriteLine("Please enter what hobby were you doing");
                    otherhobbies.Hobby = Console.ReadLine();
                    
                    user.Activities.Add(otherhobbies);

                    Console.WriteLine("Your information has been added to your statistics!");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                default : 
                    break;
            }

        }
        public void SeeReadingStats(User user)
        {

            var readings = user.Activities.OfType<Reading>().ToList();
            var totalaHours = user.TotalHoursReading.Sum().ToString();
          //  var average = user.TotalHoursReading.Average().ToString();
            var totalPages = readings.Sum(pages => pages.Pages);
            var allTypesofBooks = readings.Select(name => name.BookType).ToList();

            if (readings.Count != 0)
            {
                Console.WriteLine($"Total seconds spend {totalaHours}");
              //  Console.WriteLine($"Average: {average}");
                Console.WriteLine($"Total pages: {totalPages}");


                Console.WriteLine(" All BookTypes:");
                foreach (var book in allTypesofBooks)
                {
                    Console.WriteLine($"{book}");
                }


            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("No activity yet");
                Console.ResetColor();
                Console.ReadLine();

                Console.Clear();
            }







        }

        public void SeeOtherHobbiesStats(User user)
        {
            var totalOtherHobbiesHours = user.TotalHoursOtherHobbies.Sum();
            var otherHobbies = user.Activities.OfType<OtherHobbies>().ToList();
         //   var average = user.TotalHoursOtherHobbies.Average().ToString();

            var allhobies = otherHobbies.Select(name => name.Hobby).ToList();


            if (otherHobbies.Count != 0)
            {
                Console.WriteLine($"Total seconds spent in your hobbies: {totalOtherHobbiesHours}");
             //   Console.WriteLine($"Average time {average} seconds");
                Console.WriteLine("Hobbies:");
                foreach (var hobby in allhobies)
                {
                    Console.WriteLine(hobby);
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("No activity yet");
                Console.ReadLine();
                Console.ResetColor();
                Console.Clear();
            }




        }


        public void SeeWatchingStats(User user)
        {

            var watchings = user.Activities.OfType<Watching>().ToList();

            var totalWatchingHours = user.TotalHoursWatching.Sum();
            var movies = watchings.Where(watching => watching.WatchingType == WatchingType.Movie).Sum(hours => hours.TRackedTime.TotalSeconds);
            var standup = watchings.Where(watching => watching.WatchingType == WatchingType.StandUp).Sum(hours => hours.TRackedTime.TotalSeconds);
            var tvshows = watchings.Where(watching => watching.WatchingType == WatchingType.TvShow).Sum(hours => hours.TRackedTime.TotalSeconds);
            //var average = user.TotalHoursWatching.Average().ToString();


            if (watchings.Count != 0)
            {
                Console.WriteLine($"Total seconds spend {totalWatchingHours} in total");
              //  Console.WriteLine($"Average secods {average}");
                Console.WriteLine($"Just movies: {movies} seconds");
                Console.WriteLine($"Just standup: {standup} seconds");
                Console.WriteLine($"Just tvshows: {tvshows} seconds");
                Console.ReadLine();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("No activity yet");
                Console.ReadLine();
                Console.ResetColor();
                Console.Clear();
            }








        }



        public void SeePuzzlesStats(User user)
        {

            var puzzles = user.Activities.OfType<Puzzles>().ToList();
            var totalPuzzlesHours = user.TotalHoursPuzzles.Sum();
            var escapeRoom = puzzles.Where(first => first.PuzzlesType == PuzzlesType.EscapeRoom).Count();
            var rubikCube = puzzles.Where(first => first.PuzzlesType == PuzzlesType.RubiksCube).Count();
            var jigsaw = puzzles.Where(first => first.PuzzlesType == PuzzlesType.Jigsaw).Count();
            var crossword = puzzles.Where(first => first.PuzzlesType == PuzzlesType.Crossword).Count();
           // var average = user.TotalHoursPuzzles.Average().ToString();



            if (puzzles.Count != 0)
            {
                Console.WriteLine($"total seconds spend {totalPuzzlesHours}");
              //  Console.WriteLine($"Average seconds {average}");
                Console.WriteLine("Escape Room :" + escapeRoom);
                Console.WriteLine("Rubik Cube: " + rubikCube);
                Console.WriteLine("Jigsaw: " + jigsaw);
                Console.WriteLine("Crosswords: " + crossword);
                Console.ReadLine();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("No activity yet");
                Console.ReadLine();
                Console.ResetColor();
                Console.Clear();
            }



            //   List<int> vs = new List<int>() { escapeRoom, rubikCube, jigsaw, crossword };




        }
        public void SeeGeneralStats(User user)
        {

            var allGeneralHours = user.Activities.Sum(hours => hours.TRackedTime.TotalSeconds);
           // var average = user.Activities.Average(avg => avg.TRackedTime.TotalSeconds);

            Console.WriteLine($" Total time doing all of the activities{allGeneralHours} seconds");
           // Console.WriteLine($"Average time {average}");




            var reading = user.Activities.Where(x => x.ActivityType == ActivityType.Reading).Count();
            var watching = user.Activities.Where(x => x.ActivityType == ActivityType.Watching).Count();
            var puzzles = user.Activities.Where(x => x.ActivityType == ActivityType.Puzzles).Count();
            var hobbies = user.Activities.Where(x => x.ActivityType == ActivityType.OtherHobbies).Count();

           

            Console.WriteLine("Reading: " + reading);
            Console.WriteLine("Watching: " + watching);
            Console.WriteLine("Puzzles: " + puzzles);
            Console.WriteLine("Hobbies: " + hobbies);



            Console.ReadLine();


        }



    }
}
