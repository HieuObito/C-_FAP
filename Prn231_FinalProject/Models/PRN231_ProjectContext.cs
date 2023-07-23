using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Prn231_FinalProject.Models
{
    public partial class PRN231_ProjectContext : DbContext
    {
        public PRN231_ProjectContext()
        {
        }

        public PRN231_ProjectContext(DbContextOptions<PRN231_ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassSlotDate> ClassSlotDates { get; set; }
        public virtual DbSet<Mentor> Mentors { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Slot> Slots { get; set; }
        public virtual DbSet<SlotDate> SlotDates { get; set; }
        public virtual DbSet<Specialized> Specializeds { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentClass> StudentClasses { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<WeekDay> WeekDays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server = localhost; database =PRN231_Project; uid=sa; pwd=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Account__RoleID__0519C6AF");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassName).HasMaxLength(10);

                entity.Property(e => e.DateFrom).HasColumnType("smalldatetime");

                entity.Property(e => e.DateTo).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Mentor)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.MentorId)
                    .HasConstraintName("FK__Class__MentorId__276EDEB3");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Class__SubjectId__286302EC");
            });

            modelBuilder.Entity<ClassSlotDate>(entity =>
            {
                entity.HasKey(e => e.ClassSlotDate1)
                    .HasName("PK__ClassSlo__6356D1FA2B3F6F97");

                entity.ToTable("ClassSlotDate");

                entity.Property(e => e.ClassSlotDate1).HasColumnName("ClassSlotDate");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassSlotDates)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__ClassSlot__Class__2D27B809");

                entity.HasOne(d => d.SlotDate)
                    .WithMany(p => p.ClassSlotDates)
                    .HasForeignKey(d => d.SlotDateId)
                    .HasConstraintName("FK__ClassSlot__SlotD__2E1BDC42");
            });

            modelBuilder.Entity<Mentor>(entity =>
            {
                entity.ToTable("Mentor");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.ToTable("Slot");

                entity.Property(e => e.TimeFrom).HasColumnName("Time_from");

                entity.Property(e => e.TimeTo).HasColumnName("Time_to");
            });

            modelBuilder.Entity<SlotDate>(entity =>
            {
                entity.ToTable("Slot_Date");

                entity.HasOne(d => d.Date)
                    .WithMany(p => p.SlotDates)
                    .HasForeignKey(d => d.DateId)
                    .HasConstraintName("FK__Slot_Date__DateI__1273C1CD");

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.SlotDates)
                    .HasForeignKey(d => d.SlotId)
                    .HasConstraintName("FK__Slot_Date__SlotI__117F9D94");
            });

            modelBuilder.Entity<Specialized>(entity =>
            {
                entity.ToTable("Specialized");

                entity.Property(e => e.SpecializedCode).HasMaxLength(10);

                entity.Property(e => e.SpecializedName).HasMaxLength(10);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.StudentCode).HasMaxLength(10);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Student__Account__1B0907CE");
            });

            modelBuilder.Entity<StudentClass>(entity =>
            {
                entity.HasKey(e => e.StudentClass1)
                    .HasName("PK__StudentC__D213A27E30F848ED");

                entity.ToTable("StudentClass");

                entity.Property(e => e.StudentClass1).HasColumnName("StudentClass");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.StudentClasses)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__StudentCl__Class__33D4B598");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentClasses)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentCl__Stude__32E0915F");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectCode).HasMaxLength(10);

                entity.Property(e => e.SubjectName).HasMaxLength(10);
            });

            modelBuilder.Entity<WeekDay>(entity =>
            {
                entity.HasKey(e => e.DateId)
                    .HasName("PK__WeekDays__A426F2330BC6C43E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
