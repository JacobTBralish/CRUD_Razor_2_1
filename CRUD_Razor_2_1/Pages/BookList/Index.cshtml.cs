using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Razor_2_1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Razor_2_1.Pages.BookList
{
    public class IndexModel : PageModel
    {
        /* The instance of the database is set to readonly private because this
         * instance should be kept confined to this component only */
        private readonly ApplicationDbContext _db;
        /* Set to IEnumerable so we are able to invoke "foreach" upon the data for displaying. IEnumerable provides a 
         a method "IEnumerator" which returns an IEnumerator and provides the ability to iterate through a collection by 
         exposing the current property and MoveNext and Reset methods.
         *****SIMPLE TERMS: IEnumerable makes using foreach possible on the collection*/
        public IEnumerable<Book> Books { get; set; }

        // This is creating an instance of the database so that we can retrive it,
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        // To make async you must add async Task here to get the data
        public async Task OnGet()
        {
            /* Async method used to get the books and stored to the IEnumerable.
             _db.Books is coming from the ApplicationDbContext which is the DbSet.*/
            Books = await _db.Books.ToListAsync();
        }
    }
}