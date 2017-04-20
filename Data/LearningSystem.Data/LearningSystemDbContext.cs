namespace LearningSystem.Data
{
    using System.Data.Entity;
    using LearningSystem.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class LearningSystemDbContext : IdentityDbContext<User>
    {
        public LearningSystemDbContext()
            : base("LearningSystem", throwIfV1Schema: false)
        {
        }

        public IDbSet<StudyMaterial> StudyMaterials { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Section> Sections { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public IDbSet<Question> Questions { get; set; }

        public IDbSet<Answer> Answers { get; set; }

        public IDbSet<Image> Images { get; set; }

        public static LearningSystemDbContext Create()
        {
            return new LearningSystemDbContext();
        }
    }
}