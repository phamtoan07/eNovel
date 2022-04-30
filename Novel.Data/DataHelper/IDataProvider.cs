using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Data.DataHelper
{
    public interface IDataProvider
    {
        /// <summary>
        /// Initialize database
        /// </summary>
        void InitDatabase();

        /// <summary>
        /// Get connetction string
        /// </summary>
        public string ConnectionString { get; }
    }
}
