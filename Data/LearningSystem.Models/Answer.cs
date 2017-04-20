namespace LearningSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using LearningSystem.Common;

    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.AnswerMaxLength), MinLength(GlobalConstants.AnswerMinLength)]
        public string Content { get; set; }

        [Required]
        public bool Correct { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
