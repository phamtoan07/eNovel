using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Data.Customers
{
    public partial class CustomerRole : BaseEntity
    {

        /// <summary>
        /// Gets or sets the customer role name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the customer Id
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer role is active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer role is system
        /// </summary>
        public bool IsSystemRole { get; set; }

        /// <summary>
        /// Gets or sets the customer role system name
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customers must change passwords after a specified time
        /// </summary>
        public bool EnablePasswordLifetime { get; set; }

    }
}
