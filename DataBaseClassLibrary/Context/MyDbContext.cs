using System;
using System.Collections.Generic;
using DataBaseClassLibrary.Entities.Schedules;
using DataBaseClassLibrary.Entities.Comission;
using DataBaseClassLibrary.Entities.PersonalData;
using Microsoft.EntityFrameworkCore;

namespace DataBaseClassLibrary.Context;

/// <summary>
/// Class for creating dataBase context. Class is abstract and if you want to create a context - use OpenConnectionDataBase class
/// </summary>
public abstract partial class MyDbContext : DbContext
{
    protected MyDbContext()
    {
    }

    protected MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<DocumentKey> DocumentKeys { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<DocumentData> DocumentsData { get; set; }

    public virtual DbSet<DocumentsImage> DocumentsImages { get; set; }

    public virtual DbSet<FormsEducationSpecialization> FormsEducationSpecializations { get; set; }

    public virtual DbSet<FormsEducationSpecializationApplicant> FormsEducationSpecializationApplicants { get; set; }

    public virtual DbSet<FormsSpecialization> FormsSpecializations { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<KeysForDocument> KeysForDocuments { get; set; }

    public virtual DbSet<PersonalAccountData> PersonalAccountsData { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<Specialty> Specialties { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Timeslot> Timeslots { get; set; }

    public virtual DbSet<TypeFinancing> TypeFinancings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=0201");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("personalData", "pgcrypto")
            .HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.ApplicantId).HasName("applicants_pkey");

            entity.ToTable("applicants", "comission");

            entity.HasIndex(e => e.Snils, "applicants_snils_key").IsUnique();

            entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");
            entity.Property(e => e.AverageScore)
                .HasPrecision(3, 2)
                .HasColumnName("average_score");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.DateRegistry)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("date_registry");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name");
            entity.Property(e => e.Snils)
                .HasMaxLength(11)
                .HasColumnName("snils");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NONE'::character varying")
                .HasColumnName("status");
        });

