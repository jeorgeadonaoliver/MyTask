using Microsoft.EntityFrameworkCore;
using MyTask.Api.Client.MyTaskDbModel;
using Tasks = MyTask.Api.Client.MyTaskDbModel.Tasks;
using TaskStatus = MyTask.Api.Client.MyTaskDbModel.TaskStatus;

namespace MyTask.Persistence.MyTaskDb;

public partial class MyTaskDbContext : DbContext
{
    public MyTaskDbContext()
    {
    }

    public MyTaskDbContext(DbContextOptions<MyTaskDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectMember> ProjectMembers { get; set; }

    public virtual DbSet<ProjectMemberRole> ProjectMemberRoles { get; set; }

    public virtual DbSet<ProjectStatus> ProjectStatuses { get; set; }

    public virtual DbSet<Sprint> Sprints { get; set; }

    public virtual DbSet<SprintStatus> SprintStatuses { get; set; }

    public virtual DbSet<SubTaskStatus> SubTaskStatuses { get; set; }

    public virtual DbSet<Subtask> Subtasks { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Tasks> Tasks { get; set; }

    public virtual DbSet<TaskAssignment> TaskAssignments { get; set; }

    public virtual DbSet<TaskComment> TaskComments { get; set; }

    public virtual DbSet<TaskList> TaskLists { get; set; }

    public virtual DbSet<TaskPriority> TaskPriorities { get; set; }

    public virtual DbSet<MyTask.Api.Client.MyTaskDbModel.TaskStatus> TaskStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=JEORGEOLIVER-LA\\SQLEXPRESS02;Database=myTaskDb;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.AttachmentId).HasName("PK__Attachme__442C64BEB1868C36");

            entity.Property(e => e.AttachmentId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.FileName).HasMaxLength(255);
            entity.Property(e => e.FileUrl).HasMaxLength(1024);
            entity.Property(e => e.UploadedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Task).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attachmen__TaskI__114A936A");

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.UploadedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attachmen__Uploa__123EB7A3");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__AuditLog__5E54864832425367");

