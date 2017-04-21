using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningSystem.Web.ViewModels
{
    public class StudyMaterialViewModel
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public DateTime PublishDate { get; set; }

        public string Author { get; set; }
        
        public string Content { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
        
    }
}