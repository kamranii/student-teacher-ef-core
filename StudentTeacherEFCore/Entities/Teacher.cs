using System;
namespace StudentTeacherEFCore.Data.Entities
{
	public class Teacher
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Experience { get; set; }
		public Teacher()
		{
		}
	}
}

