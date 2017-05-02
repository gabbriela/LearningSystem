namespace LearningSystem.ViewModels.Test
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using LearningSystem.Common;
    using LearningSystem.Models;

    public class AddQuestionViewModel
    {
        [Required]
        [MaxLength(GlobalConstants.QuestionMaxLength), MinLength(GlobalConstants.QuestionMinLength)]
        public string Content { get; set; }

        [Required]
        public virtual ICollection<Answer> Answers { get; set; }

        [Required]
        [Display(Name = "Section")]
        [UIHint("DropDownList")]
        public int SectionId { get; set; }

        public IEnumerable<SelectListItem> Sections { get; set; }
    }
}
