using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteExplorer.ViewModel
{
    public class TriggerViewModel
    {
        #region private fields
        private string _name;
        private string _tableName;
        #endregion
        
        /// <summary>
        /// Table name
        /// </summary>
        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        /// <summary>
        /// Trigger name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        public TriggerViewModel()
        {
            _name = "";
        }
    }
}
