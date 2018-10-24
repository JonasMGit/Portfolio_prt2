﻿using System;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
namespace DataLayer
{
    public class SOVAContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("host=localhost;db=stackedoverflow;uid=postgres;pwd=postgres");
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Map Class property: Post. Principal entity. Still has relation to comment
            modelBuilder.Entity<Post>().ToTable("posts");
            modelBuilder.Entity<Post>().Property(x => x.PostId).HasColumnName("id");
            modelBuilder.Entity<Post>().Property(x => x.Score).HasColumnName("score");
            modelBuilder.Entity<Post>().Property(x => x.CreationDate).HasColumnName("creationdate");
            modelBuilder.Entity<Post>().Property(x => x.Body).HasColumnName("body");
            modelBuilder.Entity<Post>().Property(x => x.AuthorId).HasColumnName("authorid");
            //foreign key to author. One post can have one author, but one author can have many posts
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Author)
                .WithMany(a => a.Posts)
                .HasForeignKey(p => p.AuthorId);



            //Map Class Propert: Question dependent entity
            modelBuilder.Entity<Question>().ToTable("questions");
            modelBuilder.Entity<Question>().Property(x => x.QuestionId).HasColumnName("id");
            modelBuilder.Entity<Question>().Property(x => x.ClosedDate).HasColumnName("closeddate");
            modelBuilder.Entity<Question>().Property(x => x.AcceptedAnswer).HasColumnName("acceptedanswer");
            modelBuilder.Entity<Question>().Property(x => x.Title).HasColumnName("title");
            //configure relationship to post.One-One relationship. Question has accepted answer, post has one answer. Should be done
            //Need to ask about foreign key mapping from question.id to post.id. If t even is a foreign key
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Post)
                .WithOne(p => p.Question)
                .HasForeignKey<Question>(q => q.AcceptedAnswer); 
                

            //Map Class Propert: Answer dependent entity. Foreign key parent
            modelBuilder.Entity<Answer>().ToTable("answers");
            modelBuilder.Entity<Answer>().Property(x => x.AnswerId).HasColumnName("id");
            modelBuilder.Entity<Answer>().Property(x => x.Parent).HasColumnName("parent");
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Post)
                .WithOne(p => p.Answer)
                .HasForeignKey<Answer>(q => q.Parent);

            //Map Class Propert: Author
            modelBuilder.Entity<Author>().ToTable("authors");
            modelBuilder.Entity<Author>().Property(x => x.AuthorId).HasColumnName("id");
            modelBuilder.Entity<Author>().Property(x => x.DisplayName).HasColumnName("displayname");
            modelBuilder.Entity<Author>().Property(x => x.CreationDate).HasColumnName("creationdate");
            modelBuilder.Entity<Author>().Property(x => x.Location).HasColumnName("location");
            modelBuilder.Entity<Author>().Property(x => x.Age).HasColumnName("age");

            //Map Class Propert: Comment 
            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<Comment>().Property(x => x.CommentId).HasColumnName("id");
            modelBuilder.Entity<Comment>().Property(x => x.Score).HasColumnName("score");
            modelBuilder.Entity<Comment>().Property(x => x.CreationDate).HasColumnName("creationdate");
            modelBuilder.Entity<Comment>().Property(x => x.Body).HasColumnName("body");
            modelBuilder.Entity<Comment>().Property(x => x.Parent).HasColumnName("parent");
            modelBuilder.Entity<Comment>().Property(x => x.AuthorId).HasColumnName("authorid");
            //may need feedback on all of ths foreign key stuff. 
            //author id needs to be configured as a foreign key as well??
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.Parent);

            //Map class propery: Tag. May not need this actually 
            modelBuilder.Entity<tag>().ToTable("tags");
            modelBuilder.Entity<tag>().HasKey(x => x.Tag);
            modelBuilder.Entity<tag>().Property(x => x.Tag).HasColumnName("tag");

            //Map class property: PostTag Id is still foreign key. Need to ask about this as well. 
            //tag does not need to be foreign key to tag. Can just use distinct keyword
            modelBuilder.Entity<PostTag>().ToTable("posttags");
            modelBuilder.Entity<PostTag>().Property(x => x.PostTagId).HasColumnName("id");
            modelBuilder.Entity<PostTag>().Property(x => x.Tag).HasColumnName("tag");


















        }

    }

}