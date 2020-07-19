using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrackingTimeApp.Domain.Entities
{
   public class AllActivities
   {
   public List<BaseEntity> Activities { get; set; } = new List<BaseEntity>();
   public List<double> TotalHoursReading { get; set; } = new List<double>();
   public List<double> TotalHoursWatching { get; set; } = new List<double>();
   public List<double> TotalHoursPuzzles { get; set; } = new List<double>();
   public List<double> TotalHoursOtherHobbies { get; set; } = new List<double>();
   public List<string> FavoriteTypeBook { get; set; } = new List<string>();
   public List<string> FavoriteTypePuzzle { get; set; } = new List<string>();
   public List<string> FavoriteTypToWatch { get; set; } = new List<string>();
   }
}
