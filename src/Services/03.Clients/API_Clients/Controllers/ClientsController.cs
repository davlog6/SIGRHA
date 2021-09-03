using ClientsDomain;
using ClientsPersistenceDataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Clients.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientsController : ControllerBase
    {


        private readonly ApplicationDbContext context;
        public ClientsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<ClientModel> Get()
        {
            return context.Client.ToList();
        }


        [HttpGet("{id}")]
        public ClientModel Get(int id)
        {
            var employee = context.Client.FirstOrDefault(p => p.IdClient == id);
            return employee;
        }
    }
}
