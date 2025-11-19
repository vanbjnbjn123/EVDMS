using System;

namespace EVDMS.Core.Entities;

/// <summary>
/// Represents a system user (employee, manager, admin) in the EVDMS.
/// Contains user authentication information, personal details, and role assignments.
/// Users can create quotes, manage orders, and perform various system operations based on their permissions.
/// </summary>
public class User : EntityBase
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime? LastLoginAt { get; set; }
    public int AccessFailCount { get; set; } = 0;
    public bool? LockoutEnable { get; set; }
    public DateTime? LockoutEnd { get; set; }

    // User information
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public int Gender { get; set; } = 2; // Default to Other
    public int Age
    {

        get
        {
            if (DateOfBirth == null) return 0;
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Value.Year;
            if (DateOfBirth.Value.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
    public string Address { get; set; } = string.Empty;
    

    
    // Navigation properties
    public Contract? Contract { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public ICollection<TestDriveAppointment> AssignedTestDrives { get; set; } = new List<TestDriveAppointment>();
    public ICollection<UserOrganization> UserOrganizations { get; set; } = new List<UserOrganization>();

}
