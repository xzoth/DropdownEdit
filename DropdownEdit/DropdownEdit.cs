using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DropdownEdit
{
    /// <summary>
    /// 多列下拉选择控件
    /// </summary>
    public class DropdownEdit : PopupContainerEdit
    {
        #region Menber

        /// <summary>
        /// 事件锁
        /// </summary>
        private readonly object eventLock = new object();

        /// <summary>
        /// 类型名
        /// </summary>
        public const string CONST_TYPE_NAME = "DropdownEdit";

        /// <summary>
        /// 文本改变事件自复位开关
        /// 设置此复位开关的目的是为了拦截基类及其他方法触发的“不在期望内”的文本改变事件
        /// </summary>
        protected bool AutoResetControl = false;

        #endregion

        #region Event

        /// <summary>
        /// 行选择变更事件
        /// </summary>
        private SelectedRowChangeHandler selectedRowChangeHandler;
        /// <summary>
        /// 行选择变更事件
        /// </summary>
        [Category("属性已更改"), Description("行选择变更事件")]
        public event SelectedRowChangeHandler SelectedRowChange
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                lock (eventLock)
                {
                    selectedRowChangeHandler += value;
                }
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                lock (eventLock)
                {
                    selectedRowChangeHandler -= value;
                }
            }
        }

        #endregion

        #region Property

        /// <summary>
        /// 获取选中的数据行
        /// </summary>
        [NonSerialized]
        private DataRow selectedRow;
        /// <summary>
        /// 获取选中的数据行
        /// </summary>
        [XmlIgnore, Browsable(false), Category("数据"), Description("获取选中的数据行")]
        public DataRow SelectedRow
        {
            get
            {
                return selectedRow;
            }
            internal protected set
            {
                selectedRow = value;
            }
        }

        /// <summary>
        /// 获取值
        /// </summary>
        [XmlIgnore, Browsable(false), Category("数据"), Description("获取值")]
        public object Value
        {
            get
            {
                object resultObj = null;
                if (SelectedRow != null && !string.IsNullOrWhiteSpace(DisplayMember))
                {
                    resultObj = SelectedRow[DisplayMember];
                }

                return resultObj;
            }
        }

        /// <summary>
        /// 获取或设置绑定的数据源
        /// </summary>
        [XmlIgnore, Browsable(false)]
        [Category("数据"), Description("数据源")]
        public DataTable DataSource
        {
            get
            {
                return this.Properties.DataSource;
            }
            set
            {
                this.Properties.DataSource = value;
                SelectedRow = null;
                AutoResetControl = true;
                Text = string.Empty;
            }
        }

        /// <summary>
        /// 获取或者设置下拉框高度
        /// </summary>
        [DefaultValue(200), Browsable(true), Category("外观"), Description("获取或者设置下拉框高度")]
        public int DropdownHeight
        {
            get
            {
                return this.Properties.DropdownHeight;
            }
            set
            {
                this.Properties.DropdownHeight = value;
            }
        }

        /// <summary>
        /// 获取或者设置下拉框宽度
        /// </summary>
        [DefaultValue(300), Browsable(true), Category("外观"), Description("获取或者设置下拉框宽度")]
        public int DropdownWidth
        {
            get
            {
                return this.Properties.DropdownWidth;
            }
            set
            {
                this.Properties.DropdownWidth = value;
            }
        }

        /// <summary>
        /// 获取或者设置是否在录入时自动展开下拉列表
        /// </summary>
        private bool isExpandOnEdit = true;
        /// <summary>
        /// 获取或者设置是否录入时自动展开下拉列表
        /// </summary>
        [Browsable(true)]
        [Description("获取或者设置是否在录入时自动展开下拉列表")]
        [Category("行为")]
        [DefaultValue(true)]
        public bool IsExpandOnEdit
        {
            get
            {
                return isExpandOnEdit;
            }
            set
            {
                isExpandOnEdit = value;
            }
        }

        /// <summary>
        /// 获取或者设置是否在筛选时自动选中项
        /// </summary>
        private bool isAutoSelect = false;
        /// <summary>
        /// 获取或者设置是否在筛选时自动选中项
        /// </summary>
        [Browsable(true)]
        [Description("获取或者设置是否在筛选时自动选中项")]
        [Category("行为")]
        [DefaultValue(false)]
        public virtual bool IsAutoSelect
        {
            get
            {
                return isAutoSelect;
            }
            set
            {
                isAutoSelect = value;
            }
        }

        /// <summary>
        /// 获取或者设置是否根据录入的字符对下拉列表进行筛选过滤
        /// </summary>
        private bool isApplyRowFilter = true;
        /// <summary>
        /// 获取或者设置是否根据录入的字符对下拉列表进行筛选过滤
        /// </summary>
        [Browsable(true)]
        [Description("获取或者设置是否根据录入的字符对下拉列表进行筛选过滤")]
        [Category("行为")]
        [DefaultValue(true)]
        public virtual bool IsApplyRowFilter
        {
            get
            {
                return isApplyRowFilter;
            }
            set
            {
                isApplyRowFilter = value;
            }
        }

        /// <summary>
        /// 获取或者设置是否高亮关键字
        /// </summary>
        private bool isHighlightKeyword = false;
        /// <summary>
        /// 获取或者设置是否高亮关键字
        /// </summary>
        [Browsable(true)]
        [Description("获取或者设置是否高亮关键字")]
        [Category("行为")]
        [DefaultValue(false)]
        public virtual bool IsHighlightKeyword
        {
            get
            {
                return isHighlightKeyword;
            }
            set
            {
                isHighlightKeyword = value;
            }
        }

        /// <summary>
        /// 类型名
        /// </summary>
        public override string EditorTypeName
        {
            get
            {
                return DropdownEdit.CONST_TYPE_NAME;
            }
        }

        private RepositoryItemDropdownEdit properties;
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemDropdownEdit Properties
        {
            get
            {
                if (this.properties == null)
                {
                    this.properties = base.Properties as RepositoryItemDropdownEdit;
                    if (this.properties == null)
                    {
                        this.properties = new RepositoryItemDropdownEdit();
                    }
                }

                return this.properties;
            }
            internal protected set
            {
                this.properties = value;
            }
        }

        /// <summary>
        /// 获取或者设置显示的成员
        /// </summary>
        private string displayMember = string.Empty;
        /// <summary>
        /// 获取或者设置显示的成员
        /// </summary>
        [Browsable(true), Category("数据"), Description("获取或者设置显示的成员"), DefaultValue("")]
        public string DisplayMember
        {
            get
            {
                return displayMember;
            }
            set
            {
                if (displayMember != value)
                {
                    displayMember = value;

                    if (SelectedRow != null)
                    {
                        AutoResetControl = true;
                        base.Text = SelectedRow[displayMember].ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 获取或者设置关键字匹配模式
        /// </summary>
        private StringComparison keyWordMatchMode = StringComparison.CurrentCultureIgnoreCase;
        /// <summary>
        /// 获取或者设置关键字匹配模式
        /// </summary>
        [Browsable(true), DefaultValue(StringComparison.CurrentCultureIgnoreCase), Category("行为"), Description("获取或者设置关键字匹配模式")]
        public StringComparison KeyWordMatchMode
        {
            get
            {
                return keyWordMatchMode;
            }
            set
            {
                keyWordMatchMode = value;
            }
        }

        /// <summary>
        /// 获取或设置是否单击时展开列表
        /// </summary>
        private bool isExpandOnClick = true;
        /// <summary>
        /// 获取或设置是否单击时展开列表
        /// </summary>
        [Browsable(true), DefaultValue(true), Category("行为"), Description("获取或设置是否单击时展开列表")]
        public bool IsExpandOnClick
        {
            get
            {
                return isExpandOnClick;
            }
            set
            {
                isExpandOnClick = value;
            }
        }

        #endregion

        #region Method

        static DropdownEdit()
        {
            RepositoryItemDropdownEdit.RegisterDropdownEdit();
        }

        public DropdownEdit()
            : base()
        {
            this.properties = base.Properties as RepositoryItemDropdownEdit;
        }

        /// <summary>
        /// 文本改变事件处理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            #region 检查复位开关

            //拦截事件的执行
            if (AutoResetControl)
            {
                //复位
                AutoResetControl = false;
                return;
            }

            #endregion

            //展开
            IfExpand();

            if (IsApplyRowFilter)
            {
                ApplyFilter();
            }
            else
            {
                DoAutoSelect();
            }

            base.OnTextChanged(e);
        }

        /// <summary>
        /// 触发行选择变更事件
        /// </summary>
        /// <param name="row"></param>
        internal protected virtual void OnSelectedRowChanged(DataRow row)
        {
            string strText = row[DisplayMember].ToString();
            Text = strText;

            SelectedRow = row;

            SelectedRowChangeEventArg changeEventArg = new SelectedRowChangeEventArg() { SelectedRow = row };
            if (selectedRowChangeHandler != null)
            {
                selectedRowChangeHandler(this, changeEventArg);
            }

            this.ClosePopup();
        }

        /// <summary>
        /// 弹出下拉框事件处理
        /// </summary>
        protected override void OnPopupShown()
        {
            if (Text.Length > 0)
            {
                //移除筛选以显示所有数据
                Properties.RowFilter = string.Empty;

                //选中当前行
                DoAutoSelect();
            }

            this.Focus();
        }        

        /// <summary>
        /// 默认选中
        /// </summary>
        protected virtual void DoAutoSelect()
        {
            //查找编辑器文本
            for (int rowIndex = 0; rowIndex < Properties.DataView.Count; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < Properties.DataSource.Columns.Count; columnIndex++)
                {
                    //项文本
                    string strText = Properties.DataView[rowIndex][Properties.DataSource.Columns[columnIndex].ColumnName].ToString();
                    if (strText.Length >= Text.Length)
                    {
                        if (strText.Equals(Text, KeyWordMatchMode))
                        {
                            Properties.GridView.FocusedRowHandle = rowIndex;
                            break;
                        }
                    }//end if
                }// end for
            }//end for
        }

        /// <summary>
        /// 鼠标击键事件处理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (IsExpandOnClick && !this.IsPopupOpen)
            {
                this.ShowPopup();
            }
        }

        /// <summary>
        /// 键盘击键事件处理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            //回车
            if (Properties.DataView.Count > 0 && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return))
            {
                //当前行
                DataRowView rowView = Properties.DataView[Properties.GridView.FocusedRowHandle];
                //触发选中行事件
                OnSelectedRowChanged(rowView.Row);
            }
            //上箭头
            else if (e.KeyCode == Keys.Up)
            {
                //展开
                IfExpand();
                Properties.GridView.FocusedRowHandle -= 1;
            }
            //下箭头
            else if (e.KeyCode == Keys.Down)
            {
                //展开
                IfExpand();
                Properties.GridView.FocusedRowHandle += 1;
            }
            //取消
            else if (e.KeyCode == Keys.Escape && IsPopupOpen)
            {
                ClosePopup(DevExpress.XtraEditors.PopupCloseMode.Cancel);
            }
            else//其他键传递自行处理
            {
                base.OnKeyDown(e);
                return;
            }

            //标记事件已处理
            e.Handled = true;
            base.OnKeyDown(e);
        }

        /// <summary>
        /// 鼠标滚轮事件处理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                //展开
                IfExpand();
                Properties.GridView.FocusedRowHandle -= 1;
            }
            else
            {
                //展开
                IfExpand();
                Properties.GridView.FocusedRowHandle += 1;
            }

            base.OnMouseWheel(e);
        }

        /// <summary>
        /// 根据属性决定是否展开列表
        /// </summary>
        private void IfExpand()
        {
            if (this.Site != null && this.Site.DesignMode)
            {

            }
            else
            {
                //展开
                if (IsExpandOnEdit && !this.IsPopupOpen)
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        this.ShowPopup();
                    }));
                }
            }
        }

        /// <summary>
        /// 对数据源应用筛选
        /// </summary>
        protected virtual void ApplyFilter()
        {
            StringBuilder filterBuilder = new StringBuilder();
            string strFilteTemplate = "[{0}] LIKE '%{1}%' OR ";
            string strFilteText = GetFilterString();

            foreach (DataColumn column in DataSource.Columns)
            {
                filterBuilder.AppendFormat(strFilteTemplate, column.ColumnName, strFilteText);
            }

            filterBuilder.Remove(filterBuilder.Length - 3, 3);
            Properties.DataView.RowFilter = filterBuilder.ToString();
        }

        /// <summary>
        /// 获取筛选字符串
        /// </summary>
        /// <returns></returns>
        protected virtual string GetFilterString()
        {
            StringBuilder result = new StringBuilder(Text);
            result.Replace("[", "[[ ")
                  .Replace("]", " ]]")
                  .Replace("*", "[*]")
                  .Replace("%", "[%]")
                  .Replace("[[ ", "[[]")
                  .Replace(" ]]", "[]]")
                  .Replace("\'", "''");

            return result.ToString();
        }

        #endregion
    }
}
