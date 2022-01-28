using Bookstore.Data.Base;
using Bookstore.Data.ViewModels;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Data.Services
{
    public class BooksService : EntityBaseRepository<Book>, IBooksService
    {
        private readonly AppDbContext _context;
        public BooksService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewBookAsync(NewBookVM data)
        {
            var newBook = new Book()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                PublishingHouseId = data.PublishingHouseId,
                ReleaseDate = data.ReleaseDate,
                BookCategory = data.BookCategory,
                NumberOfPages = data.NumberOfPages,
                AuthorId = data.AuthorId
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

          
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var bookDetails = await _context.Books
                .Include(c => c.PublishingHouse)
                .Include(p => p.Author)
                .FirstOrDefaultAsync(n => n.Id == id);

            return bookDetails;
        }

        public async Task<NewBookDropdownsVM> GetNewBookDropdownsValues()
        {
            var response = new NewBookDropdownsVM()
            {
                PublishingHouses = await _context.PublishingHouses.OrderBy(n => n.Name).ToListAsync(),
                Authors = await _context.Authors.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateBookAsync(NewBookVM data)
        {
            var dbBook = await _context.Books.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbBook != null)
            {
                dbBook.Name = data.Name;
                dbBook.Description = data.Description;
                dbBook.Price = data.Price;
                dbBook.ImageURL = data.ImageURL;
                dbBook.PublishingHouseId = data.PublishingHouseId;
                dbBook.ReleaseDate = data.ReleaseDate;
                dbBook.NumberOfPages = data.NumberOfPages;
                dbBook.BookCategory = data.BookCategory;
                dbBook.AuthorId = data.AuthorId;
                await _context.SaveChangesAsync();
            }

          
            await _context.SaveChangesAsync();
        }
    }
}
