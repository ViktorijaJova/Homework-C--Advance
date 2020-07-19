using System;
using System.Collections.Generic;
using System.Text;
using TrackingTimeApp.Domain.Enums;

namespace TrackingTimeApp.Domain.Entities
{
   public class Puzzles:BaseEntity
   {
   public PuzzlesType PuzzlesType { get; set; }
   public Puzzles()
   {
    ActivityType = ActivityType.Puzzles;
   }
   }
}
