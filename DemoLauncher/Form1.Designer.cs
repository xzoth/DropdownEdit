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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkIsExpandOnEdit = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dropdownEdit1 = new DropdownEdit.DropdownEdit();
            this.txtSelectedValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dropdownEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.chkIsExpandOnEdit);
            this.groupBox1.Location = new System.Drawing.Point(363, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 326);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Propertys";
            // 
            // chkIsExpandOnEdit
            // 
            this.chkIsExpandOnEdit.AutoSize = true;
            this.chkIsExpandOnEdit.Checked = true;
            this.chkIsExpandOnEdit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsExpandOnEdit.Location = new System.Drawing.Point(22, 29);
            this.chkIsExpandOnEdit.Name = "chkIsExpandOnEdit";
            this.chkIsExpandOnEdit.Size = new System.Drawing.Size(108, 16);
            this.chkIsExpandOnEdit.TabIndex = 0;
            this.chkIsExpandOnEdit.Text = "IsExpandOnEdit";
            this.chkIsExpandOnEdit.UseVisualStyleBackColor = true;
            this.chkIsExpandOnEdit.CheckedChanged += new System.EventHandler(this.chkIsExpandOnEdit_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Static DataBind";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dynamic DataBind";
            this.label2.Visible = false;
            // 
            // dropdownEdit1
            // 
            this.dropdownEdit1.DataSource = null;
            this.dropdownEdit1.DisplayMember = null;
            this.dropdownEdit1.DropdownHeight = 200;
            this.dropdownEdit1.DropdownWidth = 300;
            this.dropdownEdit1.Location = new System.Drawing.Point(47, 60);
            this.dropdownEdit1.Name = "dropdownEdit1";
            this.dropdownEdit1.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.dropdownEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dropdownEdit1.Properties.DataSource = null;
            this.dropdownEdit1.Size = new System.Drawing.Size(240, 20);
            this.dropdownEdit1.TabIndex = 0;
            this.dropdownEdit1.SelectedRowChange += new DropdownEdit.SelectedRowChangeHandler(this.dropdownEdit1_SelectedRowChange);
            // 
            // txtSelectedValue
            // 
            this.txtSelectedValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedValue.Location = new System.Drawing.Point(12, 207);
            this.txtSelectedValue.Multiline = true;
            this.txtSelectedValue.Name = "txtSelectedValue";
            this.txtSelectedValue.Size = new System.Drawing.Size(345, 131);
            this.txtSelectedValue.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Selected Value";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 350);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSelectedValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dropdownEdit1);
            this.Name = "Form1";
            this.Text = "DemoLauncher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dropdownEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DropdownEdit.DropdownEdit dropdownEdit1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkIsExpandOnEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSelectedValue;
        private System.Windows.Forms.Label label3;

    }
}

