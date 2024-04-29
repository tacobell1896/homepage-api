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
    public class LinkItemsController : ControllerBase
    {
        private readonly LinkContext _context;

        public LinkItemsController(LinkContext context)
        {
            _context = context;
        }

        // GET: api/LinkItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LinkItem>>> GetLinks()
        {
            return await _context.Links.ToListAsync();
        }

        // GET: api/LinkItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LinkItem>> GetLinkItem(long id)
        {
            var linkItem = await _context.Links.FindAsync(id);

            if (linkItem == null)
            {
                return NotFound();
            }

            return linkItem;
        }

        // PUT: api/LinkItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLinkItem(long id, LinkItem linkItem)
        {
            if (id != linkItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(linkItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkItemExists(id))
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

        // POST: api/LinkItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LinkItem>> PostLinkItem(LinkItem linkItem)
        {
            _context.Links.Add(linkItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostLinkItem), new { id = linkItem.Id }, linkItem);
        }

        // DELETE: api/LinkItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLinkItem(long id)
        {
            var linkItem = await _context.Links.FindAsync(id);
            if (linkItem == null)
            {
                return NotFound();
            }

            _context.Links.Remove(linkItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LinkItemExists(long id)
        {
            return _context.Links.Any(e => e.Id == id);
        }
    }
}
