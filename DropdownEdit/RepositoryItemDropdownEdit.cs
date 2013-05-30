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
    [UserRepositoryItem("RegisterDropdownEdit")]
    public class RepositoryItemDropdownEdit : RepositoryItemPopupContainerEdit
    {
        static RepositoryItemDropdownEdit()
        {
            RepositoryItemDropdownEdit.RegisterDropdownEdit();
        }

        public static void RegisterDropdownEdit()
        {
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
            this.gridControl.ProcessGridKey += gridControl_ProcessGridKey;
            this.gridView.RowClick += gridView_RowClick;
            this.gridView.MouseWheel += gridView_MouseWheel;

            this.PopupControl = this.popupContainerControl;
            this.AppearanceDisabled.Options.UseBackColor = true;

            this.popupContainerControl.Controls.Add(this.gridControl);
            this.popupContainerControl.Location = new Point(0, 0);
            this.popupContainerControl.Size = new Size(DropdownWidth, DropdownHeight);

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

        void gridView_RowClick(object sender, RowClickEventArgs e)
        {
            if (DataView.Count > 0)
            {
                RaiseSelectedRowChanged();
            }
        }

        void gridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (DataView.Count > 0 && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return))
            {
                RaiseSelectedRowChanged();
            }
            else//传递到OwnerEdit
            {

            }
        }

        private void RaiseSelectedRowChanged()
        {
            DropdownEdit editor = OwnerEdit as DropdownEdit;

            DataRow row = DataView[GridView.FocusedRowHandle].Row;
            editor.OnSelectedRowChanged(row);
        }

        [ReadOnly(true)]
        public GridView GridView
        {
            get
            {
                return this.gridView;
            }
        }

        [ReadOnly(true)]
        public GridControl GridControl
        {
            get
            {
                return this.gridControl;
            }
        }

        private int dropdownHeight = 200;
        [DefaultValue(200)]
        public int DropdownHeight
        {
            get
            {
                return dropdownHeight;
            }
            set
            {
                dropdownHeight = value;
            }
        }

        private int dropdownWidth = 300;
        [DefaultValue(300)]
        public int DropdownWidth
        {
            get
            {
                return dropdownWidth;
            }
            set
            {
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
        [XmlIgnore, Browsable(true)]
        public DataTable DataSource
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
        private DataView dataView = null;
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

        private TextEditStyles textEditStyle = TextEditStyles.Standard;
        [Browsable(false), DefaultValue(TextEditStyles.Standard)]
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

        [ReadOnly(true)]
        public override string EditorTypeName
        {
            get
            {
                return DropdownEdit.CONST_TYPE_NAME;
            }
        }

        public override BaseEdit CreateEditor()
        {
            DropdownEdit dropdownEdit = base.CreateEditor() as DropdownEdit;
            dropdownEdit.Properties = this;

            return dropdownEdit;
        }

        private GridControl gridControl = new GridControl();
        private GridView gridView = new GridView();
        private PopupContainerControl popupContainerControl = new PopupContainerControl();
    }
}
