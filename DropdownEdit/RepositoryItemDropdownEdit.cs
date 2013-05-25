using DevExpress.Accessibility;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropdownEdit
{
    [UserRepositoryItem("RegisterPopTextEdit")]
    public class RepositoryItemDropdownEdit : RepositoryItemPopupContainerEdit
    {
        static RepositoryItemDropdownEdit()
        {
            RepositoryItemDropdownEdit.RegisterDropdownEdit();
        }

        public const string DropdownEditName = "DropdownEdit";
        public static void RegisterDropdownEdit()
        {
            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(DropdownEditName,
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
            this.AppearanceDisabled.Options.UseBackColor = false;

            this.TextEditStyle = TextEditStyles.Standard;
            this.PopupControl = this.popupContainerControl;

            //Init PopupContainerControl
            this.popupContainerControl.Location = new Point(200, 0);
            this.popupContainerControl.Size = new Size(300, 260);

            this.popupContainerControl.Controls.Add(this.gridControl);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Dock = DockStyle.Fill;

            this.gridControl.ViewCollection.AddRange(new BaseView[]{ this.gridView });
            this.gridView.GridControl = this.gridControl;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = true;
            this.gridView.OptionsBehavior.Editable = false;
        }

        [Browsable(false)]
        public override TextEditStyles TextEditStyle
        {
            get
            {
                return TextEditStyles.Standard;
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
