using System;
using System.Collections.Generic;
using System.Text;

namespace TrackingTimeApp.Domain.Entities
{
   public class AllActivities
    {
        public List<BaseEntity> Activities { get; set; } = new List<BaseEntity>();

        public List<double> TotalHours { get; set; } = new List<double>() {1.02 } ;

        public List<string> FavoriteType { get; set; } = new List<string>();

    }
}
