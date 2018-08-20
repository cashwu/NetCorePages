using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace testPages.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;
        private readonly ILogger<CreateModel> _logger;

        [TempData]
        public string Message { get; set; }
        
        [BindProperty]
        public Customer Customer { get; set; }
        
        public CreateModel(AppDbContext db, ILogger<CreateModel> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();

            var msg = $"Customer {Customer.Name} added";
            Message = msg;
            
            _logger.LogCritical(msg);
            
            return RedirectToPage("/Index");
        }
    }
}