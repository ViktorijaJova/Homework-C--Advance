using System;
using System.Collections.Generic;
using System.Text;
using TrackingTimeApp.Domain.Enums;

namespace TrackingTimeApp.Domain.Entities
{
   public class OtherHobbies:BaseEntity
    {
        public string Hobby { get; set; }

        public OtherHobbies()
        {
            ActivityType = ActivityType.OtherHobbies;
        }

   

    }
}
