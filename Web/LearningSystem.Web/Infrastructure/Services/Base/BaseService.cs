using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LearningSystem.Data;

namespace LearningSystem.Web.Infrastructure.Services.Base
{
    public abstract class BaseService
    {
        protected ILearningSystemData Data { get; private set; }

        public BaseService(ILearningSystemData data)
        {
            this.Data = data;
        }
    }
}