using System;
using Microsoft.EntityFrameworkCore;
using StudentTeacherEFCore.Data.Entities;

namespace StudentTeacherEFCore.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions options)
			:base(options)
		{

		}
		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
	}
}

