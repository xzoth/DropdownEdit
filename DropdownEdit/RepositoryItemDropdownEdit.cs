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
    [UserRepositoryItem("RegisterPopTextEdit")]
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

            //EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(DropdownEdit.CONST_TYPE_NAME, typeof(DropdownEdit), typeof(RepositoryItemDropdownEdit), typeof(PopupContainerEditViewInfo), (BaseEditPainter)new ButtonEditPainter(), true));

        }

        public RepositoryItemDropdownEdit()
        {
            //RichTextBox rtb = new RichTextBox();
            //rtb.Dock = DockStyle.Fill;
            //PopupContainerControl popupControl = new PopupContainerControl();
            //popupControl.Controls.Add(rtb);

            //this.PopupControl = popupControl;

            this.popupContainerControl = new PopupContainerControl();
            this.gridControl = new GridControl();
            this.gridView = new GridView();
            this.PopupControl = this.popupContainerControl;
            this.AppearanceDisabled.Options.UseBackColor = true;
            this.TextEditStyle = TextEditStyles.Standard;
            this.popupContainerControl.Controls.Add((Control)this.gridControl);
            this.popupContainerControl.Location = new Point(200, 3);
            this.popupContainerControl.Size = new Size(400, 200);
            this.gridControl.MainView = (BaseView)this.gridView;
            this.gridControl.Dock = DockStyle.Fill;
      //      this.gridControl.ViewCollection.AddRange(new BaseView[1]
      //{
      //  (BaseView) this.gridView
      //});
      //      this.gridView.GridControl = this.gridControl;
      //      this.gridView.OptionsView.ShowGroupPanel = false;
      //      this.gridView.OptionsView.ShowIndicator = false;
      //      this.gridView.OptionsBehavior.Editable = false;

            this.gridView.Columns.Add(new GridColumn()
            {
                FieldName = "aa",
                Caption = "aa"
            });
            this.gridView.Columns.Add(new GridColumn()
            {
                FieldName = "bb",
                Caption = "bb"
            });
            this.gridView.Columns.Add(new GridColumn()
            {
                FieldName = "cc",
                Caption = "cc"
            });

            //this.AppearanceDisabled.Options.UseBackColor = true;

            //this.TextEditStyle = TextEditStyles.Standard;
            //this.PopupControl = this.popupContainerControl;

            ////Init PopupContainerControl
            //this.popupContainerControl.Location = new Point(200, 0);
            //this.popupContainerControl.Size = new Size(300, 260);

            //this.popupContainerControl.Controls.Add(this.gridControl);
            //this.gridControl.MainView = this.gridView;
            //this.gridControl.Dock = DockStyle.Fill;

            //this.gridControl.ViewCollection.AddRange(new BaseView[1] { this.gridView });
            //this.gridView.GridControl = this.gridControl;
            //this.gridView.OptionsView.ShowGroupPanel = false;
            //this.gridView.OptionsView.ShowIndicator = true;
            //this.gridView.OptionsBehavior.Editable = false;
        }

        /// <summary>
        /// 获取或设置绑定的数据源
        /// </summary>
        [XmlIgnore, Browsable(true)]
        internal protected virtual DataTable DataSource
        {
            get
            {
                return this.gridControl.DataSource as DataTable;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (value != null)
                {
                    if (value.Rows.Count > 1000)
                    {
                        throw new OverflowException("数据源过大，超过1000条。");
                    }

                    this.gridControl.DataSource = value;
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

        public override BaseEdit CreateEditor()
        {
            DropdownEdit dropdownEdit = base.CreateEditor() as DropdownEdit;
            dropdownEdit.Properties = this;
            //TODO: init dropdownEdit

            return dropdownEdit;
        }

        private GridControl gridControl = new GridControl();
        private GridView gridView = new GridView();
        private PopupContainerControl popupContainerControl = new PopupContainerControl();
    }
}
