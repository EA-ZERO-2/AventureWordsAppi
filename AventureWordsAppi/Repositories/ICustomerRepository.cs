using AdventureWorksNS.Data;
namespace AventureWordsAppi.Repositories
{
    public interface ICustomerRepository
    {
        /*
         * CRUD
         * C = Create  (Crear)
         * R = Read  (Leer)
         * U = Update 
         * D = Delete 
         */
         
        Task<Customer> CreateAsync(Customer customer);
        Task<IEnumerable<Customer>> RetrieveAllAsync();
        Task<Customer?> RetrieveAsync(int id);
        Task<Customer?> UpdateAsync(int id, Customer c);
        Task<bool?> DeleteAsync(int id);

    }
}
