using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ICQ.Data.Access.DAL;

namespace Expenses.Data.Access.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Messages.Data.Models.Expense", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<decimal>("Amount");

                b.Property<string>("Comment");

                b.Property<DateTime>("Date");

                b.Property<string>("Description");

                b.Property<bool>("IsDeleted");

                b.Property<int>("UserId");

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("Messages");
            });

            modelBuilder.Entity("Messages.Data.Models.Role", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Name");

                b.HasKey("Id");

                b.ToTable("Roles");
            });

            modelBuilder.Entity("Messages.Data.Models.User", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("FirstName");

                b.Property<bool>("IsDeleted");

                b.Property<string>("LastName");

                b.Property<string>("Password");

                b.Property<string>("Username");

                b.HasKey("Id");

                b.ToTable("Users");
            });

            modelBuilder.Entity("Messages.Data.Models.UserRole", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int>("RoleId");

                b.Property<int>("UserId");

                b.HasKey("Id");

                b.HasIndex("RoleId");

                b.HasIndex("UserId");

                b.ToTable("UserRoles");
            });

            modelBuilder.Entity("Messages.Data.Models.Expense", b =>
            {
                b.HasOne("Messages.Data.Models.User", "User")
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Messages.Data.Models.UserRole", b =>
            {
                b.HasOne("Messages.Data.Models.Role", "Role")
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("Messages.Data.Models.User", "User")
                    .WithMany("Roles")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
