using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PreparationApi.Models;

namespace PreparationApi.Context;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Condition> Conditions { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Diagnosis> Diagnoses { get; set; }

    public virtual DbSet<Diagnostic> Diagnostics { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Hospitaliz> Hospitalizs { get; set; }

    public virtual DbSet<Hospitalization> Hospitalizations { get; set; }

    public virtual DbSet<Insurancecompany> Insurancecompanies { get; set; }

    public virtual DbSet<Medialcard> Medialcards { get; set; }

    public virtual DbSet<Medication> Medications { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Placeofwork> Placeofworks { get; set; }

    public virtual DbSet<Prescribedmedication> Prescribedmedications { get; set; }

    public virtual DbSet<Proceduretipe> Proceduretipes { get; set; }

    public virtual DbSet<Purpose> Purposes { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Roletable> Roletables { get; set; }

    public virtual DbSet<TypeEvent> TypeEvents { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("host = 89.110.53.87; password = 492492; Database = postgres; Username = postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Condition>(entity =>
        {
            entity.HasKey(e => e.Conditionsid).HasName("conditions_pkey");

            entity.ToTable("conditions", "Preparation");

            entity.Property(e => e.Conditionsid).HasColumnName("conditionsid");
            entity.Property(e => e.Conditionsname)
                .HasMaxLength(100)
                .HasColumnName("conditionsname");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Departmentid).HasName("department_pkey");

            entity.ToTable("department", "Preparation");

            entity.Property(e => e.Departmentid).HasColumnName("departmentid");
            entity.Property(e => e.Departmentname)
                .HasMaxLength(100)
                .HasColumnName("departmentname");
        });

        modelBuilder.Entity<Diagnosis>(entity =>
        {
            entity.HasKey(e => e.Diagnosisid).HasName("diagnosis_pkey");

            entity.ToTable("diagnosis", "Preparation");

            entity.Property(e => e.Diagnosisid).HasColumnName("diagnosisid");
            entity.Property(e => e.Diagnosisname)
                .HasMaxLength(100)
                .HasColumnName("diagnosisname");
        });

        modelBuilder.Entity<Diagnostic>(entity =>
        {
            entity.HasKey(e => e.Diagnosticid).HasName("diagnostic_pkey");

            entity.ToTable("diagnostic", "Preparation");

            entity.Property(e => e.Diagnosticid).HasColumnName("diagnosticid");
            entity.Property(e => e.Datadiagnostic)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datadiagnostic");
            entity.Property(e => e.Diagnosticname)
                .HasMaxLength(100)
                .HasColumnName("diagnosticname");
            entity.Property(e => e.Doctor).HasColumnName("doctor");
            entity.Property(e => e.Medialcardid).HasColumnName("medialcardid");
            entity.Property(e => e.Tipeeventid).HasColumnName("tipeeventid");

            entity.HasOne(d => d.DoctorNavigation).WithMany(p => p.Diagnostics)
                .HasForeignKey(d => d.Doctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("diagnostic_doctor_fkey");

            entity.HasOne(d => d.Medialcard).WithMany(p => p.Diagnostics)
                .HasForeignKey(d => d.Medialcardid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("diagnostic_medialcardid_fkey");

            entity.HasOne(d => d.Tipeevent).WithMany(p => p.Diagnostics)
                .HasForeignKey(d => d.Tipeeventid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("diagnostic_tipeeventid_fkey");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Genderid).HasName("genders_pkey");

            entity.ToTable("genders", "Preparation");

            entity.Property(e => e.Genderid).HasColumnName("genderid");
            entity.Property(e => e.Gendername)
                .HasMaxLength(100)
                .HasColumnName("gendername");
        });

        modelBuilder.Entity<Hospitaliz>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("hospitaliz", "Preparation");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Conditionsname)
                .HasMaxLength(100)
                .HasColumnName("conditionsname");
            entity.Property(e => e.Departmentname)
                .HasMaxLength(100)
                .HasColumnName("departmentname");
            entity.Property(e => e.Endhospital)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("endhospital");
            entity.Property(e => e.Fio)
                .HasMaxLength(100)
                .HasColumnName("fio");
            entity.Property(e => e.Purposename)
                .HasMaxLength(100)
                .HasColumnName("purposename");
            entity.Property(e => e.Starthospital)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("starthospital");
        });

        modelBuilder.Entity<Hospitalization>(entity =>
        {
            entity.HasKey(e => e.Hospitalizationid).HasName("hospitalization_pkey");

            entity.ToTable("hospitalization", "Preparation");

            entity.Property(e => e.Hospitalizationid).HasColumnName("hospitalizationid");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Conditionsid).HasColumnName("conditionsid");
            entity.Property(e => e.Departmentid).HasColumnName("departmentid");
            entity.Property(e => e.Endhospital)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("endhospital");
            entity.Property(e => e.Patientid).HasColumnName("patientid");
            entity.Property(e => e.Purposeid).HasColumnName("purposeid");
            entity.Property(e => e.Starthospital)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("starthospital");

            entity.HasOne(d => d.Conditions).WithMany(p => p.Hospitalizations)
                .HasForeignKey(d => d.Conditionsid)
                .HasConstraintName("hospitalization_conditionsid_fkey");

            entity.HasOne(d => d.Department).WithMany(p => p.Hospitalizations)
                .HasForeignKey(d => d.Departmentid)
                .HasConstraintName("hospitalization_departmentid_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Hospitalizations)
                .HasForeignKey(d => d.Patientid)
                .HasConstraintName("hospitalization_patientid_fkey");

            entity.HasOne(d => d.Purpose).WithMany(p => p.Hospitalizations)
                .HasForeignKey(d => d.Purposeid)
                .HasConstraintName("hospitalization_purposeid_fkey");
        });

        modelBuilder.Entity<Insurancecompany>(entity =>
        {
            entity.HasKey(e => e.Insurancecompanyid).HasName("insurancecompany_pkey");

            entity.ToTable("insurancecompany", "Preparation");

            entity.Property(e => e.Insurancecompanyid).HasColumnName("insurancecompanyid");
            entity.Property(e => e.Insurancecompanyname)
                .HasMaxLength(100)
                .HasColumnName("insurancecompanyname");
        });

        modelBuilder.Entity<Medialcard>(entity =>
        {
            entity.HasKey(e => e.Mcid).HasName("medialcard_pkey");

            entity.ToTable("medialcard", "Preparation");

            entity.Property(e => e.Mcid).HasColumnName("mcid");
            entity.Property(e => e.Datalastvisit)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datalastvisit");
            entity.Property(e => e.Datanextvisit)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datanextvisit");
            entity.Property(e => e.Diagnosisid).HasColumnName("diagnosisid");
            entity.Property(e => e.Medialcardcod).HasColumnName("medialcardcod");
            entity.Property(e => e.Patientid).HasColumnName("patientid");

            entity.HasOne(d => d.Diagnosis).WithMany(p => p.Medialcards)
                .HasForeignKey(d => d.Diagnosisid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medialcard_diagnosisid_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Medialcards)
                .HasForeignKey(d => d.Patientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medialcard_patientid_fkey");
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.HasKey(e => e.Medicationsid).HasName("medications_pkey");

            entity.ToTable("medications", "Preparation");

            entity.Property(e => e.Medicationsid).HasColumnName("medicationsid");
            entity.Property(e => e.Medicationsname)
                .HasMaxLength(100)
                .HasColumnName("medicationsname");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Patientid).HasName("patient_pkey");

            entity.ToTable("patient", "Preparation");

            entity.Property(e => e.Patientid).HasColumnName("patientid");
            entity.Property(e => e.Dataexpirationinsurancepolisy)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dataexpirationinsurancepolisy");
            entity.Property(e => e.Dataissuemc)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dataissuemc");
            entity.Property(e => e.Insurancecompanyid).HasColumnName("insurancecompanyid");
            entity.Property(e => e.Numberpolis)
                .HasMaxLength(100)
                .HasColumnName("numberpolis");
            entity.Property(e => e.Placeofworkid).HasColumnName("placeofworkid");
            entity.Property(e => e.Policyvalidity)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("policyvalidity");
            entity.Property(e => e.Useridpatient).HasColumnName("useridpatient");

            entity.HasOne(d => d.Insurancecompany).WithMany(p => p.Patients)
                .HasForeignKey(d => d.Insurancecompanyid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("patient_insurancecompanyid_fkey");

            entity.HasOne(d => d.Placeofwork).WithMany(p => p.Patients)
                .HasForeignKey(d => d.Placeofworkid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("patient_placeofworkid_fkey");

            entity.HasOne(d => d.UseridpatientNavigation).WithMany(p => p.Patients)
                .HasForeignKey(d => d.Useridpatient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("patient_useridpatient_fkey");
        });

        modelBuilder.Entity<Placeofwork>(entity =>
        {
            entity.HasKey(e => e.Placeofworkid).HasName("placeofwork_pkey");

            entity.ToTable("placeofwork", "Preparation");

            entity.Property(e => e.Placeofworkid).HasColumnName("placeofworkid");
            entity.Property(e => e.Placeofworkname)
                .HasMaxLength(100)
                .HasColumnName("placeofworkname");
        });

        modelBuilder.Entity<Prescribedmedication>(entity =>
        {
            entity.HasKey(e => e.Pmid).HasName("prescribedmedications_pkey");

            entity.ToTable("prescribedmedications", "Preparation");

            entity.Property(e => e.Pmid).HasColumnName("pmid");
            entity.Property(e => e.Madicationsid).HasColumnName("madicationsid");
            entity.Property(e => e.Procedureid).HasColumnName("procedureid");
            entity.Property(e => e.Resultpmid).HasColumnName("resultpmid");

            entity.HasOne(d => d.Madications).WithMany(p => p.Prescribedmedications)
                .HasForeignKey(d => d.Madicationsid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prescribedmedications_madicationsid_fkey");

            entity.HasOne(d => d.Procedure).WithMany(p => p.Prescribedmedications)
                .HasForeignKey(d => d.Procedureid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prescribedmedications_procedureid_fkey");

            entity.HasOne(d => d.Resultpm).WithMany(p => p.Prescribedmedications)
                .HasForeignKey(d => d.Resultpmid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prescribedmedications_resultpmid_fkey");
        });

        modelBuilder.Entity<Proceduretipe>(entity =>
        {
            entity.HasKey(e => e.Procedureid).HasName("proceduretipe_pkey");

            entity.ToTable("proceduretipe", "Preparation");

            entity.Property(e => e.Procedureid).HasColumnName("procedureid");
            entity.Property(e => e.Procedurename)
                .HasMaxLength(100)
                .HasColumnName("procedurename");
        });

        modelBuilder.Entity<Purpose>(entity =>
        {
            entity.HasKey(e => e.Purposeid).HasName("purpose_pkey");

            entity.ToTable("purpose", "Preparation");

            entity.Property(e => e.Purposeid).HasColumnName("purposeid");
            entity.Property(e => e.Purposename)
                .HasMaxLength(100)
                .HasColumnName("purposename");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.Resultsid).HasName("results_pkey");

            entity.ToTable("results", "Preparation");

            entity.Property(e => e.Resultsid).HasColumnName("resultsid");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Diagnosis).HasColumnName("diagnosis");

            entity.HasOne(d => d.DiagnosisNavigation).WithMany(p => p.Results)
                .HasForeignKey(d => d.Diagnosis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("results_diagnosis_fkey");
        });

        modelBuilder.Entity<Roletable>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("roletable_pkey");

            entity.ToTable("roletable", "Preparation");

            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Rolename)
                .HasMaxLength(100)
                .HasColumnName("rolename");
        });

        modelBuilder.Entity<TypeEvent>(entity =>
        {
            entity.HasKey(e => e.Eventid).HasName("type_event_pkey");

            entity.ToTable("type_event", "Preparation");

            entity.Property(e => e.Eventid).HasColumnName("eventid");
            entity.Property(e => e.Costevent).HasColumnName("costevent");
            entity.Property(e => e.Eventname)
                .HasMaxLength(100)
                .HasColumnName("eventname");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.ToTable("users", "Preparation");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Birthday)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("birthday");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Fio)
                .HasMaxLength(100)
                .HasColumnName("fio");
            entity.Property(e => e.Foto)
                .HasMaxLength(100)
                .HasColumnName("foto");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Numberp).HasColumnName("numberp");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .HasColumnName("phone");
            entity.Property(e => e.Roleuser).HasColumnName("roleuser");
            entity.Property(e => e.Seriesp).HasColumnName("seriesp");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Gender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_gender_fkey");

            entity.HasOne(d => d.RoleuserNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Roleuser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_roleuser_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
