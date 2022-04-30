using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Data.Localization
{
    /// <summary>
    /// Represents a localized entity
    /// </summary>
    public interface ILocalizedEntity
    {
        IList<LocalizedProperty> Locales { get; set; }
    }
}
