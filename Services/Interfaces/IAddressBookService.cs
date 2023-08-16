namespace ContactProAltair.Services.Interfaces
{
    public interface IAddressBookService
    {
        public Task AddCategoriesToContactAsync(List<int> categoriesIds, int contactId);
        Task AddCategoriesToContactAsync(object selected, int id);
        public Task RemoveCategoriesFromContactAsync(int contactId);
    }
}
