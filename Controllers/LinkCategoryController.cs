using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomePageApi.Models;

namespace HomePageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkCategoryController : ControllerBase
    {
        private readonly LinkContext _context;

        public LinkCategoryController(LinkContext context)
        {
            _context = context;
        }

        // GET: api/LinkCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LinkCategory>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        // GET: api/LinkCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LinkCategory>> GetLinkCategory(long id)
        {
            var linkCategory = await _context.Categories.FindAsync(id);

            if (linkCategory == null)
            {
                return NotFound();
            }

            return linkCategory;
        }

        // PUT: api/LinkCategory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLinkCategory(long id, LinkCategory linkCategory)
        {
            if (id != linkCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(linkCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LinkCategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LinkCategory>> PostLinkCategory(LinkCategory linkCategory)
        {
            _context.Categories.Add(linkCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostLinkCategory), new { id = linkCategory.Id }, linkCategory);
        }

        // DELETE: api/LinkCategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLinkCategory(long id)
        {
            var linkCategory = await _context.Categories.FindAsync(id);
            if (linkCategory == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(linkCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LinkCategoryExists(long id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
