using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using LearningSystem.Data;
using LearningSystem.Services.Base;
using LearningSystem.Services.Infrastructure.Contracts;
using LearningSystem.ViewModels.Questions;

namespace LearningSystem.Services.Questions
{
    public class QuestionService : BaseService, IQuestionsService
    {
        public QuestionService(ILearningSystemData data) 
            : base(data)
        {
        }

        public IEnumerable<QuestionViewModel> GetQuestionsBySection(int id)
        {
            var questionsBySection = this.Data
                .Questions
                .All()
                .Where(m => m.SectionId == id)
                .Project()
                .To<QuestionViewModel>()
                .ToList();

            return questionsBySection;
        }
        
    }
}
