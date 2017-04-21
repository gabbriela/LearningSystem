using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningSystem.Web.ViewModels
{
    public class StudyMaterialInputModel
    {
        [Required(ErrorMessage = "Study material title is required.")]
        [StringLength(200, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 1)]
        [Display(Name = "Title *")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Study material content is required.")]
        [MinLength(200, ErrorMessage = "Minimum content: 200 characters")]
        [Display(Name = "Content")]
        public string Content { get; set; }

        
    }
}