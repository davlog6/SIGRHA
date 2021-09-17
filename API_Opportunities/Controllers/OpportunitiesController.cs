using Microsoft.AspNetCore.Mvc;
using OpportunitiesPersistenceDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpportunitiesDomain;
using API_Opportunities.Entities;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Opportunities.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("[controller]")]
    public class OpportunitiesController : ControllerBase
    {
        /// <summary>
        /// Context, for the database access
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Default constructor to initialize de DbContext
        /// </summary>
        /// <param name="_context"></param>
        public OpportunitiesController(ApplicationDbContext _context) => context = _context;

        // GET: <ValuesController>
        [HttpGet]
        public IEnumerable<OpportunityModel> Get()
        {
            return this.context.Opportunity.ToList();
        }

        // GET <ValuesController>/5
        [HttpGet("{id}")]
        public OpportunityModel Get(int id)
        {
            return this.context.Opportunity.FirstOrDefault(filtro => filtro.IdOpportunity == id);
        }

        // POST <ValuesController>
        [HttpPost]
        public IActionResult Post(OpportunityModel opportunity)
        {
            context.Opportunity.Add(opportunity);
            context.SaveChanges();

            return CreatedAtAction(nameof(Post), new { id = opportunity.IdOpportunity }, opportunity);
        }

        // PUT <ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, OpportunityModel opportunity)
        {
            if (id != opportunity.IdOpportunity)
                return BadRequest();

            //var existingOpportunity = Get(id);
            //if (existingOpportunity is null)
            //    return NotFound();

            context.Opportunity.Update(opportunity);
            context.SaveChanges();

            return NoContent();
        }

        // DELETE <ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var opportunity = context.Opportunity.Find(id);

            if (opportunity is null)
                return NotFound();

            context.Opportunity.Remove(opportunity);
            context.SaveChanges();

            return NoContent();
        }

        [HttpPost("pagination")]
        public IEnumerable<OpportunityModel> PostPagination(PaginationEntity<OpportunityModel> pagination)
        {
            IQueryable<OpportunityModel> items;
            if(pagination.SortDirection == "" || pagination.SortDirection == "asc")
            {
                switch(pagination.SortColumn.ToLower())
                {
                    case "idclient":
                        items = FindAll()
                        .OrderBy(op => op.IdClient)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "opportunityname":
                        items = FindAll()
                        .OrderBy(op => op.OpportunityName)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "idopportunitystatus":
                        items = FindAll()
                        .OrderBy(op => op.IdOpportunityStatus)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "idopportunitytype":
                        items = FindAll()
                        .OrderBy(op => op.IdOpportunityType)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "opportunitygoesby":
                        items = FindAll()
                        .OrderBy(op => op.OpportunityGoesBy)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "opportunitynotes":
                        items = FindAll()
                        .OrderBy(op => op.OpportunityNotes)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "updateddate":
                        items = FindAll()
                        .OrderBy(op => op.UpdatedDate)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "createddate":
                        items = FindAll()
                        .OrderBy(op => op.CreatedDate)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    default:
                        items = FindAll()
                        .OrderBy(op => op.IdOpportunity)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                }
            } 
            else
            {
                switch (pagination.SortColumn.ToLower())
                {
                    case "idclient":
                        items = FindAll()
                        .OrderByDescending(op => op.IdClient)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "opportunityname":
                        items = FindAll()
                        .OrderByDescending(op => op.OpportunityName)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "idopportunitystatus":
                        items = FindAll()
                        .OrderByDescending(op => op.IdOpportunityStatus)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "idopportunitytype":
                        items = FindAll()
                        .OrderByDescending(op => op.IdOpportunityType)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "opportunitygoesby":
                        items = FindAll()
                        .OrderByDescending(op => op.OpportunityGoesBy)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "opportunitynotes":
                        items = FindAll()
                        .OrderByDescending(op => op.OpportunityNotes)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "updateddate":
                        items = FindAll()
                        .OrderByDescending(op => op.UpdatedDate)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "createddate":
                        items = FindAll()
                        .OrderByDescending(op => op.CreatedDate)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    default:
                        items = FindAll()
                        .OrderByDescending(op => op.IdOpportunity)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                }
            }

            int TotalCount = context.Opportunity.Count();
            int TotalPages = (int)Math.Ceiling(TotalCount / (double)pagination.PageSize);
            bool HasPrevious = pagination.CurrentPage > 1;
            bool HasNext = pagination.CurrentPage < TotalPages;

            var metadata = new
            {
                TotalCount,
                pagination.PageSize,
                pagination.CurrentPage,
                TotalPages,
                HasNext,
                HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return items.ToList();
        }

        private IQueryable<OpportunityModel> FindAll()
        {
            return context.Set<OpportunityModel>();
        }
    }
}
