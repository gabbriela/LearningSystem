namespace LearningSystem.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using LearningSystem.Models;
    using LearningSystem.ViewModels.Infrastructure.Mapping;

    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public PostCommentViewModel()
        {
        }

        public PostCommentViewModel(int materialId)
        {
            this.MaterialId = materialId;
        }
        
        public int MaterialId { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 100)]
        [UIHint("MultiLineText")]
        public string Content { get; set; }
    }
}