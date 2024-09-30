using System;
using System.Collections.Generic;

namespace Hope.DomainEntites.DbEntites;

public partial class StudentsTable
{
    public int StudentId { get; set; }

    public string StudentsFirstName { get; set; } = null!;

    public string? StudentsLasttName { get; set; }

    public DateOnly? StudentDateOfbirth { get; set; }

    public int? HighSchoolGrade { get; set; }

    public string? MothersEducation { get; set; }

    public string? FathersEducation { get; set; }

    public string? StudentsEmail { get; set; }

    public string? StudentsPhoneNumber { get; set; }

    public string? StudentsAddress { get; set; }

    public string? StudentsEnrollmentDate { get; set; }

    public string? StudentsPictureUrl { get; set; }

    public int? SectionId { get; set; }

    public virtual SectionTable? Section { get; set; }
}
