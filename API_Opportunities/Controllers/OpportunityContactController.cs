using API_Opportunities.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpportunitiesDomain;
using OpportunitiesPersistenceDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Opportunities.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OpportunityContactController : ControllerBase
    {

        /// <summary>
        /// Context, for the database access
        /// </summary>
        private readonly ApplicationDbContext context;

        public OpportunityContactController(ApplicationDbContext _context) => context = _context;

        // GET: <OpportunityContactController>
        [HttpGet]
        public IEnumerable<OpportunityContactModel> Get()
        {
            return context.OpportunityContact.ToList();
        }
         
        // GET <OpportunityContactController>/5
        [HttpGet("{id}")]
        public OpportunityContactModel Get(int id)
        {
            return context.OpportunityContact.FirstOrDefault(filtro => filtro.IdOpportunityContacts == id);
        }

        // POST <OpportunityContactController>
        [HttpPost]
        public IActionResult Post(OpportunityContactModel opportunityContact)
        {
            context.OpportunityContact.Add(opportunityContact);
            context.SaveChanges();

            return CreatedAtAction(nameof(Post), new { id = opportunityContact.IdOpportunityContacts }, opportunityContact);
        }

        // PUT <OpportunityContactController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, OpportunityContactModel opportunityContact)
        {
            if (id != opportunityContact.IdOpportunityContacts)
                return BadRequest();

            context.OpportunityContact.Update(opportunityContact);
            context.SaveChanges();

            return NoContent();
        }

        // DELETE <OpportunityContactController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var opportunityContact = context.OpportunityContact.Find(id);

            if (opportunityContact is null)
                return NotFound();

            context.OpportunityContact.Remove(opportunityContact);
            context.SaveChanges();

            return NoContent();
        }

        [HttpPost("pagination")]
        public IEnumerable<OpportunityContactModel> PostPagination(PaginationEntity<OpportunityContactModel> pagination)
        {
            IQueryable<OpportunityContactModel> items;
            if (pagination.SortDirection == "" || pagination.SortDirection == "asc")
            {
                switch (pagination.SortColumn.ToLower())
                {
                    case "idopportunity":
                        items = FindAll()
                        .OrderBy(op => op.IdOpportunity)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "contactnotes":
                        items = FindAll()
                        .OrderBy(op => op.ContactNotes)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "email":
                        items = FindAll()
                        .OrderBy(op => op.EMail)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "firstname":
                        items = FindAll()
                        .OrderBy(op => op.FirstName)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "goesby":
                        items = FindAll()
                        .OrderBy(op => op.GoesBy)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "idphonetype":
                        items = FindAll()
                        .OrderBy(op => op.IdPhoneType)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "lastname":
                        items = FindAll()
                        .OrderBy(op => op.LastName)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "middlename":
                        items = FindAll()
                        .OrderBy(op => op.MiddleName)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "organizationrole":
                        items = FindAll()
                        .OrderBy(op => op.OrganizationRole)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "phonenumber":
                        items = FindAll()
                        .OrderBy(op => op.PhoneNumber)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    default:
                        items = FindAll()
                        .OrderBy(op => op.IdOpportunityContacts)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                }
            }
            else
            {
                switch (pagination.SortColumn.ToLower())
                {
                    case "idopportunity":
                        items = FindAll()
                        .OrderByDescending(op => op.IdOpportunity)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "contactnotes":
                        items = FindAll()
                        .OrderByDescending(op => op.ContactNotes)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "email":
                        items = FindAll()
                        .OrderByDescending(op => op.EMail)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "firstname":
                        items = FindAll()
                        .OrderByDescending(op => op.FirstName)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "goesby":
                        items = FindAll()
                        .OrderByDescending(op => op.GoesBy)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "idphonetype":
                        items = FindAll()
                        .OrderByDescending(op => op.IdPhoneType)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "lastname":
                        items = FindAll()
                        .OrderByDescending(op => op.LastName)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "middlename":
                        items = FindAll()
                        .OrderByDescending(op => op.MiddleName)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "organizationrole":
                        items = FindAll()
                        .OrderByDescending(op => op.OrganizationRole)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "phonenumber":
                        items = FindAll()
                        .OrderByDescending(op => op.PhoneNumber)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    default:
                        items = FindAll()
                        .OrderByDescending(op => op.IdOpportunityContacts)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                }
            }

            int TotalCount = context.OpportunityContact.Count();
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

        private IQueryable<OpportunityContactModel> FindAll()
        {
            return context.Set<OpportunityContactModel>();
        }
    }
}
