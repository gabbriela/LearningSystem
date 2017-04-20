namespace LearningSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        public string FileExtension { get; set; }

        public int StudyMaterialId { get; set; }

        public StudyMaterial StudyMaterial { get; set; }
    }
}
