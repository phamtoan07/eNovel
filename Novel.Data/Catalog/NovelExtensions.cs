using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Data.Catalog
{
    public static class NovelExtensions
    {
        /// <summary>
        /// Parse "required novel Ids" property
        /// </summary>
        /// <param name="product">Novel</param>
        /// <returns>A list of required novel IDs</returns>
        public static string[] ParseRequiredNovelIds(this NovelEntity novel)
        {
            if (novel == null)
                throw new ArgumentNullException("novel");

            if (String.IsNullOrEmpty(novel.RequiredNovelIds))
                return new string[0];

            var ids = new List<string>();

            foreach (var idStr in novel.RequiredNovelIds
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim()))
            {
                ids.Add(idStr);
            }

            return ids.ToArray();
        }

        /// <summary>
        /// Get a value indicating whether a product is available now (availability dates)
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Result</returns>
        public static bool IsAvailable(this NovelEntity novel)
        {
            return IsAvailable(novel, DateTime.UtcNow);
        }

        public static bool IsAvailable(this NovelEntity novel, DateTime dateTime)
        {
            if (novel == null)
                throw new ArgumentNullException("novel");

            if (novel.AvailableStartDateTimeUtc.HasValue && novel.AvailableStartDateTimeUtc.Value > dateTime)
            {
                return false;
            }

            if (novel.AvailableEndDateTimeUtc.HasValue && novel.AvailableEndDateTimeUtc.Value < dateTime)
            {
                return false;
            }

            return true;
        }
    }
}
