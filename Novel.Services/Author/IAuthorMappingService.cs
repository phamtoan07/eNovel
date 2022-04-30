using Novel.Data;
using Novel.Data.Author;

namespace Novel.Services.Author
{
    public partial interface IAuthorMappingService
    {
        /// <summary>
        /// Authorize whether entity could be accessed in the current author (mapped to this user)
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Wntity</param>
        /// <returns>true - authorized; otherwise, false</returns>
        bool Authorize<T>(T entity) where T : BaseEntity, IAuthorMappingSupported;

        /// <summary>
        /// Authorize whether entity could be accessed in a author (mapped to this store)
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="auhtorId">Store identifier</param>
        /// <returns>true - authorized; otherwise, false</returns>
        bool Authorize<T>(T entity, string authorId) where T : BaseEntity, IAuthorMappingSupported;
    }
}
