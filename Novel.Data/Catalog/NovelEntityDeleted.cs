using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Data.Catalog
{
    public partial class NovelEntityDeleted : NovelEntity
    {
        public DateTime DeletedOnUtc { get; set; }
    }
}
