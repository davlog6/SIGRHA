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
    public class OpportunityDocumentsController : ControllerBase
    {
        /// <summary>
        /// Context, for thki0e database access
        /// </summary>
        private readonly ApplicationDbContext context;

        public OpportunityDocumentsController(ApplicationDbContext _context) => context = _context;

        // GET: <OpportunityDocumentsController>
        [HttpGet]
        public IEnumerable<OpportunityDocumentsModel> Get()
        {
            return context.OpportunityDocuments.ToList();
        }

        // GET <OpportunityDocumentsController>/5
        [HttpGet("{id}")]
        public OpportunityDocumentsModel Get(int id)
        {
            return context.OpportunityDocuments.FirstOrDefault(filtro => filtro.IdOpportunityDocuments == id);
        }

        // POST <OpportunityDocumentsController>
        [HttpPost]
        public IActionResult Post(OpportunityDocumentsModel opportunityDocuments)
        {
            context.OpportunityDocuments.Add(opportunityDocuments);
            context.SaveChanges();

            return CreatedAtAction(nameof(Post), new { id = opportunityDocuments.IdOpportunityDocuments }, opportunityDocuments);
        }

        // PUT api/<OpportunityDocumentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, OpportunityDocumentsModel opportunityDocuments)
        {
            if (id != opportunityDocuments.IdOpportunityDocuments)
                return BadRequest();

            context.OpportunityDocuments.Update(opportunityDocuments);
            context.SaveChanges();

            return NoContent();
        }

        // DELETE api/<OpportunityDocumentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var opportunityDocument = context.OpportunityDocuments.Find(id);

            if (opportunityDocument is null)
                return NotFound();

            context.OpportunityDocuments.Remove(opportunityDocument);
            context.SaveChanges();

            return NoContent();
        }

        [HttpPost("pagination")]
        public IEnumerable<OpportunityDocumentsModel> PostPagination(PaginationEntity<OpportunityDocumentsModel> pagination)
        {
            IQueryable<OpportunityDocumentsModel> items;
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
                    case "iddocumenttype":
                        items = FindAll()
                        .OrderBy(op => op.IdDocumentType)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "docnumber":
                        items = FindAll()
                        .OrderBy(op => op.DocNumber)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "documentnotes":
                        items = FindAll()
                        .OrderBy(op => op.DocumentNotes)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "effbegindate":
                        items = FindAll()
                        .OrderBy(op => op.EffBeginDate)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "effenddate":
                        items = FindAll()
                        .OrderBy(op => op.EffEndDate)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "filename":
                        items = FindAll()
                        .OrderBy(op => op.FileName)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    default:
                        items = FindAll()
                        .OrderBy(op => op.IdOpportunityDocuments)
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
                    case "iddocumenttype":
                        items = FindAll()
                        .OrderByDescending(op => op.IdDocumentType)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "docnumber":
                        items = FindAll()
                        .OrderByDescending(op => op.DocNumber)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "documentnotes":
                        items = FindAll()
                        .OrderByDescending(op => op.DocumentNotes)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "effbegindate":
                        items = FindAll()
                        .OrderByDescending(op => op.EffBeginDate)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "effenddate":
                        items = FindAll()
                        .OrderByDescending(op => op.EffEndDate)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    case "filename":
                        items = FindAll()
                        .OrderByDescending(op => op.FileName)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                    default:
                        items = FindAll()
                        .OrderByDescending(op => op.IdOpportunityDocuments)
                        .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                        .Take(pagination.PageSize);
                        break;
                }
            }

            int TotalCount = context.OpportunityDocuments.Count();
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

        private IQueryable<OpportunityDocumentsModel> FindAll()
        {
            return context.Set<OpportunityDocumentsModel>();
        }
    }
}
