using System;
using System.Collections.Generic;

namespace Hope.DomainEntites.DbEntites;

public partial class TeachersTable
{
    public int TeachersId { get; set; }

    public string TeachersFirstName { get; set; } = null!;

    public string TeachersLastName { get; set; } = null!;

    public string? TeachersEmail { get; set; }

    public string? TeachersPhoneNumber { get; set; }

    public string? TeachersDateOfBirth { get; set; }

    public string? TeachersHireDate { get; set; }

    public string? TeachersSpecialization { get; set; }

    public string? TeachersAddress { get; set; }

    public string? TeachersPictureUrl { get; set; }

    public string? Isactive { get; set; }

    public virtual ICollection<SectionTable> SectionTables { get; set; } = new List<SectionTable>();
}
