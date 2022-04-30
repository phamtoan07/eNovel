using Novel.Data.Common;
using System.Collections.Generic;

namespace Novel.Data
{
    public abstract partial class BaseEntity : ParentEntity
    {
        protected BaseEntity()
        {
            GenericAttributes = new List<GenericAttribute>();
        }

        public IList<GenericAttribute> GenericAttributes { get; set; }

    }
}
