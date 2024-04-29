using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskTrackerBackend.Models;

namespace TaskTrackerBackend.Services.Context
{
    public class DataContext : DbContext
    {
        public DbSet<PostModels> PostInfo { get; set; }
        public DbSet<UserModels> UserInfo { get; set;}
        public DbSet<CommentsModels> CommentInfo {get; set;}
        public DbSet<AppModels> AppInfo { get; set; }

        public DataContext(DbContextOptions options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}