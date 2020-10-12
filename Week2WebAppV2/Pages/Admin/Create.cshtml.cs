using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Week2WebAppV2.Data;
using Week2WebAppV2.Models;

namespace Week2WebAppV2.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly Week2WebAppV2.Data.Week2WebAppV2Context _context;

        public CreateModel(Week2WebAppV2.Data.Week2WebAppV2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Candle Candle { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Candle.Add(Candle);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
