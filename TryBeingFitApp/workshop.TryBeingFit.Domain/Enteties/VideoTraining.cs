using System;
using System.Collections.Generic;
using System.Text;
using workshop.TryBeingFit.Domain.Interfaces;

namespace workshop.TryBeingFit.Domain.Enteties
{
    public class VideoTraining : Training, IVideoTraining
    {
        public string Link { get; set; }

        public string CheckRaiting()
        {
            throw new NotImplementedException();
        }

        public override string PrintInfo()
        {
            return $"[{Difficulty}] {Title} - {Description}";
        }
    }
}
