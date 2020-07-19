using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    }
}
