using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Data.Author
{
    public partial interface IAuthorMappingSupported
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
        /// </summary>
        bool LimitedToAuthor { get; set; }
        IList<string> Authors { get; set; }
    }
}
