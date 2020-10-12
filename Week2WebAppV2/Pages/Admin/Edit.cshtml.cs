using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Week2WebAppV2.Data;
using Week2WebAppV2.Models;

namespace Week2WebAppV2.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly Week2WebAppV2.Data.Week2WebAppV2Context _context;

        public EditModel(Week2WebAppV2.Data.Week2WebAppV2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Candle Candle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Candle = await _context.Candle.FirstOrDefaultAsync(m => m.id == id);

            if (Candle == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Candle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandleExists(Candle.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CandleExists(int id)
        {
            return _context.Candle.Any(e => e.id == id);
        }
    }
}
