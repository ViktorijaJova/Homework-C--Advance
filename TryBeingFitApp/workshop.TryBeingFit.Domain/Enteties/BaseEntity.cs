using System;
using System.Collections.Generic;
using System.Text;
using workshop.TryBeingFit.Domain.Interfaces;

namespace workshop.TryBeingFit.Domain.Enteties
{
    public abstract class BaseEntity:IBaseEntity
    {
        public int Id { get; set; }


        public abstract string PrintInfo();


     
    }
}
