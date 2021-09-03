using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesPersistenceDataBase;
using EmployeesDomain;


namespace API_Employees.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeesController : ControllerBase
    {
        //public IEmployees _interface;

        //  public DefaultController(IEmployees iemp)
        //  {
        //      _interface = iemp;
        //  }

        //  [HttpGet]
        //  [Route("getAllEmployees")]
        ////  [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<EmployeeModel>))]
        //  public async Task<IHttpActionResult> getEmployees()
        //  {
        //      try
        //      {
        //          var result = await _interface.getEmployees();
        //          return (IHttpActionResult)Ok(result);
        //      }
        //      catch (Exception ex)
        //      {
        //          return (IHttpActionResult)BadRequest("Failed getting employees" + ex.Message);
        //      }
        //  }


        private readonly ApplicationDbContext context;
        public EmployeesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<EmployeeModel> Get()
        {
            return context.Employee.ToList();
        }


        [HttpGet("{id}")]
        public EmployeeModel Get(int id)
        {
            var employee = context.Employee.FirstOrDefault(p => p.IdEmployees == id);
            return employee;
        }
    }
}
