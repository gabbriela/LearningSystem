using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using LearningSystem.Web.Infrastructure.Mapping;
using LearningSystem.Models;

namespace LearningSystem.Web.ViewModels.Home
{
    public class MostVotedMaterialsViewModel : IMapFrom<StudyMaterial>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string MaterialTitle { get; set; }

        public string SectionName { get; set; }

        public string AuthorName { get; set; }

        public int NumberOfVotes { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<StudyMaterial, MostVotedMaterialsViewModel>()
                .ForMember(d => d.MaterialTitle, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.SectionName, opt => opt.MapFrom(s => s.Section.Title))
                .ForMember(d => d.AuthorName, opt => opt.MapFrom(s => s.Author.FullName))
                .ForMember(d => d.NumberOfVotes, opt => opt.MapFrom(s => s.Votes.Count()))
                .ReverseMap();
        }
    }
}