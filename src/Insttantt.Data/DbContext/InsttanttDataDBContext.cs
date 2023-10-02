using Insttantt.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Insttantt.Data.DbContext
{
    public class InsttanttDataDBContextDbContext : DbContext
    {
        public DbSet<Flow> Flows { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<InputField> InputFields { get; set; }
        public DbSet<OutputField> OutputFields { get; set; }
        public DbSet<User> Users { get; set; }

        public InsttanttDataDBContextDbContext(DbContextOptions<InsttanttDataDBContextDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Step>()
                .HasOne(s => s.Flow)
                .WithMany(f => f.Steps)
                .HasForeignKey(s => s.FlowId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
