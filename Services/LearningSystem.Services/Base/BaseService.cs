using LearningSystem.Data;

namespace LearningSystem.Services.Base
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