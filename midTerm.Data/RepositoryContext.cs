using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using midTerm.Data.Entities;

namespace midTerm.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Answers> Answers { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet<SurveyUser> SurveyUsers { get; set; }
    }
}
