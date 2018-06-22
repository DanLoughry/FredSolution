using Fred.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fred.Controllers
{
    public class StudentsController : ApiController    {
		private FredDbContext db = new FredDbContext();

		[HttpGet]
		[ActionName("List")]
		public IEnumerable<Student> List()		{
			return db.Students.ToList();
		}

		[HttpGet]
		[ActionName("Get")]
		public Student Get(int? id)		{
			if (id == null) 
			return null;
			return db.Students.Find();
		}
		[HttpPost]
		[ActionName("Create")]
		public bool Create(Student student)		{
			if (student == null)
				return false;
			if (!ModelState.IsValid)
				return false;
			var stu = db.Students.Find(student.Id);
			stu.Name = student.Name;
			stu.Sat = student.Sat;
			stu.MajorId = student.MajorId;
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		[ActionName("Remove")]
		public bool Remove(Student student)		{
			if (student == null)
				return false;
			if (ModelState.IsValid)
				return false;
			var stu = db.Students.Find(student.Id);
			db.Students.Remove(stu);
			db.SaveChanges();
			return true;
		}



	}
}
