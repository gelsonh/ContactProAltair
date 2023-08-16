using ContactProAltair.Data;
using ContactProAltair.Models;
using ContactProAltair.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactProAltair.Services
{
    public class AddressBookServices : IAddressBookService
    {
        private readonly ApplicationDbContext _context;

        public AddressBookServices(ApplicationDbContext context)
        {
           _context = context;
        }

        public async Task AddCategoriesToContactAsync(List<int> categoryIds, int contactId)
        {
            try 
            {
                // get the contact to add categories to
                Contact? contact = await _context.Contacts.
                                           Include(c => c.Categories).
                                           FirstOrDefaultAsync(c => c.Id == contactId);

                // if this contact does't exist,
                // just qui
                if (contact == null)
                {
                    return;
                }

                // loop through each category ID
                foreach(int categoryId in categoryIds)
                {

                // -make sure the category exists
                Category? category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
                    // -if it does, add the contact to that category
                    if (category != null)
                    {
                        contact.Categories.Add(category);
                    }
                }

                // when I'm done, save the changes to the database
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task AddCategoriesToContactAsync(object selected, int id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveCategoriesFromContactAsync(int contactId)
        {
            try
            {
                // find the contact by ID
                Contact? contact = await _context.Contacts.
                                           Include(c => c.Categories).
                                           FirstOrDefaultAsync(c => c.Id == contactId);
                if (contact != null)
                {
                    // remove all of their categories
                    contact.Categories.Clear();
                    // save those changes to the database
                    await _context.SaveChangesAsync();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
