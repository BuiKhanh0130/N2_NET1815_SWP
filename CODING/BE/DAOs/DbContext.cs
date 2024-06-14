using System;
using System.Collections.Generic;
using BusinessObjects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAOs;

public partial class DbContext : IdentityDbContext<Account>
{
    public DbContext()
    {
    }

    public DbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Complaint> Complaints { get; set; }

    public virtual DbSet<Conversation> Conversations { get; set; }

    public virtual DbSet<ConversationAccount> ConversationAccounts { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<FindTutorForm> FindTutorForms { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectGroup> SubjectGroups { get; set; }

    public virtual DbSet<SubjectTutor> SubjectTutors { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Tutor> Tutors { get; set; }

    public virtual DbSet<TutorAd> TutorAds { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=localhost;uid=sa;pwd=12345;database=OnDemandTutor;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("isActive");

        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Class__CB1927A0090BF352");

            entity.ToTable("Class");

            entity.Property(e => e.ClassId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ClassID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StudentId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("StudentID");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("SubjectID");
            entity.Property(e => e.TutorId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("TutorID");

            entity.HasOne(d => d.Student).WithMany(p => p.Classes)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKClass301112");

            entity.HasOne(d => d.Subject).WithMany(p => p.Classes)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKClass105998");

            entity.HasOne(d => d.Tutor).WithMany(p => p.Classes)
                .HasForeignKey(d => d.TutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKClass479452");
        });

        modelBuilder.Entity<Complaint>(entity =>
        {
            entity.HasKey(e => e.ComplaintId).HasName("PK__Complain__740D89AFCEF50736");

            entity.ToTable("Complaint");

            entity.Property(e => e.ComplaintId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ComplaintID");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.StudentId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("StudentID");
            entity.Property(e => e.TutorId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("TutorID");

            entity.HasOne(d => d.Student).WithMany(p => p.Complaints)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKComplaint416082");

            entity.HasOne(d => d.Tutor).WithMany(p => p.Complaints)
                .HasForeignKey(d => d.TutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKComplaint196647");
        });

        modelBuilder.Entity<Conversation>(entity =>
        {
            entity.HasKey(e => e.ConversationId).HasName("PK__Conversa__C050D897C401235F");

            entity.ToTable("Conversation");

            entity.Property(e => e.ConversationId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ConversationID");
        });

        modelBuilder.Entity<ConversationAccount>(entity =>
        {
            entity.HasKey(e => new { e.ConversationId, e.AccountId }).HasName("PK__Conversa__B31902CF056C16DA");

            entity.ToTable("Conversation_Account");

            entity.Property(e => e.ConversationId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ConversationID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(450)
                .IsUnicode(true)
                .HasColumnName("AccountID");

            entity.HasOne(d => d.Account).WithMany(p => p.ConversationAccounts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKConversati818528");

            entity.HasOne(d => d.Conversation).WithMany(p => p.ConversationAccounts)
                .HasForeignKey(d => d.ConversationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKConversati872380");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF65E258262");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FeedbackID");
            entity.Property(e => e.ClassId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ClassID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StudentId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("StudentID");
            entity.Property(e => e.TutorId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("TutorID");

            entity.HasOne(d => d.Class).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKFeedback912586");

            entity.HasOne(d => d.Student).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKFeedback348843");

            entity.HasOne(d => d.Tutor).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.TutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKFeedback431721");
        });

        modelBuilder.Entity<FindTutorForm>(entity =>
        {
            entity.HasKey(e => e.FormId).HasName("PK__FindTuto__FB05B7BD12F4FFB4");

            entity.ToTable("FindTutorForm");

            entity.Property(e => e.FormId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FormID");
            entity.Property(e => e.DescribeTutor)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StudentId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("StudentID");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("SubjectID");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TypeOfDegree)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.FindTutorForms)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKFindTutorF134374");

            entity.HasOne(d => d.Subject).WithMany(p => p.FindTutorForms)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKFindTutorF727263");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grade__54F87A37CC152DE4");

            entity.ToTable("Grade");

            entity.Property(e => e.GradeId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("GradeID");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Message__C87C037C2D324FDF");

            entity.ToTable("Message");

            entity.Property(e => e.MessageId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("MessageID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(450)
                .IsUnicode(true)
                .HasColumnName("AccountID");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ConversationID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Messages)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKMessage179454");

            entity.HasOne(d => d.Conversation).WithMany(p => p.Messages)
                .HasForeignKey(d => d.ConversationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKMessage125602");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E32FFBD5FC4");

            entity.ToTable("Notification");

            entity.Property(e => e.NotificationId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("NotificationID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(450)
                .IsUnicode(true)
                .HasColumnName("AccountID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKNotificati765224");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A42B64DA9");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A79D012377F");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("StudentID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(450)
                .IsUnicode(true)
                .HasColumnName("AccountID");
            entity.Property(e => e.SchoolName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Students)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKStudent718314");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subject__AC1BA388537DD7A1");

            entity.ToTable("Subject");

            entity.Property(e => e.SubjectId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("SubjectID");
            entity.Property(e => e.GradeId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("GradeID");
            entity.Property(e => e.SubjectGroupId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("SubjectGroupID");

            entity.HasOne(d => d.Grade).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKSubject866932");

            entity.HasOne(d => d.SubjectGroup).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.SubjectGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKSubject340947");
        });

        modelBuilder.Entity<SubjectGroup>(entity =>
        {
            entity.HasKey(e => e.SubjectGroupId).HasName("PK__SubjectG__2F88B016AD652F27");

            entity.ToTable("SubjectGroup");

            entity.Property(e => e.SubjectGroupId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("SubjectGroupID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SubjectName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SubjectTutor>(entity =>
        {
            entity.HasKey(e => new { e.SubjectId, e.TutorId }).HasName("PK__Subject___9B67D374BBB4AFD2");

            entity.ToTable("Subject_Tutor");

            entity.Property(e => e.SubjectId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("SubjectID");
            entity.Property(e => e.TutorId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("TutorID");

            entity.HasOne(d => d.Subject).WithMany(p => p.SubjectTutors)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKSubject_Tu675031");

            entity.HasOne(d => d.Tutor).WithMany(p => p.SubjectTutors)
                .HasForeignKey(d => d.TutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKSubject_Tu3188");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A4B61451DBE");

            entity.ToTable("Transaction");

            entity.Property(e => e.TransactionId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("TransactionID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WalletId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("WalletID");

            entity.HasOne(d => d.Wallet).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.WalletId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTransactio181260");
        });

        modelBuilder.Entity<Tutor>(entity =>
        {
            entity.HasKey(e => e.TutorId).HasName("PK__Tutor__77C70FC2A16C50DB");

            entity.ToTable("Tutor");

            entity.Property(e => e.TutorId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("TutorID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(450)
                .IsUnicode(true)
                .HasColumnName("AccountID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CardId).HasColumnName("CardID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Education)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Headline)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Photo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TypeOfDegree)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Tutors)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTutor387597");
        });

        modelBuilder.Entity<TutorAd>(entity =>
        {
            entity.HasKey(e => e.AdsId).HasName("PK__Tutor_Ad__46AAC65A5EF65941");

            entity.ToTable("Tutor_Ads");

            entity.Property(e => e.AdsId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("AdsID");
            entity.Property(e => e.Image)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TutorId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("TutorID");
            entity.Property(e => e.Video)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Tutor).WithMany(p => p.TutorAds)
                .HasForeignKey(d => d.TutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTutor_Ads572887");
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasKey(e => e.WalletId).HasName("PK__Wallet__84D4F92E9F63180B");

            entity.ToTable("Wallet");

            entity.Property(e => e.WalletId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("WalletID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(450)
                .IsUnicode(true)
                .HasColumnName("AccountID");
            entity.Property(e => e.BankName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Wallets)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKWallet115696");
        });

        base.OnModelCreating(modelBuilder);
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }
        OnModelCreatingPartial(modelBuilder);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
