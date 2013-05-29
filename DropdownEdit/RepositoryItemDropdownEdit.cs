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
            this.popupContainerControl = new PopupContainerControl();
            this.gridControl = new GridControl();
            this.gridView = new GridView();

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
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.OptionsBehavior.Editable = false;

            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsCustomization.AllowSort = false;
            this.gridView.OptionsView.AnimationType = GridAnimationType.AnimateAllContent;
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
        [XmlIgnore, Browsable(true)]
        [Category("数据"), Description("数据源")]
        internal protected DataTable DataSource
        {
            get
            {
                return this.gridControl.DataSource as DataTable;
            }
            set
            {
                if (value != null)
                {
                    if (value.Rows.Count > 1000)
                    {
                        throw new OverflowException("数据源过大，超过1000条。");
                    }

                    this.gridControl.DataSource = value.DefaultView;
                }
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
            //TODO: init dropdownEdit

            return dropdownEdit;
        }

        private GridControl gridControl;
        private GridView gridView;
        private PopupContainerControl popupContainerControl;
    }
}
