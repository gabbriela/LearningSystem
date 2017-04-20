namespace LearningSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Vote
    {
        [Key]
        public int Id { get; set; }

        public string VotedById { get; set; }

        public virtual User VotedBy { get; set; }

        public int StudyMaterialId { get; set; }

        [Required]
        public StudyMaterial StudyMaterial { get; set; }
    }
}
