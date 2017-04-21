using System;
using AutoMapper;
using LearningSystem.Models;
using LearningSystem.Web.Infrastructure.Mapping;
using LearningSystem.Web.ViewModels.Home;

namespace LearningSystem.Web.ViewModels.Study
{
    public class StudyMaterialViewModel : IMapFrom<StudyMaterial>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PublishDate { get; set; }

        public string Content { get; set; }

        public string Source { get; set; }
        
        public string SectionName { get; set; }

        public string AuthorName { get; set; }

        //public ICollection<Comment> Comments;

        public int VotesCount;

        public int? ImageId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<StudyMaterial, StudyMaterialViewModel>()
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Content, opt => opt.MapFrom(s => s.Content))
                .ForMember(d => d.AuthorName, opt => opt.MapFrom(s => s.Author.FullName))
                .ForMember(d => d.PublishDate, opt => opt.MapFrom(s => s.PublishDate))
                .ForMember(d => d.Source, opt => opt.MapFrom(s => s.Source))
                .ForMember(d => d.SectionName, opt => opt.MapFrom(s => s.Section.Title))
                .ForMember(d => d.VotesCount, opt => opt.MapFrom(s => s.Votes.Count));



        }
    }
}