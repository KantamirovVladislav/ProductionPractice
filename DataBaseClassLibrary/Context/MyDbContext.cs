using System;
using System.Collections.Generic;
using DataBaseClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBaseClassLibrary.Context;

public partial class MyDbContext : DbContext
{
    private string userName;
    private string userPassword;
    
    public MyDbContext()
    {
    }

    public MyDbContext(string userName, string userPassword)
    {
        this.userName = userName;
        this.userPassword = userPassword;
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<Applicantsanddocumentsdatum> Applicantsanddocumentsdata { get; set; }

    public virtual DbSet<Applicantsandeducation> Applicantsandeducations { get; set; }

    public virtual DbSet<Applicantsdocumentimage> Applicantsdocumentimages { get; set; }

    public virtual DbSet<Commission> Commissions { get; set; }

    public virtual DbSet<DocumentKey> DocumentKeys { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Documentdatum> Documentdata { get; set; }

    public virtual DbSet<DocumentsImage> DocumentsImages { get; set; }

    public virtual DbSet<Educationbase> Educationbases { get; set; }

    public virtual DbSet<FormsEducationSpecialization> FormsEducationSpecializations { get; set; }

    public virtual DbSet<FormsEducationSpecializationApplicant> FormsEducationSpecializationApplicants { get; set; }

    public virtual DbSet<FormsSpecialization> FormsSpecializations { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Keysfordocument> Keysfordocuments { get; set; }

    public virtual DbSet<PersonalAccountDatum> PersonalAccountData { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Scheduletimeslot> Scheduletimeslots { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<Specialty> Specialties { get; set; }

    public virtual DbSet<Specialtysubject> Specialtysubjects { get; set; }

    public virtual DbSet<Statusesapplicant> Statusesapplicants { get; set; }

    public virtual DbSet<Statusesforapplicant> Statusesforapplicants { get; set; }

    public virtual DbSet<Statusesforeducation> Statusesforeducations { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Timeslot> Timeslots { get; set; }

    public virtual DbSet<TypeFinancing> TypeFinancings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql($"Host=localhost;Port=5432;Database=postgres;Username={userName};Password={userPassword}");

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
            entity.Property(e => e.Preferentialcount)
                .HasDefaultValue(0)
                .HasColumnName("preferentialcount");
            entity.Property(e => e.Snils)
                .HasMaxLength(11)
                .HasColumnName("snils");
        });

        modelBuilder.Entity<Applicantsanddocumentsdatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("applicantsanddocumentsdata", "comission");

            entity.Property(e => e.DataValue).HasColumnName("data_value");
            entity.Property(e => e.Documenttype)
                .HasMaxLength(50)
                .HasColumnName("documenttype");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.Keyname)
                .HasMaxLength(50)
                .HasColumnName("keyname");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Snils)
                .HasMaxLength(11)
                .HasColumnName("snils");
        });

        modelBuilder.Entity<Applicantsandeducation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("applicantsandeducation", "comission");

