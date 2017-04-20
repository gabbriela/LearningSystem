namespace LearningSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using LearningSystem.Common;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CategoryMaxLength), MinLength(GlobalConstants.CategoryMinLength)]
        public string Title { get; set; }
    }
}
