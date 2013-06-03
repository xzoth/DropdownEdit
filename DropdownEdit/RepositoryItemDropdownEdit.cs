using DevExpress.Accessibility;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DropdownEdit
{
    /// <summary>
    /// 下拉选择控件库项
    /// </summary>
    [UserRepositoryItem("RegisterDropdownEdit")]
    public class RepositoryItemDropdownEdit : RepositoryItemPopupContainerEdit
    {
        #region Member

        private GridControl gridControl = new GridControl();
        private GridView gridView = new GridView();
        private PopupContainerControl popupContainerControl = new PopupContainerControl();

        #endregion

        #region Property

        /// <summary>
        /// 表格视图
        /// </summary>
        [ReadOnly(true)]
        public GridView GridView
        {
            get
            {
                return this.gridView;
            }
        }

        /// <summary>
        /// 表格控件
        /// </summary>
        [ReadOnly(true)]
        public GridControl GridControl
        {
            get
            {
                return this.gridControl;
            }
        }

        /// <summary>
        /// 获取或者设置下拉框高度
        /// </summary>
        private int dropdownHeight = 200;
        /// <summary>
        /// 获取或者设置下拉框高度
        /// </summary>
        [DefaultValue(200), Browsable(true), Category("外观"), Description("获取或者设置下拉框高度")]
        public int DropdownHeight
        {
            get
            {
                return dropdownHeight;
            }
            set
            {
                this.popupContainerControl.Height = value;
                dropdownHeight = value;
            }
        }

        /// <summary>
        /// 获取或者设置下拉框宽度
        /// </summary>
        private int dropdownWidth = 300;
        /// <summary>
        /// 获取或者设置下拉框宽度
        /// </summary>
        [DefaultValue(300), Browsable(true), Category("外观"), Description("获取或者设置下拉框宽度")]
        public int DropdownWidth
        {
            get
            {
                return dropdownWidth;
            }
            set
            {
                this.popupContainerControl.Width = value;
                dropdownWidth = value;
            }
        }

        /// <summary>
        /// 获取或设置绑定的数据源
        /// </summary>
        [NonSerialized, XmlIgnore]
        private DataTable dataSource = null;
        /// <summary>
        /// 获取或设置绑定的数据源
        /// </summary>
        [XmlIgnore, Browsable(false)]
        internal protected DataTable DataSource
        {
            get
            {
                return dataSource;
            }
            set
            {
                if (value != null)
                {
                    if (value.Rows.Count > 1000)
                    {
                        throw new OverflowException("数据源过大，超过1000条。");
                    }

                    dataSource = value;
                    this.gridControl.DataSource = dataView = new DataView(dataSource);
                }
            }
        }

        /// <summary>
        /// 获取或者设置行筛选表达式
        /// </summary>
        [XmlIgnore]
        [Browsable(false)]
        public virtual string RowFilter
        {
            get
            {
                return DataView.RowFilter;
            }
            set
            {
                DataView.RowFilter = value;
            }
        }

        /// <summary>
        /// 数据源视图
        /// </summary>
        [NonSerialized, XmlIgnore]
        private DataView dataView = new DataView();
        /// <summary>
        /// 数据源视图
        /// </summary>
        [XmlIgnore]
        [Browsable(false)]
        internal protected virtual DataView DataView
        {
            get
            {
                if (dataView == null && DataSource != null)
                {
                    dataView = new DataView(DataSource);
                }

                return dataView;
            }
        }

        /// <summary>
        /// 获取或者设置编辑器编辑框样式
        /// </summary>
        private TextEditStyles textEditStyle = TextEditStyles.Standard;
        /// <summary>
        /// 获取或者设置编辑器编辑框样式
        /// </summary>
        [Browsable(true), Category("外观"), Description("获取或者设置编辑器编辑框样式"), DefaultValue(TextEditStyles.Standard)]
        public override TextEditStyles TextEditStyle
        {
            get
            {
                return textEditStyle;
            }
            set
            {
                textEditStyle = value;
            }
        }

        /// <summary>
        /// 编辑器类型名
        /// </summary>
        [ReadOnly(true)]
        public override string EditorTypeName
        {
            get
            {
                return DropdownEdit.CONST_TYPE_NAME;
            }
        }

        #endregion

        #region Method

        public override BaseEdit CreateEditor()
        {
            DropdownEdit dropdownEdit = base.CreateEditor() as DropdownEdit;
            dropdownEdit.Properties = this;

            return dropdownEdit;
        }

        static RepositoryItemDropdownEdit()
        {
            RepositoryItemDropdownEdit.RegisterDropdownEdit();
        }

        public static void RegisterDropdownEdit()
        {
            if (EditorRegistrationInfo.Default.Editors.Contains(DropdownEdit.CONST_TYPE_NAME))
            {
                return;
            }

            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(DropdownEdit.CONST_TYPE_NAME,
                                                       typeof(DropdownEdit),
                                                       typeof(RepositoryItemDropdownEdit),
                                                       typeof(PopupContainerEditViewInfo),
                                                       new ButtonEditPainter(),
                                                       true,
                                                       img,
                                                       typeof(PopupEditAccessible)));
        }

        public RepositoryItemDropdownEdit()
        {
            this.gridControl.ProcessGridKey += new KeyEventHandler(this.gridControl_ProcessGridKey);
            this.gridView.RowClick += new RowClickEventHandler(this.gridView_RowClick);
            this.gridView.MouseWheel += new MouseEventHandler(this.gridView_MouseWheel);

            this.PopupControl = this.popupContainerControl;
            this.AppearanceDisabled.Options.UseBackColor = true;
            this.popupContainerControl.Controls.Add(this.gridControl);
            this.popupContainerControl.Location = new Point(0, 0);
            this.popupContainerControl.Size = new Size(this.DropdownWidth, this.DropdownHeight);

            this.gridControl.MainView = this.gridView;
            this.gridControl.Dock = DockStyle.Fill;
            this.gridControl.ViewCollection.AddRange(new BaseView[] { this.gridView });

            this.gridView.GridControl = this.gridControl;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = true;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsCustomization.AllowSort = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
        }

        /// <summary>
        /// 鼠标滚轮事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gridView_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                GridView.FocusedRowHandle -= 1;
            }
            else
            {
                GridView.FocusedRowHandle += 1;
            }
        }

        /// <summary>
        /// 行点击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gridView_RowClick(object sender, RowClickEventArgs e)
        {
            if (DataView.Count > 0)
            {
                RaiseSelectedRowChanged();
            }
        }

        /// <summary>
        /// 键盘击键事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (DataView.Count > 0 && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return))
            {
                RaiseSelectedRowChanged();
            }
            else//如果是其他键，则传递到OwnerEdit
            {
                OwnerEdit.Focus();
                OwnerEdit.SelectionStart = OwnerEdit.Text.Length;
                //OwnerEdit.SelectionStart = 0;
                //OwnerEdit.SelectionLength = OwnerEdit.Text.Length;
            }
        }

        /// <summary>
        /// 触发行选择变更事件
        /// </summary>
        private void RaiseSelectedRowChanged()
        {
            DropdownEdit editor = OwnerEdit as DropdownEdit;

            DataRow row = DataView[GridView.FocusedRowHandle].Row;
            editor.OnSelectedRowChanged(row);
        }

        #endregion        
    }
}