            entity.Property(e => e.Action).HasMaxLength(30);
            entity.Property(e => e.At).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Entity).HasMaxLength(60);

            entity.HasOne(d => d.ChangedByNavigation).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.ChangedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AuditLogs__Chang__1BC821DD");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E12596999CC");

            entity.Property(e => e.NotificationId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Type).HasMaxLength(40);

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__UserI__17036CC0");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Projects__761ABEF04CB4652E");

            entity.Property(e => e.ProjectId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Description).HasMaxLength(1024);
            entity.Property(e => e.Name).HasMaxLength(120);

            entity.HasOne(d => d.Owner).WithMany(p => p.Projects)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Projects__OwnerI__5535A963");

            entity.HasOne(d => d.Status).WithMany(p => p.Projects)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Projects__Status__5629CD9C");
        });

        modelBuilder.Entity<ProjectMember>(entity =>
        {
            entity.HasKey(e => new { e.ProjectId, e.UserId });

            entity.Property(e => e.AddedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectMembers)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProjectMe__Proje__5BE2A6F2");

            entity.HasOne(d => d.Role).WithMany(p => p.ProjectMembers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProjectMe__RoleI__59FA5E80");

            entity.HasOne(d => d.User).WithMany(p => p.ProjectMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProjectMe__UserI__5CD6CB2B");
        });

        modelBuilder.Entity<ProjectMemberRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__ProjectM__8AFACE1A37C3A2CE");

            entity.ToTable("ProjectMemberRole");

            entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ProjectStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__ProjectS__8AFACE1AD42DC873");

            entity.ToTable("ProjectStatus");

            entity.Property(e => e.StatusId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Sprint>(entity =>
        {
            entity.HasKey(e => e.SprintId).HasName("PK__Sprint__29F16AC0CD799302");

            entity.ToTable("Sprint");

            entity.Property(e => e.SprintId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Goal).HasMaxLength(512);
            entity.Property(e => e.Name).HasMaxLength(80);

            entity.HasOne(d => d.Project).WithMany(p => p.Sprints)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sprint__ProjectI__60A75C0F");

            entity.HasOne(d => d.Status).WithMany(p => p.Sprints)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sprint__StatusId__619B8048");
        });

        modelBuilder.Entity<SprintStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__SprintSt__8AFACE1A4F655CBB");

            entity.ToTable("SprintStatus");

            entity.Property(e => e.StatusId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<SubTaskStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__SubTaskS__C8EE2063487CEF0B");

            entity.ToTable("SubTaskStatus");

            entity.Property(e => e.StatusId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Subtask>(entity =>
        {
            entity.HasKey(e => e.SubtaskId).HasName("PK__Subtasks__E0871796FDD3E811");

            entity.Property(e => e.SubtaskId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("To-Do");
            entity.Property(e => e.Title).HasMaxLength(160);

            entity.HasOne(d => d.ParentTask).WithMany(p => p.Subtasks)
                .HasForeignKey(d => d.ParentTaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subtasks__Parent__797309D9");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK__Tags__657CF9ACB8DE150B");

            entity.Property(e => e.TagId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Color)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(40);

            entity.HasOne(d => d.Project).WithMany(p => p.Tags)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tags__ProjectId__02FC7413");
        });

        modelBuilder.Entity<Tasks>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Tasks__7C6949B11BEF3DAA");

            entity.Property(e => e.TaskId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.EstimateHours).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Title).HasMaxLength(160);

            entity.HasOne(d => d.List).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tasks__ListId__71D1E811");

            entity.HasOne(d => d.Priority).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tasks__PriorityI__74AE54BC");

            entity.HasOne(d => d.Sprint).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.SprintId)
                .HasConstraintName("FK__Tasks__SprintId__72C60C4A");

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tasks__StatusId__73BA3083");

            entity.HasMany(d => d.Tags).WithMany(p => p.Tasks)
                .UsingEntity<Dictionary<string, object>>(
                    "TaskTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TaskTags__TagId__06CD04F7"),
                    l => l.HasOne<Tasks>().WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TaskTags__TaskId__05D8E0BE"),
                    j =>
                    {
                        j.HasKey("TaskId", "TagId");
                        j.ToTable("TaskTags");
                    });
        });

        modelBuilder.Entity<TaskAssignment>(entity =>
        {
            entity.HasKey(e => new { e.TaskId, e.UserId });

            entity.Property(e => e.AssignedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskAssignments)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaskAssig__TaskI__7E37BEF6");

            entity.HasOne(d => d.User).WithMany(p => p.TaskAssignments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaskAssig__UserI__7F2BE32F");
        });

        modelBuilder.Entity<TaskComment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__TaskComm__C3B4DFCAEC9BF65F");

            entity.Property(e => e.CommentId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Author).WithMany(p => p.TaskComments)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaskComme__Autho__0B91BA14");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__TaskComme__Paren__0C85DE4D");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskComments)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaskComme__TaskI__0A9D95DB");
        });

        modelBuilder.Entity<TaskList>(entity =>
        {
            entity.HasKey(e => e.ListId).HasName("PK__TaskList__E3832805C0D8E4D8");

            entity.Property(e => e.ListId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(60);

            entity.HasOne(d => d.Project).WithMany(p => p.TaskLists)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaskLists__Proje__656C112C");
        });

        modelBuilder.Entity<TaskPriority>(entity =>
        {
            entity.HasKey(e => e.PriorityId).HasName("PK__TaskPrio__D0A3D0BEFCE215B1");

            entity.ToTable("TaskPriority");

            entity.Property(e => e.PriorityId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TaskStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__TaskStat__C8EE20634FB7412B");

            entity.ToTable("TaskStatus");

            entity.Property(e => e.StatusId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CC964382F");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534F40E8A1C").IsUnique();

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AvatarUrl).HasMaxLength(512);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FullName).HasMaxLength(120);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);

            entity.HasOne(d => d.UserRoles).WithOne(p => p.Users)
            .HasForeignKey<User>(d => d.RoleId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Users_Role");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__UserRole__8AFACE1A094285C6");

            entity.ToTable("UserRole");

            entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
