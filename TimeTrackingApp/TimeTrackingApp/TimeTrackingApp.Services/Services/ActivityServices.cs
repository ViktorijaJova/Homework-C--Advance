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
                    _userDb.UpdateUser(user);
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
                    _userDb.UpdateUser(user);

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
                    _userDb.UpdateUser(user);

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
                    _userDb.UpdateUser(user);

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
           // var average = user.TotalHoursReading.Average().ToString();
            var totalPages = readings.Sum(pages => pages.Pages);
            var allTypesofBooks = readings.Select(name => name.BookType).ToList();

          
                Console.WriteLine($"Total minutes spend {totalaHours}");
             //   Console.WriteLine($"Average: {average}");


            if (readings.Count != 0)
            {
                Console.WriteLine($"Total pages: {totalPages}");
                Console.WriteLine(" All BookTypes:");
                foreach (var book in allTypesofBooks)
                {
                    Console.WriteLine($"{book}");
                }
            }
                _userDb.UpdateUser(user);

            Console.ReadLine();
            
         







        }

        public void SeeOtherHobbiesStats(User user)
        {
            var totalOtherHobbiesHours = user.TotalHoursOtherHobbies.Sum();
           var otherHobbies = user.Activities.OfType<OtherHobbies>().ToList();
          //  var average = user.TotalHoursOtherHobbies.Average().ToString();

            var allhobies = otherHobbies.Select(name => name.Hobby).ToList();


          
                Console.WriteLine($"Total minutes spent in your hobbies: {totalOtherHobbiesHours}");
            //  Console.WriteLine($"Average time  {average} seconds");

            if (otherHobbies.Count != 0)
            {
                Console.WriteLine("Hobbies:");
                foreach (var hobby in allhobies)
                {
                    Console.WriteLine(hobby);
                }
            }
                _userDb.UpdateUser(user);
                Console.ReadLine();

        }

        public void SeeWatchingStats(User user)
        {

            var watchings = user.Activities.OfType<Watching>().ToList();

            var totalWatchingHours = user.TotalHoursWatching.Sum();

            var movies = watchings.Where(watching => watching.WatchingType == WatchingType.Movie).Sum(hours => hours.TRackedTime.TotalMinutes);
            var standup = watchings.Where(watching => watching.WatchingType == WatchingType.StandUp).Sum(hours => hours.TRackedTime.TotalMinutes);
            var tvshows = watchings.Where(watching => watching.WatchingType == WatchingType.TvShow).Sum(hours => hours.TRackedTime.TotalMinutes);
          //  var average = user.TotalHoursWatching.Average().ToString();


          
                Console.WriteLine($"Total seconds spend {totalWatchingHours} in total");
            //    Console.WriteLine($"Average time {average} seconds");

            if (watchings.Count != 0)
            {
                Console.WriteLine($"Just movies: {movies} min");
                Console.WriteLine($"Just standup: {standup} min");
                Console.WriteLine($"Just tvshows: {tvshows} min");
                _userDb.UpdateUser(user);
            }
                Console.ReadLine();
               
        }

        public void SeePuzzlesStats(User user)
        {

            var puzzles = user.Activities.OfType<Puzzles>().ToList();
            var totalPuzzlesHours = user.TotalHoursPuzzles.Sum();
            var escapeRoom = puzzles.Where(first => first.PuzzlesType == PuzzlesType.EscapeRoom).Count();
            var escapeRoomTIme = puzzles.Where(x => x.PuzzlesType == PuzzlesType.EscapeRoom)
          .Sum(c => c.TRackedTime.TotalSeconds);
            var rubikCube = puzzles.Where(first => first.PuzzlesType == PuzzlesType.RubiksCube).Count();
            var rubikCubeTime = puzzles.Where(x => x.PuzzlesType == PuzzlesType.RubiksCube)
      .Sum(c => c.TRackedTime.TotalSeconds);
            var jigsaw = puzzles.Where(first => first.PuzzlesType == PuzzlesType.Jigsaw).Count();
            var jigsawTime = puzzles.Where(x => x.PuzzlesType == PuzzlesType.Jigsaw)
      .Sum(c => c.TRackedTime.TotalSeconds);
            var crossword = puzzles.Where(first => first.PuzzlesType == PuzzlesType.Crossword).Count();
            var crosswordTime = puzzles.Where(x => x.PuzzlesType == PuzzlesType.Crossword)
      .Sum(c => c.TRackedTime.TotalSeconds);
           // var average = user.TotalHoursPuzzles.Average().ToString();


           
                Console.WriteLine($"Total minutes  spend {totalPuzzlesHours}");
               // Console.WriteLine($"Average time {average} seconds");

            if (puzzles.Count != 0)
            {
                Console.WriteLine($"Total Escape Room Time {escapeRoomTIme} and Number of Times {escapeRoom}:");
                Console.WriteLine($"Total Rubiks Cube Time {rubikCubeTime} and Number of Times {rubikCube}:");
                Console.WriteLine($"Total Jigsaw Time {jigsawTime} and Number of Times {jigsaw}:");
                Console.WriteLine($"Total Crosswords Time {crosswordTime} and Number of Times {crossword}:");
            }

            _userDb.UpdateUser(user);
            Console.ReadLine();
            
         
        
        }
        public void SeeGeneralStats(User user)
        {

            var allGeneralHours = user.Activities.Sum(hours => hours.TRackedTime.TotalMinutes);
            var average = user.Activities.Average(avg => avg.TRackedTime.TotalSeconds);

            Console.WriteLine($" Total time doing all of the activities: {allGeneralHours} minutes");
            Console.WriteLine($"Average time {average} seconds");




            var reading = user.Activities.Where(x => x.ActivityType == ActivityType.Reading)
                .Sum(c => c.TRackedTime.TotalSeconds);
            var readingcount = user.Activities.Where(x => x.ActivityType == ActivityType.Reading).Count();
            var watching = user.Activities.Where(x => x.ActivityType == ActivityType.Watching)
             .Sum(c => c.TRackedTime.TotalSeconds);
            var watchingcount = user.Activities.Where(x => x.ActivityType == ActivityType.Watching).Count();
            var puzzles = user.Activities.Where(x => x.ActivityType == ActivityType.Puzzles)
             .Sum(c => c.TRackedTime.TotalSeconds);
            var puzzlescount = user.Activities.Where(x => x.ActivityType == ActivityType.Puzzles).Count();
            var hobbies = user.Activities.Where(x => x.ActivityType == ActivityType.OtherHobbies)
             .Sum(c => c.TRackedTime.TotalSeconds);
            var hobbiescount = user.Activities.Where(x => x.ActivityType == ActivityType.OtherHobbies).Count();

           
           
            Console.WriteLine("Reading full time : " + reading  + " Number of times you read " + readingcount);
            Console.WriteLine("Watching full time: " + watching +" Number of times you watched sth "+ watchingcount);
            Console.WriteLine("Puzzles fill time : " + puzzles + " Number of times you did a puzzle " + puzzlescount);
            Console.WriteLine("Hobbies full time : " + hobbies + " Number of times you did the hobby " + hobbiescount);




            Console.ReadLine();


        }



    }
}
