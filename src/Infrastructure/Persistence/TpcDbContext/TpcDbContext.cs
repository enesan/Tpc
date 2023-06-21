using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.Tpc;
using CleanArchitecture.Infrastructure.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence.TpcDbContext;

public class TpcDbContext : DbContext, ITpcDbContext
{
    public TpcDbContext()
    {
    }

    public TpcDbContext(DbContextOptions<TpcDbContext> options)
        : base(options)
    {
    }

    

    public virtual DbSet<TodoItem> TodoItems { get; set; }

    public virtual DbSet<TodoList> TodoLists { get; set; }
    public DbSet<Card> Cards { get; set; }
    public virtual DbSet<Controller> Controllers { get; set; }
    public virtual DbSet<ElectronicParam> ElectronicParams { get; set; }
    public virtual DbSet<MechanicalParam> MechanicalParams { get; set; }
    public virtual DbSet<Pad> Pads { get; set; }
    public virtual DbSet<Sector> Sectors { get; set; }
    public virtual DbSet<StapIvn9> StapIvn9 { get; set; }
    public virtual DbSet<Temperature> Temperatures { get; set; }
    public virtual DbSet<WorkSectorParam> WorkSectorParams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost:5432;Database=TestDb;Username=postgres;Password=root;Include Error Detail=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Application.ToString());
        
       

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TestCard_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.File).HasColumnType("jsonb");
        });

        

        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasIndex(e => e.ListId, "IX_TodoItems_ListId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Created).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LastModified).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Reminder).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.List).WithMany(p => p.Items).HasForeignKey(d => d.ListId);
        });

        modelBuilder.Entity<TodoList>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            // entity.Property(e => e.ColourCode).HasColumnName("Colour_Code");
            entity.Property(e => e.Created).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LastModified).HasColumnType("timestamp without time zone");
        });


    }


}
