using Fred.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fred.Controllers
{
    public class MajorsController : ApiController    {
		private FredDbContext db = new FredDbContext();

		[HttpGet]
		[ActionName("List")]
		public IEnumerable<Major> List()		{
			return db.Majors.ToList();

		}
		[HttpGet]
		[ActionName("Get")]
		public Major Get(int? id)
		{  //making this int? allows null to be passed in so back side doesn;t blowup
			if (id == null)
				return null;
			return db.Majors.Find(id);
		}
		[HttpPost]
		[ActionName("Create")]
		public bool Create(Major major)
		{
			if (major == null)
				return false;
			if (!ModelState.IsValid) {
				return false;
			}
			db.Majors.Add(major);
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		[ActionName("Change")]
		public bool Change(Major major)
		{
			if (major == null)
				return false;
			if (!ModelState.IsValid) {
				return false;
			}
			var maj = db.Majors.Find(major.Id);
			maj.Description = major.Description;
			maj.MinSat = major.MinSat;
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		[ActionName("Remove")]
		public bool Remove(Major major)
		{
			if (major == null)
				return false;
			if (!ModelState.IsValid) {
				return false;
			}
			var cust = db.Majors.Find(major.Id);
			db.Majors.Remove(cust);
			db.SaveChanges();
			return true;
		}
    }
}
