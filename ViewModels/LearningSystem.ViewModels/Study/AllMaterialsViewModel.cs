namespace LearningSystem.ViewModels.Study
{
    using System;
    using AutoMapper;
    using LearningSystem.Models;
    using LearningSystem.ViewModels.Infrastructure.Mapping;

    public class AllMaterialsViewModel : IMapFrom<StudyMaterial>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PublishDate { get; set; }
        
        public string SectionName { get; set; }

        public string AuthorName { get; set; }
        
        public int VotesCount;
        
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<StudyMaterial, AllMaterialsViewModel>()
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.AuthorName, opt => opt.MapFrom(s => s.Author.FullName))
                .ForMember(d => d.PublishDate, opt => opt.MapFrom(s => s.PublishDate))
                .ForMember(d => d.SectionName, opt => opt.MapFrom(s => s.Section.Title))
                .ForMember(d => d.VotesCount, opt => opt.MapFrom(s => s.Votes.Count));
        }
    }
}