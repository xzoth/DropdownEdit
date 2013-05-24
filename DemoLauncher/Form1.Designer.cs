namespace DemoLauncher
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dropdownEdit1 = new DropdownEdit.DropdownEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dropdownEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dropdownEdit1
            // 
            this.dropdownEdit1.Location = new System.Drawing.Point(143, 34);
            this.dropdownEdit1.Name = "dropdownEdit1";
            this.dropdownEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dropdownEdit1.Size = new System.Drawing.Size(214, 20);
            this.dropdownEdit1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 350);
            this.Controls.Add(this.dropdownEdit1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dropdownEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DropdownEdit.DropdownEdit dropdownEdit1;

    }
}

