using System;
using System.Collections.Generic;
using AutoMapper;
using LearningSystem.Models;
using LearningSystem.ViewModels.Infrastructure.Mapping;

namespace LearningSystem.ViewModels.Questions
{
    public class QuestionViewModel : IMapFrom<Question>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string SectionName { get; set; }
        
        public ICollection<AnswerViewModel> Answers { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Question, QuestionViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Content, opt => opt.MapFrom(s => s.Content))
                .ForMember(d => d.SectionName, opt => opt.MapFrom(s => s.Section.Title))
                .ForMember(d => d.Answers, opt => opt.MapFrom(s => s.Answers))
                .ReverseMap();
        }
    }
}
