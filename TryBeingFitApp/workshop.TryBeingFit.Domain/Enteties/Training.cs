using System;
using System.Collections.Generic;
using System.Text;
using workshop.TryBeingFit.Domain.Enums;
using workshop.TryBeingFit.Domain.Interfaces;

namespace workshop.TryBeingFit.Domain.Enteties
{
   
        public abstract class Training : BaseEntity, Itraining
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public int Time { get; set; }
            public Difficulty Difficulty { get; set; }
            public int Rating { get; set; }
            public virtual string CheckRating()
            {
                if (Rating == 1)
                {
                    return "Bad";
                }
                if (Rating < 3)
                {
                    return "Okay";
                }
                if (Rating > 3)
                {
                    return "Good";
                }

                return "Unknown";
            }
        }
    }

