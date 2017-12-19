using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;
using System.Threading;
using EmployeeService;

namespace DemoWepApi.Controllers
{
	public class EmployeeController : ApiController

	{
		
		[BasicAuthentication]
	    [HttpGet]
		//[Route("api/Employee/")]
		public HttpResponseMessage Get()
		{
			using (EmployeeDBEntities entities = new EmployeeDBEntities())
			{
				string username = Thread.CurrentPrincipal.Identity.Name;

				switch (username)
				{
					//case "all":
					//	return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.ToList());

					case "female":
						return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.Where(e => e.Gender == username).ToList());


					case "male":
						return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.Where(e => e.Gender == username).ToList());

					default:
						return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "enter gender as male or female or all");

				}
			}
		}
		[HttpGet]
	   [BasicAuthentication]
		public HttpResponseMessage Get(int id)
		{
			try
			{
				using (EmployeeDBEntities entities = new EmployeeDBEntities())
				{
					var entity = entities.Employees.FirstOrDefault(e => e.Id == id);
					if (entity != null)
					{
						return Request.CreateResponse(HttpStatusCode.OK, entity);

					}
					else
					{
						return Request.CreateResponse(HttpStatusCode.NotFound, "employee with id=" + id + "not found");
					}
				}
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
		}
		public HttpResponseMessage Post([FromBody]Employee employee)
		{
			try
			{
				using (EmployeeDBEntities addentities = new EmployeeDBEntities())
				{
					addentities.Employees.Add(employee);
					addentities.SaveChanges();
					var message = Request.CreateResponse(HttpStatusCode.Created, employee);
					return message;
				}
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
		}

		public HttpResponseMessage Delete(int id)
		{
			using (EmployeeDBEntities entities = new EmployeeDBEntities())
			{
				var entity = entities.Employees.FirstOrDefault(e => e.Id == id);
				if (entity == null)
				{
					return Request.CreateErrorResponse(HttpStatusCode.NotFound, "employee with id" + id + "not found");
				}
				else
				{
					entities.Employees.Remove(entity);
					entities.SaveChanges();
					return Request.CreateResponse(HttpStatusCode.OK, "employee deleted successfully");
				}
			}

		}
		public HttpResponseMessage Put(int id, [FromBody]Employee employee)
		{
			try
			{
				using (EmployeeDBEntities entities = new EmployeeDBEntities())
				{
					var entity = entities.Employees.FirstOrDefault(e => e.Id == id);
					if (entity == null)
					{
						return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id" + id + "not found");
					}
					else
					{
						entity.FirstName = employee.FirstName;
						entity.Gender = employee.Gender;
						entity.LastName = employee.LastName;
						entity.Salary = employee.Salary;
						entities.SaveChanges();
						return Request.CreateResponse(HttpStatusCode.OK);
					}

				}
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
		}
	}
}
