using JobSeeking.BE.ApplicationCore.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using static JobSeeking.BE.ApplicationCore.Enums.Enumeration;

namespace JobSeeking.BE.ApplicationCore.Entities.Base
{
    public abstract class BaseEntity : IAggregateRoot
    {
        public EntityState EntityState = EntityState.GET;
    }
}
