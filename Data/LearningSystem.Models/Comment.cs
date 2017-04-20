namespace LearningSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using LearningSystem.Common;

    public class Comment
    {
        public Comment()
        {
            this.Date = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CommentMaxLength), MinLength(GlobalConstants.CommentMinLength)]
        public string Content { get; set; }

        public DateTime Date { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int StudyMaterialId { get; set; }

        [Required]
        public StudyMaterial StudyMaterial { get; set; }
    }
}
