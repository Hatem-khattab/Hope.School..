using System;
using System.Collections.Generic;

namespace Hope.DomainEntites.DbEntites;

public partial class SectionTable
{
    public int SectionId { get; set; }

    public string SectionName { get; set; } = null!;

    public int? SectionIsFull { get; set; }

    public int? SectionTeacher { get; set; }

    public virtual TeachersTable? SectionTeacherNavigation { get; set; }

    public virtual ICollection<StudentsTable> StudentsTables { get; set; } = new List<StudentsTable>();
}
