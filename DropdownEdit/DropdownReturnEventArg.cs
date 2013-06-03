using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropdownEdit
{
    /// <summary>
    /// 行选择变更事件参数
    /// </summary>
    public class SelectedRowChangeEventArg : EventArgs
    {
        /// <summary>
        /// 选中的行
        /// </summary>
        public DataRow SelectedRow
        {
            get;
            set;
        }
    }
}
