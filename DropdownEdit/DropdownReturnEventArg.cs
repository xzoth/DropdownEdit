using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropdownEdit
{
    public class SelectedRowChangeEventArg : EventArgs
    {
        public DataRow SelectedRow
        {
            get;
            set;
        }
    }

    public delegate void SelectedRowChangeHandler(object sender, SelectedRowChangeEventArg e);
}
