using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Week2WebAppV2.Data;
using Week2WebAppV2.Models;

namespace Week2WebAppV2.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly Week2WebAppV2.Data.Week2WebAppV2Context _context;

        public DetailsModel(Week2WebAppV2.Data.Week2WebAppV2Context context)
        {
            _context = context;
        }

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
    }
}
