using Novel.Data.Customers;

namespace Novel.Data.Security
{
    public partial class AclRecord : BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public string EntityId { get; set; }

        /// <summary>
        /// Gets or sets the entity name
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Gets or sets the customer role identifier
        /// </summary>
        public string CustomerRoleId { get; set; }

        /// <summary>
        /// Gets or sets the customer role
        /// </summary>
        public virtual CustomerRole CustomerRole { get; set; }
    }
}
