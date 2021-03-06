using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Data.Security
{
    public partial interface IAclSupported
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is subject to ACL
        /// </summary>
        bool SubjectToAcl { get; set; }
        IList<string> CustomerRoles { get; set; }
    }
}
