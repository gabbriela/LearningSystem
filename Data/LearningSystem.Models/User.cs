namespace LearningSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using LearningSystem.Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Comment> comments;
        private ICollection<StudyMaterial> materials;

        public User()
        {
            this.comments = new HashSet<Comment>();
            this.materials = new List<StudyMaterial>();
        }

        [Required]
        [MaxLength(GlobalConstants.UserFullNameMaxLength)]
        [Display(Name = "User")]
        public string FullName { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<StudyMaterial> Materials
        {
            get { return this.materials; }
            set { this.materials = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            // Add custom user claims here
            return userIdentity;
        }
    }
}
