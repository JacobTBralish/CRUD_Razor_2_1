using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Razor_2_1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD_Razor_2_1.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        // Bind property
        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {

        }

        //Post handler. If we do not want to retrive the Book object from the razor page we can do a bindproperty shown above
        public async Task<IActionResult> OnPost(/*Book Book*/)
        {
            /*1. ModelState tells you if an model errors have been added to ModelState. The default model binder will add
             some errors for basic type conversion issues (ex. passing a non-number for something which is an int). You can
             populate ModelState more fully based on whichever validation you're using.
             2. Indecates if it was possible to bind the incoming values from the request to the model*/
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Books.Add(Book);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}