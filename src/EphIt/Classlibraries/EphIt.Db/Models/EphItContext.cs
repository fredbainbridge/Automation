﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EphIt.Db.Models
{
    public partial class EphItContext : DbContext
    {
        public EphItContext()
        {
        }

        public EphItContext(DbContextOptions<EphItContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authentication> Authentication { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobLog> JobLog { get; set; }
        public virtual DbSet<JobStatus> JobStatus { get; set; }
        public virtual DbSet<RbacAction> RbacAction { get; set; }
        public virtual DbSet<RbacObject> RbacObject { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleMembershipUser> RoleMembershipUser { get; set; }
        public virtual DbSet<RoleObjectAction> RoleObjectAction { get; set; }
        public virtual DbSet<RoleObjectScopeScript> RoleObjectScopeScript { get; set; }
        public virtual DbSet<Script> Script { get; set; }
        public virtual DbSet<ScriptLanguage> ScriptLanguage { get; set; }
        public virtual DbSet<ScriptVersion> ScriptVersion { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserActiveDirectory> UserActiveDirectory { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = Environment.GetEnvironmentVariable("EphItConnectionString");
                if (!String.IsNullOrEmpty(connectionString))
                {
                    optionsBuilder.UseSqlServer(connectionString);
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthenticationConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new JobLogConfiguration());
            modelBuilder.ApplyConfiguration(new JobStatusConfiguration());
            modelBuilder.ApplyConfiguration(new RbacActionConfiguration());
            modelBuilder.ApplyConfiguration(new RbacObjectConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleMembershipUserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleObjectActionConfiguration());
            modelBuilder.ApplyConfiguration(new RoleObjectScopeScriptConfiguration());
            modelBuilder.ApplyConfiguration(new ScriptConfiguration());
            modelBuilder.ApplyConfiguration(new ScriptLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new ScriptVersionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserActiveDirectoryConfiguration());

        }

    }
}
