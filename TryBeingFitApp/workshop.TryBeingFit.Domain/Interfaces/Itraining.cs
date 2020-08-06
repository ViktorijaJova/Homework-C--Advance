using System;
using System.Collections.Generic;
using System.Text;
using workshop.TryBeingFit.Domain.Enums;

namespace workshop.TryBeingFit.Domain.Interfaces
{
  public interface Itraining
    {
        string Title { get; set; }
        string Description { get; set; }
        int Time { get; set; }
        Difficulty Difficulty { get; set; }

    }
}
