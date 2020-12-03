﻿// <auto-generated />
using System;
using EphIt.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EphIt.Db.Migrations
{
    [DbContext(typeof(EphItContext))]
    partial class EphItContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EphIt.Db.Models.Audit", b =>
                {
                    b.Property<long>("Audit_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("ObjectId")
                        .HasColumnType("int");

                    b.Property<short>("RbacActionId")
                        .HasColumnType("smallint");

                    b.Property<short>("RbacObjectId")
                        .HasColumnType("smallint");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Audit_Id");

                    b.HasIndex("RbacActionId");

                    b.HasIndex("RbacObjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Audit");
                });

            modelBuilder.Entity("EphIt.Db.Models.Authentication", b =>
                {
                    b.Property<short>("AuthenticationId")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("AuthenticationId");

                    b.ToTable("Authentication");

                    b.HasData(
                        new
                        {
                            AuthenticationId = (short)1,
                            Name = "ActiveDirectory"
                        },
                        new
                        {
                            AuthenticationId = (short)2,
                            Name = "EphItInternal"
                        },
                        new
                        {
                            AuthenticationId = (short)3,
                            Name = "AzureActiveDirectory"
                        });
                });

            modelBuilder.Entity("EphIt.Db.Models.Job", b =>
                {
                    b.Property<Guid>("JobUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedByAutomationId")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedByScheduleId")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Finish")
                        .HasColumnType("datetime2");

                    b.Property<short>("JobStatusId")
                        .HasColumnType("smallint");

                    b.Property<int>("ScriptVersionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("JobUid");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("JobStatusId");

                    b.HasIndex("ScriptVersionId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("EphIt.Db.Models.JobLog", b =>
                {
                    b.Property<Guid>("JobLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("JobUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("LevelId")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("LogTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobLogId");

                    b.HasIndex("JobUid");

                    b.ToTable("JobLog");
                });

            modelBuilder.Entity("EphIt.Db.Models.JobParameters", b =>
                {
                    b.Property<Guid>("JobUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Parameters")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobUid");

                    b.ToTable("JobParameters");
                });

            modelBuilder.Entity("EphIt.Db.Models.JobQueue", b =>
                {
                    b.Property<Guid>("JobUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<short>("ScriptLanguage")
                        .HasColumnType("smallint");

                    b.Property<int>("ScriptVersionId")
                        .HasColumnType("int");

                    b.HasKey("JobUid");

                    b.ToTable("JobQueue");
                });

            modelBuilder.Entity("EphIt.Db.Models.JobStatus", b =>
                {
                    b.Property<short>("JobStatusId")
                        .HasColumnType("smallint");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("JobStatusId");

                    b.ToTable("JobStatus");

                    b.HasData(
                        new
                        {
                            JobStatusId = (short)1,
                            Status = "New"
                        },
                        new
                        {
                            JobStatusId = (short)2,
                            Status = "Queued"
                        },
                        new
                        {
                            JobStatusId = (short)3,
                            Status = "InProgress"
                        },
                        new
                        {
                            JobStatusId = (short)10,
                            Status = "Complete"
                        },
                        new
                        {
                            JobStatusId = (short)11,
                            Status = "Error"
                        },
                        new
                        {
                            JobStatusId = (short)12,
                            Status = "Cancelled"
                        });
                });

            modelBuilder.Entity("EphIt.Db.Models.RbacAction", b =>
                {
                    b.Property<short>("RbacActionId")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("RbacActionId");

                    b.ToTable("RbacAction");

                    b.HasData(
                        new
                        {
                            RbacActionId = (short)1,
                            Name = "Create"
                        },
                        new
                        {
                            RbacActionId = (short)2,
                            Name = "Read"
                        },
                        new
                        {
                            RbacActionId = (short)3,
                            Name = "Delete"
                        },
                        new
                        {
                            RbacActionId = (short)4,
                            Name = "Modify"
                        },
                        new
                        {
                            RbacActionId = (short)5,
                            Name = "Execute"
                        });
                });

            modelBuilder.Entity("EphIt.Db.Models.RbacObject", b =>
                {
                    b.Property<short>("RbacObjectId")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("RbacObjectId");

                    b.ToTable("RbacObject");

                    b.HasData(
                        new
                        {
                            RbacObjectId = (short)1,
                            Name = "Scripts"
                        },
                        new
                        {
                            RbacObjectId = (short)2,
                            Name = "Roles"
                        },
                        new
                        {
                            RbacObjectId = (short)3,
                            Name = "Variables"
                        },
                        new
                        {
                            RbacObjectId = (short)4,
                            Name = "Modules"
                        },
                        new
                        {
                            RbacObjectId = (short)5,
                            Name = "Jobs"
                        });
                });

            modelBuilder.Entity("EphIt.Db.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsGlobal")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("RoleId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("EphIt.Db.Models.RoleMembershipUser", b =>
                {
                    b.Property<int>("RoleMembershipUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoleMembershipUserId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleMembershipUser");
                });

            modelBuilder.Entity("EphIt.Db.Models.RoleObjectAction", b =>
                {
                    b.Property<int>("RoleObjectActionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("RbacActionId")
                        .HasColumnType("smallint");

                    b.Property<short>("RbacObjectId")
                        .HasColumnType("smallint");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("RoleObjectActionId");

                    b.HasIndex("RbacActionId");

                    b.HasIndex("RbacObjectId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleObjectAction");
                });

            modelBuilder.Entity("EphIt.Db.Models.RoleObjectScopeScript", b =>
                {
                    b.Property<int>("RoleObjectScopeScriptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("ScriptId")
                        .HasColumnType("int");

                    b.HasKey("RoleObjectScopeScriptId");

                    b.HasIndex("RoleId");

                    b.HasIndex("ScriptId");

                    b.ToTable("RoleObjectScopeScript");
                });

            modelBuilder.Entity("EphIt.Db.Models.Script", b =>
                {
                    b.Property<int>("ScriptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int?>("PublishedVersion")
                        .HasColumnType("int");

                    b.HasKey("ScriptId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("Script");
                });

            modelBuilder.Entity("EphIt.Db.Models.ScriptLanguage", b =>
                {
                    b.Property<short>("ScriptLanguageId")
                        .HasColumnType("smallint");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ScriptLanguageId");

                    b.ToTable("ScriptLanguage");

                    b.HasData(
                        new
                        {
                            ScriptLanguageId = (short)1,
                            Language = "PowerShell"
                        },
                        new
                        {
                            ScriptLanguageId = (short)2,
                            Language = "PowerShellCore"
                        });
                });

            modelBuilder.Entity("EphIt.Db.Models.ScriptVersion", b =>
                {
                    b.Property<int>("ScriptVersionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ScriptId")
                        .HasColumnType("int");

                    b.Property<short?>("ScriptLanguageId")
                        .HasColumnType("smallint");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("ScriptVersionId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("ScriptId");

                    b.HasIndex("ScriptLanguageId");

                    b.ToTable("ScriptVersion");
                });

            modelBuilder.Entity("EphIt.Db.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("AuthenticationId")
                        .HasColumnType("smallint");

                    b.HasKey("UserId");

                    b.HasIndex("AuthenticationId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = -1,
                            AuthenticationId = (short)2
                        });
                });

            modelBuilder.Entity("EphIt.Db.Models.UserActiveDirectory", b =>
                {
                    b.Property<int>("UserActiveDirectoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("SID")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("UserActiveDirectoryId");

                    b.HasIndex("UserId");

                    b.ToTable("UserActiveDirectory");
                });

            modelBuilder.Entity("EphIt.Db.Models.UserAzureActiveDirectory", b =>
                {
                    b.Property<int>("UserAzureActiveDirectoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("ObjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("UserAzureActiveDirectoryId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAzureActiveDirectory");
                });

            modelBuilder.Entity("EphIt.Db.Models.Audit", b =>
                {
                    b.HasOne("EphIt.Db.Models.RbacAction", "RbacAction")
                        .WithMany("Audit")
                        .HasForeignKey("RbacActionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EphIt.Db.Models.RbacObject", "RbacObject")
                        .WithMany("Audit")
                        .HasForeignKey("RbacObjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EphIt.Db.Models.User", "User")
                        .WithMany("Audit")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("EphIt.Db.Models.Job", b =>
                {
                    b.HasOne("EphIt.Db.Models.User", "CreatedByUser")
                        .WithMany("Job")
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EphIt.Db.Models.JobStatus", "JobStatus")
                        .WithMany("Job")
                        .HasForeignKey("JobStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EphIt.Db.Models.ScriptVersion", "ScriptVersion")
                        .WithMany("Jobs")
                        .HasForeignKey("ScriptVersionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("EphIt.Db.Models.JobLog", b =>
                {
                    b.HasOne("EphIt.Db.Models.Job", "JobU")
                        .WithMany("JobLog")
                        .HasForeignKey("JobUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EphIt.Db.Models.JobParameters", b =>
                {
                    b.HasOne("EphIt.Db.Models.Job", "Job")
                        .WithOne("JobParameters")
                        .HasForeignKey("EphIt.Db.Models.JobParameters", "JobUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EphIt.Db.Models.JobQueue", b =>
                {
                    b.HasOne("EphIt.Db.Models.Job", "Job")
                        .WithOne("JobQueue")
                        .HasForeignKey("EphIt.Db.Models.JobQueue", "JobUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EphIt.Db.Models.Role", b =>
                {
                    b.HasOne("EphIt.Db.Models.User", "CreatedByUser")
                        .WithMany("RoleCreatedByUser")
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EphIt.Db.Models.User", "ModifiedByUser")
                        .WithMany("RoleModifiedByUser")
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EphIt.Db.Models.RoleMembershipUser", b =>
                {
                    b.HasOne("EphIt.Db.Models.Role", "Role")
                        .WithMany("RoleMembershipUser")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EphIt.Db.Models.User", "User")
                        .WithMany("RoleMembershipUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("EphIt.Db.Models.RoleObjectAction", b =>
                {
                    b.HasOne("EphIt.Db.Models.RbacAction", "RbacAction")
                        .WithMany("RoleObjectAction")
                        .HasForeignKey("RbacActionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EphIt.Db.Models.RbacObject", "RbacObject")
                        .WithMany("RoleObjectAction")
                        .HasForeignKey("RbacObjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EphIt.Db.Models.Role", "Role")
                        .WithMany("RoleObjectAction")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EphIt.Db.Models.RoleObjectScopeScript", b =>
                {
                    b.HasOne("EphIt.Db.Models.Role", "Role")
                        .WithMany("RoleObjectScopeScript")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EphIt.Db.Models.Script", "Script")
                        .WithMany("RoleObjectScopeScript")
                        .HasForeignKey("ScriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EphIt.Db.Models.Script", b =>
                {
                    b.HasOne("EphIt.Db.Models.User", "CreatedByUser")
                        .WithMany("ScriptCreatedByUser")
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EphIt.Db.Models.User", "ModifiedByUser")
                        .WithMany("ScriptModifiedByUser")
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("EphIt.Db.Models.ScriptVersion", b =>
                {
                    b.HasOne("EphIt.Db.Models.User", "CreatedByUser")
                        .WithMany("ScriptVersion")
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EphIt.Db.Models.Script", "Script")
                        .WithMany("ScriptVersion")
                        .HasForeignKey("ScriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EphIt.Db.Models.ScriptLanguage", "ScriptLanguage")
                        .WithMany("ScriptVersion")
                        .HasForeignKey("ScriptLanguageId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EphIt.Db.Models.User", b =>
                {
                    b.HasOne("EphIt.Db.Models.Authentication", "Authentication")
                        .WithMany("User")
                        .HasForeignKey("AuthenticationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("EphIt.Db.Models.UserActiveDirectory", b =>
                {
                    b.HasOne("EphIt.Db.Models.User", "User")
                        .WithMany("UserActiveDirectory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EphIt.Db.Models.UserAzureActiveDirectory", b =>
                {
                    b.HasOne("EphIt.Db.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
