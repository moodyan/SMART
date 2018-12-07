using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class Employees
    {
        public Employees()
        {
            EmployeeAvailabilities = new HashSet<EmployeeAvailabilities>();
            EmployeeShifts = new HashSet<EmployeeShifts>();
            EmployeesLocations = new HashSet<EmployeesLocations>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? Birtdate { get; set; }
        public DateTimeOffset? HireDate { get; set; }
        public bool? Active { get; set; }
        public int? AddressId { get; set; }
        public int UserId { get; set; }
        public int? ProfilePictureId { get; set; }
        public float? Wage { get; set; }
        public int? WageGroupId { get; set; }
        public int? MaxHoursPerWeek { get; set; }
        public int? MinHoursPerWeek { get; set; }
        public int? PositionId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public Addresses Address { get; set; }
        public Positions Position { get; set; }
        public ProfilePictures ProfilePicture { get; set; }
        public Users User { get; set; }
        public ICollection<EmployeeAvailabilities> EmployeeAvailabilities { get; set; }
        public ICollection<EmployeeShifts> EmployeeShifts { get; set; }
        public ICollection<EmployeesLocations> EmployeesLocations { get; set; }
    }
}
