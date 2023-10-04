using Insttantt.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Insttantt.Data.DataAccess
{
    public class InsttanttDataDBContext : DbContext
    {
        public DbSet<Flow> Flows { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Field> Fields { get; set; }

        public InsttanttDataDBContext(DbContextOptions<InsttanttDataDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Field>()
            .HasMany(f => f.InputSteps)
            .WithOne(s => s.InputField)
            .HasForeignKey(s => s.InputFieldID)
            .OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<Field>()
                .HasMany(f => f.OutputSteps)
                .WithOne(s => s.OutputField)
                .HasForeignKey(s => s.OutputFieldID)
                .OnDelete(DeleteBehavior.Restrict); ;

            base.OnModelCreating(modelBuilder);
        }
    }
}
