﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskTrackerBackend.Services.Context;

#nullable disable

namespace TaskTrackerBackend.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskTrackerBackend.Models.AppModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ProfilePic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("AppInfo");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.BoardModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BoardID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("BoardInfo");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.CommentsModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostID")
                        .HasColumnType("int");

                    b.Property<int?>("PostModelsID")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PostModelsID");

                    b.ToTable("CommentInfo");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.DTO.CommentReplyDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CommentID")
                        .HasColumnType("int");

                    b.Property<int?>("CommentReplyDTOID")
                        .HasColumnType("int");

                    b.Property<int?>("CommentsModelsID")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostID")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CommentReplyDTOID");

                    b.HasIndex("CommentsModelsID");

                    b.ToTable("CommentReplyDTO");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.PostModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AssigneeID")
                        .HasColumnType("int");

                    b.Property<string>("BoardID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BoardModelID")
                        .HasColumnType("int");

                    b.Property<string>("DateCreated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PriorityLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BoardModelID");

                    b.ToTable("PostInfo");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.UserModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AccountCreated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.CommentsModels", b =>
                {
                    b.HasOne("TaskTrackerBackend.Models.PostModels", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostModelsID");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.DTO.CommentReplyDTO", b =>
                {
                    b.HasOne("TaskTrackerBackend.Models.DTO.CommentReplyDTO", null)
                        .WithMany("Replies")
                        .HasForeignKey("CommentReplyDTOID");

                    b.HasOne("TaskTrackerBackend.Models.CommentsModels", null)
                        .WithMany("Replies")
                        .HasForeignKey("CommentsModelsID");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.PostModels", b =>
                {
                    b.HasOne("TaskTrackerBackend.Models.BoardModel", null)
                        .WithMany("Posts")
                        .HasForeignKey("BoardModelID");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.BoardModel", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.CommentsModels", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.DTO.CommentReplyDTO", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.PostModels", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
