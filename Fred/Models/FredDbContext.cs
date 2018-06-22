using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Fred.Models
{
	public class FredDbContext : DbContext	{

		public FredDbContext() : base() { }
		public DbSet<Major> Majors { get; set; }
		public DbSet<Student> Students { get; set; }

	}
}