        modelBuilder.Entity<DocumentKey>(entity =>
        {
            entity.HasKey(e => e.DocumentKeyId).HasName("document_keys_pkey");

            entity.ToTable("documentKeys", "comission");

            entity.Property(e => e.DocumentKeyId)
                .HasDefaultValueSql("nextval('comission.document_keys_document_key_id_seq'::regclass)")
                .HasColumnName("document_key_id");
            entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.DocumentKeys)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document_keys_document_type_id_fkey");

            entity.HasOne(d => d.NameNavigation).WithMany(p => p.DocumentKeys)
                .HasForeignKey(d => d.Name)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document_keys_keys_for_documents_name_fk");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.DocumentTypeId).HasName("document_types_pkey");

            entity.ToTable("documentTypes", "comission");

            entity.Property(e => e.DocumentTypeId)
                .HasDefaultValueSql("nextval('comission.document_types_document_type_id_seq'::regclass)")
                .HasColumnName("document_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DocumentData>(entity =>
        {
            entity.HasKey(e => e.DocumentDataId).HasName("document_data_pkey");

            entity.ToTable("documentdata", "comission");

            entity.Property(e => e.DocumentDataId)
                .HasDefaultValueSql("nextval('comission.document_data_document_data_id_seq'::regclass)")
                .HasColumnName("document_data_id");
            entity.Property(e => e.DataValue).HasColumnName("data_value");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.DocumentKeyId).HasColumnName("document_key_id");

            entity.HasOne(d => d.Document).WithMany(p => p.Documentdata)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document_data_document_id_fkey");

            entity.HasOne(d => d.DocumentKey).WithMany(p => p.Documentdata)
                .HasForeignKey(d => d.DocumentKeyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document_data_document_key_id_fkey");
        });

        modelBuilder.Entity<DocumentsImage>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("documents_image_pkey");

            entity.ToTable("documentsImage", "comission");

            entity.Property(e => e.DocumentId)
                .HasDefaultValueSql("nextval('comission.documents_image_document_id_seq'::regclass)")
                .HasColumnName("document_id");
            entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");
            entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");
            entity.Property(e => e.Photo).HasColumnName("photo");

            entity.HasOne(d => d.Applicant).WithMany(p => p.DocumentsImages)
                .HasForeignKey(d => d.ApplicantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("documents_image_applicant_id_fkey");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.DocumentsImages)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("documents_image_document_type_id_fkey");
        });

        modelBuilder.Entity<FormsEducationSpecialization>(entity =>
        {
            entity.HasKey(e => e.FormsEducationId).HasName("forms_education_specialization_pkey");

            entity.ToTable("formsEducationSpecialization", "comission");

            entity.Property(e => e.FormsEducationId)
                .HasDefaultValueSql("nextval('comission.forms_education_specialization_forms_education_id_seq'::regclass)")
                .HasColumnName("forms_education_id");
            entity.Property(e => e.CountPlaces).HasColumnName("count_places");
            entity.Property(e => e.DateEnrollment).HasColumnName("date_enrollment");
            entity.Property(e => e.EducationBase)
                .HasMaxLength(100)
                .HasColumnName("education_base");
            entity.Property(e => e.FormEducation).HasColumnName("form_education");
            entity.Property(e => e.SpecializationId)
                .HasMaxLength(20)
                .HasColumnName("specialization_id");
            entity.Property(e => e.TypeFinancing).HasColumnName("type_financing");

            entity.HasOne(d => d.FormEducationNavigation).WithMany(p => p.FormsEducationSpecializations)
                .HasForeignKey(d => d.FormEducation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("forms_education_specialization_form_education_fkey");

            entity.HasOne(d => d.Specialization).WithMany(p => p.FormsEducationSpecializations)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("forms_education_specialization_specialization_id_fkey");

            entity.HasOne(d => d.TypeFinancingNavigation).WithMany(p => p.FormsEducationSpecializations)
                .HasForeignKey(d => d.TypeFinancing)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("forms_education_specialization_type_financing_fkey");
        });

        modelBuilder.Entity<FormsEducationSpecializationApplicant>(entity =>
        {
            entity.HasKey(e => new { e.ApplicantId, e.FormsEducationId }).HasName("forms_education_specialization_applicants_pkey");

            entity.ToTable("formsEducationSpecializationApplicants", "comission");

            entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");
            entity.Property(e => e.FormsEducationId).HasColumnName("forms_education_id");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");

            entity.HasOne(d => d.Applicant).WithMany(p => p.FormsEducationSpecializationApplicants)
                .HasForeignKey(d => d.ApplicantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("forms_education_specialization_applicants_applicant_id_fkey");

            entity.HasOne(d => d.FormsEducation).WithMany(p => p.FormsEducationSpecializationApplicants)
                .HasForeignKey(d => d.FormsEducationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("forms_education_specialization_applican_forms_education_id_fkey");
        });

        modelBuilder.Entity<FormsSpecialization>(entity =>
        {
            entity.HasKey(e => e.FormEducationId).HasName("forms_specialization_pkey");

            entity.ToTable("formsSpecialization", "comission");

            entity.Property(e => e.FormEducationId)
                .HasDefaultValueSql("nextval('comission.forms_specialization_form_education_id_seq'::regclass)")
                .HasColumnName("form_education_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("groups_pkey");

            entity.ToTable("groups", "schedule");

            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.Course).HasColumnName("course");
            entity.Property(e => e.GroupName)
                .HasMaxLength(255)
                .HasColumnName("group_name");
            entity.Property(e => e.SpecialtyId).HasColumnName("specialty_id");

            entity.HasOne(d => d.Specialty).WithMany(p => p.Groups)
                .HasForeignKey(d => d.SpecialtyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("groups_specialty_id_fkey");
        });

        modelBuilder.Entity<KeysForDocument>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("keys_for_documents_pk");

            entity.ToTable("keysForDocuments", "comission");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<PersonalAccountData>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("personal_account_data_pkey");

            entity.ToTable("personalAccountData", "personalData");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('\"personalData\".personal_account_data_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Applicants).HasColumnName("applicants");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasColumnName("user_name");

            entity.HasOne(d => d.ApplicantsNavigation).WithMany(p => p.PersonalAccountData)
                .HasForeignKey(d => d.Applicants)
                .HasConstraintName("personal_account_data_applicants_fkey");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("rooms_pkey");

            entity.ToTable("rooms", "schedule");

            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Equipment)
                .HasMaxLength(255)
                .HasColumnName("equipment");
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(50)
                .HasColumnName("room_number");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("schedule_pkey");

            entity.ToTable("schedule", "schedule");

            entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.TimeSlotId).HasColumnName("time_slot_id");

            entity.HasOne(d => d.Group).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_group_id_fkey");

            entity.HasOne(d => d.Room).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_room_id_fkey");

            entity.HasOne(d => d.Subject).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_subject_id_fkey");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_teacher_id_fkey");

            entity.HasOne(d => d.TimeSlot).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.TimeSlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_time_slot_id_fkey");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.SpecializationId).HasName("specializations_pkey");

            entity.ToTable("specializations", "comission");

            entity.Property(e => e.SpecializationId)
                .HasMaxLength(20)
                .HasColumnName("specialization_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Specialty>(entity =>
        {
            entity.HasKey(e => e.SpecialtyId).HasName("specialties_pkey");

            entity.ToTable("specialties", "schedule");

            entity.Property(e => e.SpecialtyId).HasColumnName("specialty_id");
            entity.Property(e => e.SpecialtyName)
                .HasMaxLength(255)
                .HasColumnName("specialty_name");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("subjects_pkey");

            entity.ToTable("subjects", "schedule");

            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.Course).HasColumnName("course");
            entity.Property(e => e.SpecialtyId).HasColumnName("specialty_id");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(255)
                .HasColumnName("subject_name");

            entity.HasOne(d => d.Specialty).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.SpecialtyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subjects_specialty_id_fkey");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("teachers_pkey");

            entity.ToTable("teachers", "schedule");

            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.ContactInfo)
                .HasMaxLength(255)
                .HasColumnName("contact_info");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
        });

        modelBuilder.Entity<Timeslot>(entity =>
        {
            entity.HasKey(e => e.TimeSlotId).HasName("timeslots_pkey");

            entity.ToTable("timeslots", "schedule");

            entity.Property(e => e.TimeSlotId).HasColumnName("time_slot_id");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(50)
                .HasColumnName("day_of_week");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
        });

        modelBuilder.Entity<TypeFinancing>(entity =>
        {
            entity.HasKey(e => e.TypeFinancingId).HasName("type_financing_pkey");

            entity.ToTable("typeFinancing", "comission");

            entity.Property(e => e.TypeFinancingId)
                .HasDefaultValueSql("nextval('comission.type_financing_type_financing_id_seq'::regclass)")
                .HasColumnName("type_financing_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
