using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Core.Caching.Constants
{
    public static partial class CacheKey
    {
        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string NOVELS_PATTERN_KEY => "Grand.novel.";
        public static string NOVELS_BY_ID_KEY => "Grand.novel.id-{0}";
        public static string NOVELS_CUSTOMER_PERSONAL_PATTERN => "Grand.novel.personal";
        public static string NOVELS_CUSTOMER_ROLE_PATTERN => "Grand.novel.cr";
        public static string NOVELS_CUSTOMER_TAG_PATTERN => "Grand.novel.ct -{0}";
    }
}
