namespace LearningSystem.ViewModels.Comments
{
    using AutoMapper;
    using LearningSystem.ViewModels.Infrastructure.Mapping;
    using LearningSystem.Models;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }
        
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Content, opt => opt.MapFrom(s => s.Content))
                .ForMember(d => d.AuthorName, opt => opt.MapFrom(s => s.Author.FullName));
        }
    }
}
