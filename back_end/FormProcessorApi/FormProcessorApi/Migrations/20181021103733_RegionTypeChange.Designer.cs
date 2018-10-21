﻿// <auto-generated />
using System;
using FormProcessorApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FormProcessorApi.Migrations
{
    [DbContext(typeof(FormDetailsContext))]
    [Migration("20181021103733_RegionTypeChange")]
    partial class RegionTypeChange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("FormProcessorApi.Models.Answer", b =>
                {
                    b.Property<string>("AnswerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PixelCount");

                    b.Property<int?>("QuestionId");

                    b.Property<int?>("RegionBottomLeftAPointId");

                    b.Property<int?>("RegionBottomRightAPointId");

                    b.Property<int?>("RegionTopLeftAPointId");

                    b.Property<int?>("RegionTopRightAPointId");

                    b.Property<bool>("Selected");

                    b.Property<string>("Text");

                    b.HasKey("AnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("RegionBottomLeftAPointId");

                    b.HasIndex("RegionBottomRightAPointId");

                    b.HasIndex("RegionTopLeftAPointId");

                    b.HasIndex("RegionTopRightAPointId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("FormProcessorApi.Models.APoint", b =>
                {
                    b.Property<int>("APointId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("X");

                    b.Property<int>("Y");

                    b.HasKey("APointId");

                    b.ToTable("APoint");
                });

            modelBuilder.Entity("FormProcessorApi.Models.FormDetails", b =>
                {
                    b.Property<int>("FormDetailsId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Filename");

                    b.Property<bool>("IsTemplate");

                    b.Property<int>("TemplateId");

                    b.HasKey("FormDetailsId");

                    b.ToTable("FormDetails");
                });

            modelBuilder.Entity("FormProcessorApi.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FormDetailsId");

                    b.Property<int?>("RegionBottomLeftAPointId");

                    b.Property<int?>("RegionBottomRightAPointId");

                    b.Property<int?>("RegionTopLeftAPointId");

                    b.Property<int?>("RegionTopRightAPointId");

                    b.Property<string>("Text");

                    b.HasKey("QuestionId");

                    b.HasIndex("FormDetailsId");

                    b.HasIndex("RegionBottomLeftAPointId");

                    b.HasIndex("RegionBottomRightAPointId");

                    b.HasIndex("RegionTopLeftAPointId");

                    b.HasIndex("RegionTopRightAPointId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("FormProcessorApi.Models.Answer", b =>
                {
                    b.HasOne("FormProcessorApi.Models.Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");

                    b.HasOne("FormProcessorApi.Models.APoint", "RegionBottomLeft")
                        .WithMany()
                        .HasForeignKey("RegionBottomLeftAPointId");

                    b.HasOne("FormProcessorApi.Models.APoint", "RegionBottomRight")
                        .WithMany()
                        .HasForeignKey("RegionBottomRightAPointId");

                    b.HasOne("FormProcessorApi.Models.APoint", "RegionTopLeft")
                        .WithMany()
                        .HasForeignKey("RegionTopLeftAPointId");

                    b.HasOne("FormProcessorApi.Models.APoint", "RegionTopRight")
                        .WithMany()
                        .HasForeignKey("RegionTopRightAPointId");
                });

            modelBuilder.Entity("FormProcessorApi.Models.Question", b =>
                {
                    b.HasOne("FormProcessorApi.Models.FormDetails")
                        .WithMany("Questions")
                        .HasForeignKey("FormDetailsId");

                    b.HasOne("FormProcessorApi.Models.APoint", "RegionBottomLeft")
                        .WithMany()
                        .HasForeignKey("RegionBottomLeftAPointId");

                    b.HasOne("FormProcessorApi.Models.APoint", "RegionBottomRight")
                        .WithMany()
                        .HasForeignKey("RegionBottomRightAPointId");

                    b.HasOne("FormProcessorApi.Models.APoint", "RegionTopLeft")
                        .WithMany()
                        .HasForeignKey("RegionTopLeftAPointId");

                    b.HasOne("FormProcessorApi.Models.APoint", "RegionTopRight")
                        .WithMany()
                        .HasForeignKey("RegionTopRightAPointId");
                });
#pragma warning restore 612, 618
        }
    }
}
