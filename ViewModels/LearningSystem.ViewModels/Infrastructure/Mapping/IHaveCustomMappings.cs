
using AutoMapper;

namespace LearningSystem.ViewModels.Infrastructure.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}