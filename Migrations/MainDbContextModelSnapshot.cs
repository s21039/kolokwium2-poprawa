// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kolokwium2_poprawa.Models;

namespace kolokwium2_poprawa.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("kolokwium2_poprawa.Models.File", b =>
                {
                    b.Property<int>("FileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("FileSize")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("FileID");

                    b.HasIndex("TeamID");

                    b.ToTable("File");

                    b.HasData(
                        new
                        {
                            FileID = 1,
                            FileExtension = "sln",
                            FileName = "Solution",
                            FileSize = 1024,
                            TeamID = 1
                        });
                });

            modelBuilder.Entity("kolokwium2_poprawa.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MemberNickName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MemberSurname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.HasKey("MemberID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Member");

                    b.HasData(
                        new
                        {
                            MemberID = 1,
                            MemberName = "John",
                            MemberNickName = "jdoe",
                            MemberSurname = "Doe",
                            OrganizationID = 1
                        });
                });

            modelBuilder.Entity("kolokwium2_poprawa.Models.Membership", b =>
                {
                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<DateTime>("MembershipDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MemberID", "TeamID");

                    b.HasIndex("TeamID");

                    b.ToTable("Membership");

                    b.HasData(
                        new
                        {
                            MemberID = 1,
                            TeamID = 1,
                            MembershipDate = new DateTime(2022, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("kolokwium2_poprawa.Models.Organization", b =>
                {
                    b.Property<int>("OrganizationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrganizationDomain")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("OrganizationID");

                    b.ToTable("Organization");

                    b.HasData(
                        new
                        {
                            OrganizationID = 1,
                            OrganizationDomain = "Google.com",
                            OrganizationName = "Google"
                        });
                });

            modelBuilder.Entity("kolokwium2_poprawa.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.Property<string>("TeamDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeamID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Team");

                    b.HasData(
                        new
                        {
                            TeamID = 1,
                            OrganizationID = 1,
                            TeamDescription = "Developing products",
                            TeamName = "Software engineers"
                        });
                });

            modelBuilder.Entity("kolokwium2_poprawa.Models.File", b =>
                {
                    b.HasOne("kolokwium2_poprawa.Models.Team", "Team")
                        .WithMany("Files")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("kolokwium2_poprawa.Models.Member", b =>
                {
                    b.HasOne("kolokwium2_poprawa.Models.Organization", "Organization")
                        .WithMany("Members")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("kolokwium2_poprawa.Models.Membership", b =>
                {
                    b.HasOne("kolokwium2_poprawa.Models.Member", "Member")
                        .WithMany("Memberships")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("kolokwium2_poprawa.Models.Team", "Team")
                        .WithMany("Memberships")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("kolokwium2_poprawa.Models.Team", b =>
                {
                    b.HasOne("kolokwium2_poprawa.Models.Organization", "Organization")
                        .WithMany("Teams")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("kolokwium2_poprawa.Models.Member", b =>
                {
                    b.Navigation("Memberships");
                });

            modelBuilder.Entity("kolokwium2_poprawa.Models.Organization", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("kolokwium2_poprawa.Models.Team", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
