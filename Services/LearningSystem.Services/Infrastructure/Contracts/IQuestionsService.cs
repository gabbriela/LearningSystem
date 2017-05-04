using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningSystem.ViewModels.Questions;

namespace LearningSystem.Services.Infrastructure.Contracts
{
    public interface IQuestionsService
    {
        IEnumerable<QuestionViewModel> GetQuestionsBySection(int id);
    }
}
