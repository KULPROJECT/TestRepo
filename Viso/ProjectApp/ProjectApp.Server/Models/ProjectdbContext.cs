using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectApp.Server.Models;

public partial class ProjectdbContext : DbContext
{
    public ProjectdbContext()
    {
    }

    public ProjectdbContext(DbContextOptions<ProjectdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationComment> ApplicationComments { get; set; }

    public virtual DbSet<COpinion> COpinions { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientRole> ClientRoles { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<MenuCategory> MenuCategories { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Permit> Permits { get; set; }

    public virtual DbSet<ROpinion> ROpinions { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermit> RolePermits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); DataBase=PROJECTDB;Integrated Security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationComment>(entity =>
        {
            entity.HasKey(e => e.ClientId);

            entity.ToTable("Application_Comments");

            entity.Property(e => e.ClientId)
                .ValueGeneratedNever()
                .HasColumnName("Client_id");
            entity.Property(e => e.Comment).HasMaxLength(200);
        });

        modelBuilder.Entity<COpinion>(entity =>
        {
            entity.HasKey(e => e.OpinionIdClientIdGradeDescriptionRestaurantIdTimeOpinionId);

            entity.ToTable("C_Opinions");

            entity.Property(e => e.OpinionIdClientIdGradeDescriptionRestaurantIdTimeOpinionId).HasColumnName("Opinion_id\r\nClient_id\r\nGrade\r\nDescription\r\nRestaurant_id\r\nTime\r\nOpinion_id");
            entity.Property(e => e.ClientId).HasColumnName("Client_id");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Grade).HasColumnType("decimal(1, 1)");
            entity.Property(e => e.RestaurantId).HasColumnName("Restaurant_id");
            entity.Property(e => e.Time).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(e => e.ClientId).HasColumnName("Client_id");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PassHash).HasColumnName("Pass_hash");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("Phone_number");
            entity.Property(e => e.RestaurateurApplication).HasColumnName("Restaurateur_application");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("User_name");
        });

        modelBuilder.Entity<ClientRole>(entity =>
        {
            entity.HasKey(e => e.CrId);

            entity.ToTable("Client_Roles");

            entity.Property(e => e.CrId).HasColumnName("CR_id");
            entity.Property(e => e.ClientId).HasColumnName("Client_id");
            entity.Property(e => e.RoleId).HasColumnName("Role_id");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AddDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Add_date");
            entity.Property(e => e.ClientId).HasColumnName("Client_id");
            entity.Property(e => e.RestaurantId).HasColumnName("Restaurant_id");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.Property(e => e.ManagerId).HasColumnName("Manager_id");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_name");
            entity.Property(e => e.PassHash)
                .HasMaxLength(64)
                .IsFixedLength()
                .HasColumnName("Pass_hash");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("Phone_number");
            entity.Property(e => e.RoleId).HasColumnName("Role_id");
        });

        modelBuilder.Entity<MenuCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.ToTable("Menu_Categories");

            entity.Property(e => e.CategoryId).HasColumnName("Category_id");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK_Menu_items");

            entity.ToTable("Menu_Items");

            entity.Property(e => e.ItemId).HasColumnName("Item_id");
            entity.Property(e => e.CategoryId).HasColumnName("Category_id");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(260)
                .HasColumnName("Image_path");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.RestaurantId).HasColumnName("Restaurant_id");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).HasColumnName("Order_id");
            entity.Property(e => e.ClientId).HasColumnName("Client_id");
            entity.Property(e => e.DeliveryAddress)
                .HasMaxLength(100)
                .HasColumnName("Delivery_Address");
            entity.Property(e => e.RestaurantId).HasColumnName("Restaurant_id");
            entity.Property(e => e.TimeOfDelivery)
                .HasColumnType("smalldatetime")
                .HasColumnName("Time_of_delivery");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Order_Items");

            entity.Property(e => e.ItemId).HasColumnName("Item_id");
            entity.Property(e => e.OrderId).HasColumnName("Order_id");
        });

        modelBuilder.Entity<Permit>(entity =>
        {
            entity.HasKey(e => e.PermitId).HasName("PK_Permitions");

            entity.Property(e => e.PermitId).HasColumnName("Permit_id");
            entity.Property(e => e.PermitName)
                .HasMaxLength(50)
                .HasColumnName("Permit_name");
        });

        modelBuilder.Entity<ROpinion>(entity =>
        {
            entity.HasKey(e => e.OpinionId);

            entity.ToTable("R_Opinions");

            entity.Property(e => e.OpinionId).HasColumnName("Opinion_id");
            entity.Property(e => e.ClientId).HasColumnName("Client_id");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Grade).HasColumnType("decimal(1, 1)");
            entity.Property(e => e.RestaurantId).HasColumnName("Restaurant_id");
            entity.Property(e => e.Time).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.TableNumber);

            entity.Property(e => e.TableNumber)
                .ValueGeneratedNever()
                .HasColumnName("Table_number");
            entity.Property(e => e.ClientId).HasColumnName("Client_id");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.IsOpen).HasColumnName("Is_open");
            entity.Property(e => e.RestaurantId).HasColumnName("Restaurant_id");
            entity.Property(e => e.Time).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.Property(e => e.RestaurantId).HasColumnName("Restaurant_id");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ManagerId).HasColumnName("Manager_id");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Phone_number");
            entity.Property(e => e.TotalGrade)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("Total_grade");
            entity.Property(e => e.WorkingHours)
                .HasMaxLength(200)
                .HasColumnName("Working_hours");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleId).HasColumnName("Role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("Role_name");
        });

        modelBuilder.Entity<RolePermit>(entity =>
        {
            entity.HasKey(e => e.RpId);

            entity.ToTable("Role_Permits");

            entity.Property(e => e.RpId).HasColumnName("RP_id");
            entity.Property(e => e.PermitId).HasColumnName("Permit_id");
            entity.Property(e => e.RoleId).HasColumnName("Role_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
