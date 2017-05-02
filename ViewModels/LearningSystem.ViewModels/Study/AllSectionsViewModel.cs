namespace LearningSystem.ViewModels.Study
{
    using AutoMapper;
    using LearningSystem.Models;
    using LearningSystem.ViewModels.Infrastructure.Mapping;

    public class AllSectionsViewModel : IMapFrom<Section>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Section, AllSectionsViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title));
        }
    }
}