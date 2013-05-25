using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DropdownEdit
{
    public class DropdownEdit : PopupContainerEdit
    {
        /// <summary>
        /// 文本改变事件自复位开关
        /// 设置此复位开关的目的是为了拦截基类及其他方法触发的“不在期望内”的文本改变事件
        /// </summary>
        protected bool AutoResetControl = false;

        static DropdownEdit()
        {
            RepositoryItemDropdownEdit.RegisterDropdownEdit();
        }

        public DropdownEdit()
        {
            
        }
        
        private RepositoryItemDropdownEdit properties = new RepositoryItemDropdownEdit();
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

        public override string EditorTypeName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return RepositoryItemDropdownEdit.DropdownEditName;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }

        protected override void OnEditorEnter(EventArgs e)
        {
            base.OnEditorEnter(e);
        }

        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
        }

    }
}
