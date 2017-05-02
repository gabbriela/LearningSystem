namespace LearningSystem.Services.Base
{
    using LearningSystem.Data;

    public abstract class BaseService
    {
        public BaseService(ILearningSystemData data)
        {
            this.Data = data;
        }

        protected ILearningSystemData Data { get; private set; }
    }
}