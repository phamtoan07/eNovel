using Novel.Data.Customers;
using Novel.Data.Localization;
using System.Threading.Tasks;

namespace Novel.Core
{
    public interface IWorkContext
    {
        /// <summary>
        /// Gets the current customer
        /// </summary>
        Customer CurrentCustomer { get; }

        /// <summary>
        /// Set the current customer by Middleware
        /// </summary>
        /// <returns></returns>
        Task<Customer> SetCurrentCustomer();

        /// <summary>
        /// Set the current customer 
        /// </summary>
        /// <returns></returns>
        Task<Customer> SetCurrentCustomer(Customer customer);

        /// <summary>
        /// Gets or sets the original customer (in case the current one is impersonated)
        /// </summary>
        Customer OriginalCustomerIfImpersonated { get; }

        /// <summary>
        /// Get or set current user working language
        /// </summary>
        Language WorkingLanguage { get; }

        /// <summary>
        /// Set current user working language by Middleware
        /// </summary>
        Task<Language> SetWorkingLanguage(Customer customer);

        /// <summary>
        /// Set current user working language
        /// </summary>
        Task<Language> SetWorkingLanguage(Language language);


    }
}
