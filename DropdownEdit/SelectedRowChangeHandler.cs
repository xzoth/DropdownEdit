using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropdownEdit
{
    /// <summary>
    /// 行选择变更委托
    /// </summary>
    /// <param name="sender">下拉控件</param>
    /// <param name="e">行选择变更事件参数</param>
    public delegate void SelectedRowChangeHandler(object sender, SelectedRowChangeEventArg e);
}