            entity.Property(e => e.AverageScore)
                .HasPrecision(3, 2)
                .HasColumnName("average_score");
            entity.Property(e => e.Finansingname)
                .HasMaxLength(255)
                .HasColumnName("finansingname");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name");
            entity.Property(e => e.Preferentialcount).HasColumnName("preferentialcount");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.Snils)
                .HasMaxLength(11)
                .HasColumnName("snils");
            entity.Property(e => e.Specialityname)
                .HasMaxLength(255)
                .HasColumnName("specialityname");
            entity.Property(e => e.SpecializationId)
                .HasMaxLength(20)
                .HasColumnName("specialization_id");
            entity.Property(e => e.Statusname)
                .HasMaxLength(255)
                .HasColumnName("statusname");
        });

        modelBuilder.Entity<Applicantsdocumentimage>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("applicantsdocumentimage", "comission");

            entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Snils)
                .HasMaxLength(11)
                .HasColumnName("snils");
            entity.Property(e => e.Typename)
                .HasMaxLength(50)
                .HasColumnName("typename");
        });

        modelBuilder.Entity<Commission>(entity =>
        {
            entity.HasKey(e => e.CommissionId).HasName("commissions_pkey");

            entity.ToTable("commissions", "schedule");

            entity.Property(e => e.CommissionId).HasColumnName("commission_id");
            entity.Property(e => e.CommissionName)
                .HasMaxLength(100)
                .HasColumnName("commission_name");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EstablishedDate).HasColumnName("established_date");
            entity.Property(e => e.HeadTeacherId).HasColumnName("head_teacher_id");

            entity.HasOne(d => d.HeadTeacher).WithMany(p => p.Commissions)
                .HasForeignKey(d => d.HeadTeacherId)
                .HasConstraintName("fk_head_teacher");
        });

        modelBuilder.Entity<DocumentKey>(entity =>
        {
            entity.HasKey(e => new { e.IdKeys, e.DocumentTypeId }).HasName("documentkeys_pk");

            entity.ToTable("documentKeys", "comission");

            entity.Property(e => e.IdKeys).HasColumnName("id_keys");
            entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.DocumentKeys)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document_keys_document_type_id_fkey");

            entity.HasOne(d => d.IdKeysNavigation).WithMany(p => p.DocumentKeys)
                .HasForeignKey(d => d.IdKeys)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("documentkeys_keysfordocuments_key_id_fk");
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

        modelBuilder.Entity<Documentdatum>(entity =>
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

        modelBuilder.Entity<Educationbase>(entity =>
        {
            entity.HasKey(e => e.BaseId).HasName("educationbase_pk");

            entity.ToTable("educationbase", "comission");

            entity.Property(e => e.BaseId).HasColumnName("base_id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
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
            entity.Property(e => e.EducationBase).HasColumnName("education_base");
            entity.Property(e => e.FormEducation).HasColumnName("form_education");
            entity.Property(e => e.SpecializationId)
                .HasMaxLength(20)
                .HasColumnName("specialization_id");
            entity.Property(e => e.TypeFinancing).HasColumnName("type_financing");

            entity.HasOne(d => d.EducationBaseNavigation).WithMany(p => p.FormsEducationSpecializations)
                .HasForeignKey(d => d.EducationBase)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("formseducationspecialization_educationbase_base_id_fk");

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
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("status");

            entity.HasOne(d => d.Applicant).WithMany(p => p.FormsEducationSpecializationApplicants)
                .HasForeignKey(d => d.ApplicantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("forms_education_specialization_applicants_applicant_id_fkey");

            entity.HasOne(d => d.FormsEducation).WithMany(p => p.FormsEducationSpecializationApplicants)
                .HasForeignKey(d => d.FormsEducationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("forms_education_specialization_applican_forms_education_id_fkey");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.FormsEducationSpecializationApplicants)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("formseducationspecializationapplicants_statuses_id_status_fk");
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
            entity.Property(e => e.BudgetOrPaid)
                .HasMaxLength(10)
                .HasColumnName("budget_or_paid");
            entity.Property(e => e.Course).HasColumnName("course");
            entity.Property(e => e.GroupName)
                .HasMaxLength(50)
                .HasColumnName("group_name");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.SpecialtyId).HasColumnName("specialty_id");

            entity.HasOne(d => d.Specialty).WithMany(p => p.Groups)
                .HasForeignKey(d => d.SpecialtyId)
                .HasConstraintName("fk_specialty_group");
        });

        modelBuilder.Entity<Keysfordocument>(entity =>
        {
            entity.HasKey(e => e.KeyId).HasName("keysfordocuments_pk");

            entity.ToTable("keysfordocuments", "comission");

            entity.Property(e => e.KeyId).HasColumnName("key_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<PersonalAccountDatum>(entity =>
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
            entity.Property(e => e.Equipment).HasColumnName("equipment");
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(10)
                .HasColumnName("room_number");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("schedule_pkey");

            entity.ToTable("schedule", "schedule");

            entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");
            entity.Property(e => e.AcademicYear)
                .HasMaxLength(9)
                .HasColumnName("academic_year");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.SpecialtySubjectId).HasColumnName("specialty_subject_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Group).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("fk_group");

            entity.HasOne(d => d.Room).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("fk_room");

            entity.HasOne(d => d.SpecialtySubject).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.SpecialtySubjectId)
                .HasConstraintName("fk_specialty_subject");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("fk_teacher");
        });

        modelBuilder.Entity<Scheduletimeslot>(entity =>
        {
            entity.HasKey(e => e.ScheduleTimeSlotId).HasName("scheduletimeslots_pkey");

            entity.ToTable("scheduletimeslots", "schedule");

            entity.Property(e => e.ScheduleTimeSlotId).HasColumnName("schedule_time_slot_id");
            entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");
            entity.Property(e => e.TimeSlotId).HasColumnName("time_slot_id");

            entity.HasOne(d => d.Schedule).WithMany(p => p.Scheduletimeslots)
                .HasForeignKey(d => d.ScheduleId)
                .HasConstraintName("fk_schedule");

            entity.HasOne(d => d.TimeSlot).WithMany(p => p.Scheduletimeslots)
                .HasForeignKey(d => d.TimeSlotId)
                .HasConstraintName("fk_time_slot");
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
                .HasMaxLength(100)
                .HasColumnName("specialty_name");
        });

        modelBuilder.Entity<Specialtysubject>(entity =>
        {
            entity.HasKey(e => e.SpecialtySubjectId).HasName("specialtysubjects_pkey");

            entity.ToTable("specialtysubjects", "schedule");

            entity.Property(e => e.SpecialtySubjectId).HasColumnName("specialty_subject_id");
            entity.Property(e => e.Assessment)
                .HasMaxLength(20)
                .HasColumnName("assessment");
            entity.Property(e => e.LabHours).HasColumnName("lab_hours");
            entity.Property(e => e.Semester).HasColumnName("semester");
            entity.Property(e => e.SpecialtyId).HasColumnName("specialty_id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.TotalHours).HasColumnName("total_hours");

            entity.HasOne(d => d.Specialty).WithMany(p => p.Specialtysubjects)
                .HasForeignKey(d => d.SpecialtyId)
                .HasConstraintName("fk_specialty");

            entity.HasOne(d => d.Subject).WithMany(p => p.Specialtysubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("fk_subject");
        });

        modelBuilder.Entity<Statusesapplicant>(entity =>
        {
            entity.HasKey(e => new { e.Idapplicants, e.Idstatuses }).HasName("statusesapplicants_pk");

            entity.ToTable("statusesapplicants", "comission");

            entity.Property(e => e.Idapplicants).HasColumnName("idapplicants");
            entity.Property(e => e.Idstatuses).HasColumnName("idstatuses");

            entity.HasOne(d => d.IdapplicantsNavigation).WithMany(p => p.Statusesapplicants)
                .HasForeignKey(d => d.Idapplicants)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("statusesapplicants_applicants_applicant_id_fk");

            entity.HasOne(d => d.IdstatusesNavigation).WithMany(p => p.Statusesapplicants)
                .HasForeignKey(d => d.Idstatuses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("statusesapplicants_statusesforapplicants_id_status_fk");
        });

        modelBuilder.Entity<Statusesforapplicant>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("statusesforapplicants_pk");

            entity.ToTable("statusesforapplicants", "comission");

            entity.Property(e => e.IdStatus)
                .HasDefaultValueSql("nextval('comission.statuses_id_status_seq'::regclass)")
                .HasColumnName("id_status");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
            entity.Property(e => e.Ispreferential)
                .HasDefaultValue(false)
                .HasColumnName("ispreferential");
        });

        modelBuilder.Entity<Statusesforeducation>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("statusesforeducation_pk");

            entity.ToTable("statusesforeducation", "comission");

            entity.Property(e => e.StatusId)
                .HasDefaultValueSql("nextval('comission.statuseseducation_status_id_seq'::regclass)")
                .HasColumnName("status_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("subjects_pkey");

            entity.ToTable("subjects", "schedule");

            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(100)
                .HasColumnName("subject_name");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("teachers_pkey");

            entity.ToTable("teachers", "schedule");

            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.CommissionId).HasColumnName("commission_id");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");

            entity.HasOne(d => d.Commission).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.CommissionId)
                .HasConstraintName("fk_commission");
        });

        modelBuilder.Entity<Timeslot>(entity =>
        {
            entity.HasKey(e => e.TimeSlotId).HasName("timeslots_pkey");

            entity.ToTable("timeslots", "schedule");

            entity.Property(e => e.TimeSlotId).HasColumnName("time_slot_id");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(10)
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
