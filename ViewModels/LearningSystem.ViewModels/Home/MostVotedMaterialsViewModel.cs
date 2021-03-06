﻿namespace LearningSystem.ViewModels.Home
{
    using System.Linq;
    using AutoMapper;
    using LearningSystem.Models;
    using LearningSystem.ViewModels.Infrastructure.Mapping;

    public class MostVotedMaterialsViewModel : IMapFrom<StudyMaterial>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string MaterialTitle { get; set; }

        public string MaterialContent { get; set; }

        public string SectionName { get; set; }

        public string AuthorName { get; set; }

        public int NumberOfVotes { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<StudyMaterial, MostVotedMaterialsViewModel>()
                .ForMember(d => d.MaterialTitle, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.SectionName, opt => opt.MapFrom(s => s.Section.Title))
                .ForMember(d => d.MaterialContent, opt => opt.MapFrom(s => s.Content.Substring(0, 200)))
                .ForMember(d => d.AuthorName, opt => opt.MapFrom(s => s.Author.FullName))
                .ForMember(d => d.NumberOfVotes, opt => opt.MapFrom(s => s.Votes.Count()))
                .ReverseMap();
        }
    }
}