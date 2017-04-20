namespace LearningSystem.Data
{
    using System.Data.Entity;
    using LearningSystem.Models;

    public interface ILearningSystemData
    {
        IRepository<Answer> Answers { get; }

        IRepository<Category> Cateogries { get; }

        IRepository<Question> Questions { get; }

        IRepository<Section> Sections { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Image> Images { get; }

        IRepository<StudyMaterial> StudyMaterials { get; }

        IRepository<User> Users { get; }

        DbContext Context { get; }

        int SaveChanges();

        void Dispose();
    }
}