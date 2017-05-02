using System;

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using LearningSystem.Models;
using LearningSystem.ViewModels.Infrastructure.Mapping;

namespace LearningSystem.ViewModels.Comments
{
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

        //public void CreateMappings(IConfiguration configuration)
        //{
        //    configuration.CreateMap<Comment, PostCommentViewModel>()
        //        .ForMember(d => d.Content, opt => opt.MapFrom(s => s.Content));
        //}
    }
}
