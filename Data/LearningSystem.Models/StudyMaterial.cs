namespace LearningSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using LearningSystem.Common;

    public class StudyMaterial
    {
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;
        private ICollection<Image> images;

        public StudyMaterial()
        {
            this.PublishDate = DateTime.Now;
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<Vote>();
            this.images = new HashSet<Image>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.StudyMaterialTitleMaxLength), MinLength(GlobalConstants.StudyMaterialTitleMinLength)]
        public string Title { get; set; }

        [Display(Name = "Publish date")]
        public DateTime PublishDate { get; set; }

        [Required]
        [MinLength(GlobalConstants.StudyMaterialContentMinLength)]
        public string Content { get; set; }

        [MaxLength(GlobalConstants.StudyMaterialDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(GlobalConstants.StudyMaterialSourceMaxLength)]
        public string Source { get; set; }

        public int SectionId { get; set; }

        public virtual Section Section { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
    }
}
