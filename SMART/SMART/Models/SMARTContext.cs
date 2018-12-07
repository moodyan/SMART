using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SMART.Models
{
    public partial class SMARTContext : DbContext
    {
        public SMARTContext()
        {
        }

        public SMARTContext(DbContextOptions<SMARTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<ClientsUsers> ClientsUsers { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<EmployeeAvailabilities> EmployeeAvailabilities { get; set; }
        public virtual DbSet<EmployeeDays> EmployeeDays { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<EmployeeShifts> EmployeeShifts { get; set; }
        public virtual DbSet<EmployeesLocations> EmployeesLocations { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<LocationSchedules> LocationSchedules { get; set; }
        public virtual DbSet<LocationsPositions> LocationsPositions { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<ProfilePictures> ProfilePictures { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<ScheduleDays> ScheduleDays { get; set; }
        public virtual DbSet<ScheduleDaysShifts> ScheduleDaysShifts { get; set; }
        public virtual DbSet<Shifts> Shifts { get; set; }
        public virtual DbSet<TimeOffRequests> TimeOffRequests { get; set; }
        public virtual DbSet<TimeOffTypes> TimeOffTypes { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersRoles> UsersRoles { get; set; }
        public virtual DbSet<WageGroups> WageGroups { get; set; }
        public virtual DbSet<WeeklySchedules> WeeklySchedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#TODO, move this to appsettings
                optionsBuilder.UseSqlServer("Data Source=WINDOWS-PCCIMCK;Initial Catalog=SMARTDev;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasKey(e => e.AddressId);

                entity.Property(e => e.AddressId)
                    .HasColumnName("addressID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasColumnName("address2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("cityID");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postalCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Addresses__cityI__4222D4EF");
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.Property(e => e.CityId)
                    .HasColumnName("cityID")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryId).HasColumnName("countryID");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Cities__countryI__3E52440B");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.ClientId)
                    .HasColumnName("clientID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasColumnName("clientName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientsUsers>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ClientId });

                entity.ToTable("Clients_Users");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientsUsers)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Clients_U__clien__182C9B23");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ClientsUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Clients_U__userI__173876EA");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.CountryId)
                    .HasColumnName("countryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(50);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeAvailabilities>(entity =>
            {
                entity.HasKey(e => e.EmployeeAvailabilityId);

                entity.Property(e => e.EmployeeAvailabilityId)
                    .HasColumnName("employeeAvailabilityID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.EndDate).HasColumnName("endDate");

                entity.Property(e => e.StartDate).HasColumnName("startDate");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeAvailabilities)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__EmployeeA__emplo__00200768");
            });

            modelBuilder.Entity<EmployeeDays>(entity =>
            {
                entity.HasKey(e => e.EmployeeDayId);

                entity.Property(e => e.EmployeeDayId)
                    .HasColumnName("employeeDayID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.DayName)
                    .IsRequired()
                    .HasColumnName("dayName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeAvailabilityId).HasColumnName("employeeAvailabilityID");

                entity.Property(e => e.EndTime).HasColumnName("endTime");

                entity.Property(e => e.StartTime).HasColumnName("startTime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeAvailability)
                    .WithMany(p => p.EmployeeDays)
                    .HasForeignKey(d => d.EmployeeAvailabilityId)
                    .HasConstraintName("FK__EmployeeD__emplo__05D8E0BE");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AddressId).HasColumnName("addressID");

                entity.Property(e => e.Birtdate)
                    .HasColumnName("birtdate")
                    .HasColumnType("date");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate).HasColumnName("hireDate");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaxHoursPerWeek).HasColumnName("maxHoursPerWeek");

                entity.Property(e => e.MinHoursPerWeek).HasColumnName("minHoursPerWeek");

                entity.Property(e => e.PositionId).HasColumnName("positionID");

                entity.Property(e => e.ProfilePictureId).HasColumnName("profilePictureID");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Wage).HasColumnName("wage");

                entity.Property(e => e.WageGroupId).HasColumnName("wageGroupID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Employees__addre__5441852A");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Employees__posit__5629CD9C");

                entity.HasOne(d => d.ProfilePicture)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ProfilePictureId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Employees__profi__5535A963");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_userID");
            });

            modelBuilder.Entity<EmployeeShifts>(entity =>
            {
                entity.HasKey(e => e.EmployeeShiftId);

                entity.HasIndex(e => new { e.ShiftDate, e.ScheduleDayShiftId, e.EmployeeId, e.WeeklyScheduleId })
                    .HasName("UQ__Employee__0D62CEE098E267FB")
                    .IsUnique();

                entity.Property(e => e.EmployeeShiftId)
                    .HasColumnName("employeeShiftID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.ScheduleDayShiftId).HasColumnName("scheduleDayShiftID");

                entity.Property(e => e.ShiftDate).HasColumnName("shiftDate");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WeeklyScheduleId).HasColumnName("weeklyScheduleID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeShifts)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__EmployeeS__emplo__778AC167");

                entity.HasOne(d => d.ScheduleDayShift)
                    .WithMany(p => p.EmployeeShifts)
                    .HasForeignKey(d => d.ScheduleDayShiftId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__EmployeeS__sched__76969D2E");

                entity.HasOne(d => d.WeeklySchedule)
                    .WithMany(p => p.EmployeeShifts)
                    .HasForeignKey(d => d.WeeklyScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeS__weekl__787EE5A0");
            });

            modelBuilder.Entity<EmployeesLocations>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.LocationId });

                entity.ToTable("Employees_Locations");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeesLocations)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Employees__emplo__5AEE82B9");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.EmployeesLocations)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Employees__locat__5BE2A6F2");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.Property(e => e.LocationId)
                    .HasColumnName("locationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasColumnName("locationName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Locations__clien__22AA2996");
            });

            modelBuilder.Entity<LocationSchedules>(entity =>
            {
                entity.HasKey(e => e.LocationScheduleId);

                entity.Property(e => e.LocationScheduleId)
                    .HasColumnName("locationScheduleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.ScheduleEndDate).HasColumnName("scheduleEndDate");

                entity.Property(e => e.ScheduleName)
                    .IsRequired()
                    .HasColumnName("scheduleName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ScheduleStartDate).HasColumnName("scheduleStartDate");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationSchedules)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__LocationS__locat__2A4B4B5E");
            });

            modelBuilder.Entity<LocationsPositions>(entity =>
            {
                entity.HasKey(e => new { e.PositionId, e.LocationId });

                entity.ToTable("Locations_Positions");

                entity.Property(e => e.PositionId).HasColumnName("positionID");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationsPositions)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Locations__locat__7D439ABD");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.LocationsPositions)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK__Locations__posit__7C4F7684");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.HasKey(e => e.PositionId);

                entity.Property(e => e.PositionId)
                    .HasColumnName("positionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasColumnName("positionName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Wage).HasColumnName("wage");

                entity.Property(e => e.WageGroupId).HasColumnName("wageGroupID");

                entity.HasOne(d => d.WageGroup)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.WageGroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Positions__wageG__4E88ABD4");
            });

            modelBuilder.Entity<ProfilePictures>(entity =>
            {
                entity.HasKey(e => e.ProfilePictureId);

                entity.Property(e => e.ProfilePictureId)
                    .HasColumnName("profilePictureID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasColumnName("picture")
                    .HasColumnType("image");

                entity.Property(e => e.PictureName)
                    .IsRequired()
                    .HasColumnName("pictureName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("roleName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Roles__clientID__1B0907CE");
            });

            modelBuilder.Entity<ScheduleDays>(entity =>
            {
                entity.HasKey(e => e.ScheduleDayId);

                entity.Property(e => e.ScheduleDayId)
                    .HasColumnName("scheduleDayID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.DayName)
                    .IsRequired()
                    .HasColumnName("dayName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnName("endTime");

                entity.Property(e => e.LocationScheduleId).HasColumnName("locationScheduleID");

                entity.Property(e => e.StartTime).HasColumnName("startTime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LocationSchedule)
                    .WithMany(p => p.ScheduleDays)
                    .HasForeignKey(d => d.LocationScheduleId)
                    .HasConstraintName("FK__ScheduleD__locat__300424B4");
            });

            modelBuilder.Entity<ScheduleDaysShifts>(entity =>
            {
                entity.HasKey(e => e.ScheduleDayShiftId);

                entity.ToTable("ScheduleDays_Shifts");

                entity.Property(e => e.ScheduleDayShiftId)
                    .HasColumnName("scheduleDayShiftID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.ScheduleDayId).HasColumnName("scheduleDayID");

                entity.Property(e => e.ShiftId).HasColumnName("shiftID");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ScheduleDay)
                    .WithMany(p => p.ScheduleDaysShifts)
                    .HasForeignKey(d => d.ScheduleDayId)
                    .HasConstraintName("FK__ScheduleD__sched__33D4B598");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.ScheduleDaysShifts)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK__ScheduleD__shift__34C8D9D1");
            });

            modelBuilder.Entity<Shifts>(entity =>
            {
                entity.HasKey(e => e.ShiftId);

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.EndTime).HasColumnName("endTime");

                entity.Property(e => e.ShiftName)
                    .HasColumnName("shiftName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnName("startTime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TimeOffRequests>(entity =>
            {
                entity.HasKey(e => e.TimeOffRequestId);

                entity.Property(e => e.TimeOffRequestId)
                    .HasColumnName("timeOffRequestID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AllDay).HasColumnName("allDay");

                entity.Property(e => e.Approved)
                    .IsRequired()
                    .HasColumnName("approved")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ApprovedBy)
                    .HasColumnName("approvedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedDate).HasColumnName("approvedDate");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateRequested).HasColumnName("dateRequested");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.EndTime).HasColumnName("endTime");

                entity.Property(e => e.RequestSubmittedDate).HasColumnName("requestSubmittedDate");

                entity.Property(e => e.StartTime).HasColumnName("startTime");

                entity.Property(e => e.TimeOffTypeId).HasColumnName("timeOffTypeID");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TimeOffType)
                    .WithMany(p => p.TimeOffRequests)
                    .HasForeignKey(d => d.TimeOffTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__TimeOffRe__timeO__0E6E26BF");
            });

            modelBuilder.Entity<TimeOffTypes>(entity =>
            {
                entity.HasKey(e => e.TimeOffTypeId);

                entity.Property(e => e.TimeOffTypeId)
                    .HasColumnName("timeOffTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnName("typeName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__Users__66DCF95CDB963997")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("Users_Roles");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users_Rol__roleI__1FCDBCEB");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Users_Rol__userI__1ED998B2");
            });

            modelBuilder.Entity<WageGroups>(entity =>
            {
                entity.HasKey(e => e.WageGroupId);

                entity.Property(e => e.WageGroupId)
                    .HasColumnName("wageGroupID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WageName)
                    .IsRequired()
                    .HasColumnName("wageName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WeeklySchedules>(entity =>
            {
                entity.HasKey(e => e.WeeklyScheduleId);

                entity.Property(e => e.WeeklyScheduleId)
                    .HasColumnName("weeklyScheduleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasColumnName("dateUpdated");

                entity.Property(e => e.EndDate).HasColumnName("endDate");

                entity.Property(e => e.StartDate).HasColumnName("startDate");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.WeeklySchedules)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__WeeklySch__clien__5EBF139D");
            });
        }
    }
}
