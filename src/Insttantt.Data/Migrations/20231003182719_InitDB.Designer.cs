﻿// <auto-generated />
using System;
using Insttantt.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Insttantt.Data.Migrations
{
    [DbContext(typeof(InsttanttDataDBContext))]
    [Migration("20231003182719_InitDB")]
    partial class InitDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Insttantt.Data.Entities.Field", b =>
                {
                    b.Property<int>("FieldID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FieldID"));

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FieldID");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("Insttantt.Data.Entities.Flow", b =>
                {
                    b.Property<int>("FlowID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlowID"));

                    b.Property<string>("FlowName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlowID");

                    b.ToTable("Flows");
                });

            modelBuilder.Entity("Insttantt.Data.Entities.Step", b =>
                {
                    b.Property<int>("StepID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StepID"));

                    b.Property<int?>("FieldID")
                        .HasColumnType("int");

                    b.Property<int?>("FieldID1")
                        .HasColumnType("int");

                    b.Property<int>("FlowID")
                        .HasColumnType("int");

                    b.Property<int>("InputFieldID")
                        .HasColumnType("int");

                    b.Property<int>("OutputFieldID")
                        .HasColumnType("int");

                    b.Property<string>("StepName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StepID");

                    b.HasIndex("FieldID");

                    b.HasIndex("FieldID1");

                    b.HasIndex("FlowID");

                    b.HasIndex("InputFieldID");

                    b.HasIndex("OutputFieldID");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("Insttantt.Data.Entities.Step", b =>
                {
                    b.HasOne("Insttantt.Data.Entities.Field", null)
                        .WithMany("InputSteps")
                        .HasForeignKey("FieldID");

                    b.HasOne("Insttantt.Data.Entities.Field", null)
                        .WithMany("OutputSteps")
                        .HasForeignKey("FieldID1");

                    b.HasOne("Insttantt.Data.Entities.Flow", "Flow")
                        .WithMany("Steps")
                        .HasForeignKey("FlowID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Insttantt.Data.Entities.Field", "InputField")
                        .WithMany()
                        .HasForeignKey("InputFieldID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Insttantt.Data.Entities.Field", "OutputField")
                        .WithMany()
                        .HasForeignKey("OutputFieldID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flow");

                    b.Navigation("InputField");

                    b.Navigation("OutputField");
                });

            modelBuilder.Entity("Insttantt.Data.Entities.Field", b =>
                {
                    b.Navigation("InputSteps");

                    b.Navigation("OutputSteps");
                });

            modelBuilder.Entity("Insttantt.Data.Entities.Flow", b =>
                {
                    b.Navigation("Steps");
                });
#pragma warning restore 612, 618
        }
    }
}