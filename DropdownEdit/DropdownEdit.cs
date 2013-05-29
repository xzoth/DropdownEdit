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
    public class DropdownEdit : PopupContainerEdit
    {
        private readonly object eventLock = new object();

        private SelectedRowChangeHandler selectedRowChangeHandler;
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

        #region Member

        /// <summary>
        /// 文本改变事件自复位开关
        /// 设置此复位开关的目的是为了拦截基类及其他方法触发的“不在期望内”的文本改变事件
        /// </summary>
        protected bool AutoResetControl = false;
        /// <summary>
        /// 类型名
        /// </summary>
        public const string CONST_TYPE_NAME = "DropdownEdit";

        #endregion

        #region Property

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
            //[MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.Properties.DataSource = value;
            }
        }

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
        [Description("获取或者设置是否在匹配到项时自动展开下拉列表")]
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
            private set
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
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemDropdownEdit Properties
        {
            get
            {
                return this.properties == null ? base.Properties as RepositoryItemDropdownEdit : this.properties;

            }
            set
            {
                this.properties = value;
            }
        }

        #endregion

        #region Method

        static DropdownEdit()
        {
            RepositoryItemDropdownEdit.RegisterDropdownEdit();
        }

        public DropdownEdit()
        {
        }

        public virtual void Expand()
        {
            this.ShowPopup();
            this.Focus();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            //展开
            IfExpand();

            if (IsApplyRowFilter)
            {
                ApplyFilter();
            }

            base.OnTextChanged(e);
        }

        public string DisplayMember
        {
            get;
            set;
        }

        internal protected void OnSelectedRowChanged(DataRow row)
        {
            string strText = row[DisplayMember].ToString();
            Text = strText;

            SelectedRowChangeEventArg changeEventArg = new SelectedRowChangeEventArg() { SelectedRow = row };
            if (selectedRowChangeHandler != null)
            {
                selectedRowChangeHandler(this, changeEventArg);
            }

            this.ClosePopup();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //回车
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                //当前行
                DataRowView rowView = Properties.DataView[Properties.GridView.FocusedRowHandle];
                //触发选中行事件
                OnSelectedRowChanged(rowView.Row);
            }

            //上箭头
            if (e.KeyCode == Keys.Up)
            {
                //展开
                IfExpand();
                Properties.GridView.FocusedRowHandle -= 1;
            }
            //下箭头
            if (e.KeyCode == Keys.Down)
            {
                //展开
                IfExpand();
                Properties.GridView.FocusedRowHandle += 1;
            }

            base.OnKeyDown(e);
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
                        this.Expand();
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
