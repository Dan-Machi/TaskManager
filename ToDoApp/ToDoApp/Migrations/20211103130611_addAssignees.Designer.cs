﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApp.Database;

namespace ToDoApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211103130611_addAssignees")]
    partial class addAssignees
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("ToDoApp.Models.Entities.Assignee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Assignees");
                });

            modelBuilder.Entity("ToDoApp.Models.Entities.Todo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("AssignedId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDone")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsUrgent")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AssignedId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("ToDoApp.Models.Entities.Todo", b =>
                {
                    b.HasOne("ToDoApp.Models.Entities.Assignee", "Assignee")
                        .WithMany("Todos")
                        .HasForeignKey("AssignedId");

                    b.Navigation("Assignee");
                });

            modelBuilder.Entity("ToDoApp.Models.Entities.Assignee", b =>
                {
                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
