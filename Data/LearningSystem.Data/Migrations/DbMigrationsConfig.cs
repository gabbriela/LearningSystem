namespace LearningSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public sealed class DbMigrationsConfig : DbMigrationsConfiguration<LearningSystemDbContext>
    {
        public DbMigrationsConfig()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LearningSystemDbContext context)
        {
            // Seed initial data only if the database is empty
            if (!context.Users.Any())
            {
                var adminEmail = "admin@admin.com";
                var adminUserName = adminEmail;
                var adminFullName = "System Administrator";
                var adminPassword = adminEmail;
                string adminRole = "Administrator";
                this.CreateAdminUser(context, adminEmail, adminUserName, adminFullName, adminPassword, adminRole);
                
                this.CreateSeveralMaterials(context);
                this.CreateSeveralQuestions(context);
            }
        }

        private void CreateAdminUser(LearningSystemDbContext context, string adminEmail, string adminUserName, string adminFullName, string adminPassword, string adminRole)
        {
            // Create the "admin" user
            var adminUser = new User
            {
                UserName = adminUserName,
                FullName = adminFullName,
                Email = adminEmail
            };
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
            var userCreateResult = userManager.Create(adminUser, adminPassword);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }

            // Create the "Administrator" role
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(adminRole));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }

            // Add the "admin" user to "Administrator" role
            var addAdminRoleResult = userManager.AddToRole(adminUser.Id, adminRole);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }

        private void CreateSeveralMaterials(LearningSystemDbContext context)
        {
            context.StudyMaterials.Add(new StudyMaterial()
            {
                Title = "OOP",
                Section = new Section()
                {
                    Title = "Intro to programming",
                },
                Content = "sdafdadafafadw",
                Source = "bla bla"
            });

            context.StudyMaterials.Add(new StudyMaterial()
            {
                Title = "Data Bases",
                Comments = new HashSet<Comment>()
                {
                    new Comment()
                    {
                        Content = "User comment", Author = context.Users.First()
                    }
                },
                Section = new Section() { Title = "Intro to programming" },
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore " +
                          "et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip " +
                          "ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat " +
                          "nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Source = "bla bla"
            });

            context.StudyMaterials.Add(new StudyMaterial()
            {
                Title = "Web Forms",
                Comments = new HashSet<Comment>()
                {
                    new Comment()
                    {
                        Content = "User comment", Author = context.Users.First()
                    }
                },
                Section = new Section() { Title = "Intro to programming" },
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore " +
                          "et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip " +
                          "ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat " +
                          "nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Source = "bla bla"
            });

            context.StudyMaterials.Add(new StudyMaterial()
            {
                Title = "ASP",
                Comments = new HashSet<Comment>()
                {
                    new Comment()
                    {
                        Content = "<Anonymous> comment"
                    },
                    new Comment()
                    {
                        Content = "User comment", Author = context.Users.First()
                    },
                    new Comment()
                    {
                        Content = "Another <user> comment", Author = context.Users.First()
                    },
                    new Comment()
                    {
                        Content = "<Anonymous> comment"
                    },
                    new Comment()
                    {
                        Content = "User comment", Author = context.Users.First()
                    },
                    new Comment()
                    {
                        Content = "Another <user> comment", Author = context.Users.First()
                    }
                },
                Section = new Section()
                {
                    Title = "Intro to programming"
                },
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore " +
                          "et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip " +
                          "ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat " +
                          "nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Source = "bla bla"
            });

            context.StudyMaterials.Add(new StudyMaterial()
            {
                Title = "Identity",
                Comments = new HashSet<Comment>()
                {
                    new Comment()
                    {
                        Content = "User comment", Author = context.Users.First()
                    }
                },
                Section = new Section()
                {
                    Title = "Intro to programming"
                },
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore " +
                          "et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip " +
                          "ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat " +
                          "nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Source = "bla bla"
            });

            context.StudyMaterials.Add(new StudyMaterial()
            {
                Title = "CRUD",
                Comments = new HashSet<Comment>()
                {
                    new Comment()
                    {
                        Content = "User comment", Author = context.Users.First()
                    }
                },
                Section = new Section()
                {
                    Title = "Intro to programming"
                },
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore " +
                          "et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip " +
                          "ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat " +
                          "nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Source = "bla bla"
            });

            context.StudyMaterials.Add(new StudyMaterial()
            {
                Title = "SOLID",
                Comments = new HashSet<Comment>()
                {
                    new Comment()
                    {
                        Content = "<Anonymous> comment"
                    },
                    new Comment()
                    {
                        Content = "User comment", Author = context.Users.First()
                    },
                    new Comment()
                    {
                        Content = "Another <user> comment", Author = context.Users.First()
                    },
                    new Comment()
                    {
                        Content = "<Anonymous> comment"
                    },
                    new Comment()
                    {
                        Content = "User comment", Author = context.Users.First()
                    },
                    new Comment()
                    {
                        Content = "Another <user> comment", Author = context.Users.First()
                    }
                },
                Section = new Section()
                {
                    Title = "Intro to programming"
                },
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore " +
                          "et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip " +
                          "ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat " +
                          "nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Source = "bla bla"
            });

            context.SaveChanges();
        }

        private void CreateSeveralQuestions(LearningSystemDbContext context)
        {
            context.Questions.Add(new Question()
            {
                Content = "111111111111111111111111111",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "aaaaaaaaaaaaa",
                        Correct = false
                    },
                    new Answer()
                    {
                        Content = "bbbbbbbbbbbbb",
                        Correct = false
                    },
                    new Answer()
                    {
                        Content = "ccccccccccccc",
                        Correct = true
                    },
                    new Answer()
                    {
                        Content = "dddddddddddddd",
                        Correct = false
                    }
                },
                Section = context.Sections.FirstOrDefault()
            });

            context.Questions.Add(new Question()
            {
                Content = "222222222222222222222222222",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "aaaaaaaaaaaaa",
                        Correct = false
                    },
                    new Answer()
                    {
                        Content = "bbbbbbbbbbbbb",
                        Correct = false
                    },
                    new Answer()
                    {
                        Content = "ccccccccccccc",
                        Correct = true
                    },
                    new Answer()
                    {
                        Content = "dddddddddddddd",
                        Correct = false
                    }
                },
                Section = context.Sections.FirstOrDefault()
            });

            context.Questions.Add(new Question()
            {
                Content = "333333333333333333333333333333",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "aaaaaaaaaaaaa",
                        Correct = false
                    },
                    new Answer()
                    {
                        Content = "bbbbbbbbbbbbb",
                        Correct = false
                    },
                    new Answer()
                    {
                        Content = "ccccccccccccc",
                        Correct = true
                    },
                    new Answer()
                    {
                        Content = "dddddddddddddd",
                        Correct = false
                    }
                },
                Section = context.Sections.FirstOrDefault()
            });

            context.Questions.Add(new Question()
            {
                Content = "44444444444444444444444444444444444",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "aaaaaaaaaaaaa",
                        Correct = false
                    },
                    new Answer()
                    {
                        Content = "bbbbbbbbbbbbb",
                        Correct = false
                    },
                    new Answer()
                    {
                        Content = "ccccccccccccc",
                        Correct = true
                    },
                    new Answer()
                    {
                        Content = "dddddddddddddd",
                        Correct = false
                    }
                },
                Section = context.Sections.FirstOrDefault()
            });

            context.SaveChanges();
        }
    }
}
