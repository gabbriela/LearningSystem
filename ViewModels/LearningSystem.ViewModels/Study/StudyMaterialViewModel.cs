namespace LearningSystem.ViewModels.Study
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using LearningSystem.Models;
    using LearningSystem.ViewModels.Comments;
    using LearningSystem.ViewModels.Infrastructure.Mapping;

    public class StudyMaterialViewModel : IMapFrom<StudyMaterial>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PublishDate { get; set; }

        public string Content { get; set; }

        public string Source { get; set; }
        
        public string SectionName { get; set; }

        public string AuthorName { get; set; }
        
        public int VotesCount;

        public int? ImageId { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
        
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<StudyMaterial, StudyMaterialViewModel>()
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Content, opt => opt.MapFrom(s => s.Content))
                .ForMember(d => d.AuthorName, opt => opt.MapFrom(s => s.Author.FullName))
                .ForMember(d => d.PublishDate, opt => opt.MapFrom(s => s.PublishDate))
                .ForMember(d => d.Source, opt => opt.MapFrom(s => s.Source))
                .ForMember(d => d.SectionName, opt => opt.MapFrom(s => s.Section.Title))
                .ForMember(d => d.VotesCount, opt => opt.MapFrom(s => s.Votes.Count))
                .ReverseMap();
        }
    }
}