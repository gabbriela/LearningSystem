namespace LearningSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using LearningSystem.Common;

    public class Section
    {
        private ICollection<StudyMaterial> materials;
        private ICollection<Question> questions;

        public Section()
        {
            this.materials = new HashSet<StudyMaterial>();
            this.questions = new HashSet<Question>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.SectionTitleMaxLength), MinLength(GlobalConstants.SectionTitleMinLength)]
        public string Title { get; set; }

        public virtual ICollection<StudyMaterial> StudyMaterials
        {
            get { return this.materials; }
            set { this.materials = value; }
        }

        public virtual ICollection<Question> Questions
        {
            get { return this.questions; }
            set { this.questions = value; }
        }
    }
}
