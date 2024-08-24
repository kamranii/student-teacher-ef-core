using System;
namespace StudentTeacherEFCore.Data.Entities
{
	public class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int AverageGrade { get; set; }
		public Student()
		{
		}
	}
}

