using Microsoft.EntityFrameworkCore;

namespace kolokwium2_poprawa.Models
{
    public class MainDbContext : DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>(e =>
            {
                e.ToTable("Organization");
                e.HasKey(e => e.OrganizationID);

                e.Property(e => e.OrganizationName).HasMaxLength(100).IsRequired();
                e.Property(e => e.OrganizationDomain).HasMaxLength(50).IsRequired();

                e.HasData(
                    new Organization
                    {
                        OrganizationID = 1,
                        OrganizationName = "Google",
                        OrganizationDomain = "Google.com"
                    }
                    );
            });

            modelBuilder.Entity<Team>(e =>
            {
                e.ToTable("Team");
                e.HasKey(e => e.TeamID);

                e.Property(e => e.TeamName).HasMaxLength(50).IsRequired();
                e.Property(e => e.TeamDescription).HasMaxLength(500);

                e.HasOne(e => e.Organization).WithMany(e => e.Teams).HasForeignKey(e => e.OrganizationID).OnDelete(DeleteBehavior.ClientCascade);

                e.HasData(
                    new Team
                    {
                        TeamID = 1,
                        OrganizationID = 1,
                        TeamName = "Software engineers",
                        TeamDescription = "Developing products"
                    }
                    );
            });

            modelBuilder.Entity<Member>(e =>
            {
                e.ToTable("Member");
                e.HasKey(e => e.MemberID);

                e.Property(e => e.MemberName).HasMaxLength(20).IsRequired();
                e.Property(e => e.MemberSurname).HasMaxLength(50).IsRequired();
                e.Property(e => e.MemberNickName).HasMaxLength(20);

                e.HasOne(e => e.Organization).WithMany(e => e.Members).HasForeignKey(e => e.OrganizationID).OnDelete(DeleteBehavior.ClientCascade);

                e.HasData(
                    new Member
                    {
                        MemberID = 1,
                        OrganizationID = 1,
                        MemberName = "John",
                        MemberSurname = "Doe",
                        MemberNickName = "jdoe"
                    }
                    );
            });

            modelBuilder.Entity<File>(e =>
            {
                e.ToTable("File");
                e.HasKey(e => e.FileID);

                e.Property(e => e.FileName).HasMaxLength(100).IsRequired();
                e.Property(e => e.FileExtension).HasMaxLength(4).IsRequired();
                e.Property(e => e.FileSize);

                e.HasOne(e => e.Team).WithMany(e => e.Files).HasForeignKey(e => e.TeamID).OnDelete(DeleteBehavior.ClientCascade);

                e.HasData(
                    new File
                    {
                        FileID = 1,
                        TeamID = 1,
                        FileName = "Solution",
                        FileExtension = "sln",
                        FileSize = 1024
                    }
                    );
            });

            modelBuilder.Entity<Membership>(e =>
            {
                e.ToTable("Membership");
                e.HasKey(e => new { e.MemberID, e.TeamID });

                e.Property(e => e.MembershipDate).IsRequired();

                e.HasOne(e => e.Member).WithMany(e => e.Memberships).HasForeignKey(e => e.MemberID).OnDelete(DeleteBehavior.ClientCascade);
                e.HasOne(e => e.Team).WithMany(e => e.Memberships).HasForeignKey(e => e.TeamID).OnDelete(DeleteBehavior.ClientCascade);

                e.HasData(
                    new Membership
                    {
                        MemberID = 1,
                        TeamID = 1,
                        MembershipDate = new System.DateTime(2022, 6, 6)        
                    }
                    );
            });
        }
    }
}
