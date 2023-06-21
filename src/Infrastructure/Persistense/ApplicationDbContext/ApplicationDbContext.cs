using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistense.ApplicationDbContext;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Controller> Controllers { get; set; }

    public virtual DbSet<DeviceCode> DeviceCodes { get; set; }

    public virtual DbSet<ElectronicParam> ElectronicParams { get; set; }

    public virtual DbSet<Key> Keys { get; set; }

    public virtual DbSet<MechanicalParam> MechanicalParams { get; set; }

    public virtual DbSet<Pad> Pads { get; set; }

    public virtual DbSet<PersistedGrant> PersistedGrants { get; set; }

    public virtual DbSet<Sector> Sectors { get; set; }

    public virtual DbSet<StapIvn9> StapIvn9s { get; set; }

    public virtual DbSet<Temperature> Temperatures { get; set; }

    public virtual DbSet<TodoItem> TodoItems { get; set; }

    public virtual DbSet<TodoList> TodoLists { get; set; }

    public virtual DbSet<WorkSectorParam> WorkSectorParams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost:5432;Database=TestDb;Username=postgres;Password=root;Include Error Detail=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.ToTable("AspNetRoles", "Application");

            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex").IsUnique();
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.ToTable("AspNetRoleClaims", "Application");

            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.ToTable("AspNetUsers", "Application");

            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex").IsUnique();

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles", "Application");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.ToTable("AspNetUserClaims", "Application");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.ToTable("AspNetUserLogins", "Application");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.ToTable("AspNetUserTokens", "Application");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TestCard_pkey");

            entity.ToTable("Cards", "Application");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.File).HasColumnType("jsonb");
            entity.Property(e => e.NewFile).HasColumnType("jsonb");
        });

        modelBuilder.Entity<Controller>(entity =>
        {
            entity.ToTable("Controllers", "Application");

            entity.Property(e => e.File).HasColumnType("jsonb");
        });

        modelBuilder.Entity<DeviceCode>(entity =>
        {
            entity.HasKey(e => e.UserCode);

            entity.ToTable("DeviceCodes", "Application");

            entity.HasIndex(e => e.DeviceCode1, "IX_DeviceCodes_DeviceCode").IsUnique();

            entity.HasIndex(e => e.Expiration, "IX_DeviceCodes_Expiration");

            entity.Property(e => e.CreationTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DeviceCode1).HasColumnName("DeviceCode");
            entity.Property(e => e.Expiration).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<ElectronicParam>(entity =>
        {
            entity.ToTable("ElectronicParams", "Application");

            entity.Property(e => e.File).HasColumnType("jsonb");
        });

        modelBuilder.Entity<Key>(entity =>
        {
            entity.ToTable("Keys", "Application");

            entity.HasIndex(e => e.Use, "IX_Keys_Use");

            entity.Property(e => e.Created).HasColumnType("timestamp without time zone");
            entity.Property(e => e.IsX509certificate).HasColumnName("IsX509Certificate");
        });

        modelBuilder.Entity<MechanicalParam>(entity =>
        {
            entity.ToTable("MechanicalParams", "Application");

            entity.Property(e => e.File).HasColumnType("jsonb");
        });

        modelBuilder.Entity<Pad>(entity =>
        {
            entity.ToTable("Pads", "Application");

            entity.Property(e => e.File).HasColumnType("jsonb");
        });

        modelBuilder.Entity<PersistedGrant>(entity =>
        {
            entity.HasKey(e => e.Key);

            entity.ToTable("PersistedGrants", "Application");

            entity.HasIndex(e => e.ConsumedTime, "IX_PersistedGrants_ConsumedTime");

            entity.HasIndex(e => e.Expiration, "IX_PersistedGrants_Expiration");

            entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type }, "IX_PersistedGrants_SubjectId_ClientId_Type");

            entity.HasIndex(e => new { e.SubjectId, e.SessionId, e.Type }, "IX_PersistedGrants_SubjectId_SessionId_Type");

            entity.Property(e => e.ConsumedTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CreationTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Expiration).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.ToTable("Sectors", "Application");

            entity.Property(e => e.File).HasColumnType("jsonb");
        });

        modelBuilder.Entity<StapIvn9>(entity =>
        {
            entity.ToTable("StapIvn9", "Application");

            entity.Property(e => e.File).HasColumnType("jsonb");
        });

        modelBuilder.Entity<Temperature>(entity =>
        {
            entity.ToTable("Temperatures", "Application");

            entity.Property(e => e.File).HasColumnType("jsonb");
        });

        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.ToTable("TodoItems", "Application");

            entity.HasIndex(e => e.ListId, "IX_TodoItems_ListId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Created).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LastModified).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Reminder).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.List).WithMany(p => p.TodoItems).HasForeignKey(d => d.ListId);
        });

        modelBuilder.Entity<TodoList>(entity =>
        {
            entity.ToTable("TodoLists", "Application");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Created).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LastModified).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<WorkSectorParam>(entity =>
        {
            entity.ToTable("WorkSectorParams", "Application");

            entity.Property(e => e.File).HasColumnType("jsonb");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
