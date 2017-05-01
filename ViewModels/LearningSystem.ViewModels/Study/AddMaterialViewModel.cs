using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LearningSystem.Common;
using LearningSystem.Models;
using LearningSystem.ViewModels.Infrastructure.Mapping;

namespace LearningSystem.ViewModels.Study
{
    public class AddMaterialViewModel : IMapFrom<StudyMaterial>
    {
        [Required]
        [UIHint("SingleLineText")]
        public string Title { get; set; }
        
        [Required]
        [MinLength(GlobalConstants.StudyMaterialContentMinLength)]
        [UIHint("MultiLineText")]
        public string Content { get; set; }

        [MaxLength(GlobalConstants.StudyMaterialDescriptionMaxLength)]
        [UIHint("MultiLineText")]
        public string Description { get; set; }

        [Required]
        [MaxLength(GlobalConstants.StudyMaterialSourceMaxLength)]
        [UIHint("SingleLineText")]
        public string Source { get; set; }

        [Required]
        [Display(Name = "Section")]
        [UIHint("DropDownList")]
        public int SectionId { get; set; }

        public IEnumerable<SelectListItem> Sections { get; set; }
    
        public HttpPostedFileBase UploadedImage { get; set; }
    }
}
