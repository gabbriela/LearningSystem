namespace LearningSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using LearningSystem.Models;

    public class LearningSystemData : ILearningSystemData
    {
        private readonly DbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public LearningSystemData(DbContext context)
        {
            this.context = context;
        }

        public IRepository<Answer> Answers
        {
            get { return this.GetRepository<Answer>(); }
        }

        public IRepository<Category> Cateogries
        {
            get { return this.GetRepository<Category>(); }
        }

        public IRepository<Question> Questions
        {
            get { return this.GetRepository<Question>(); }
        }

        public IRepository<Section> Sections
        {
            get { return this.GetRepository<Section>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IRepository<Image> Images
        {
            get { return this.GetRepository<Image>(); }
        }

        public IRepository<StudyMaterial> StudyMaterials
        {
            get { return this.GetRepository<StudyMaterial>(); }
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }
        
        public DbContext Context
        {
            get { return this.context; }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EfGenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
