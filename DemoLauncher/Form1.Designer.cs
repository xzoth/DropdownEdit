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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dropdownEdit3 = new DropdownEdit.DropdownEdit();
            this.dropdownEdit1 = new DropdownEdit.DropdownEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSelectedValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDisplayMember = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTextEditStyles = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbKeyWordMatchMode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDropdownHeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDropdownWidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIsHighlightKeyword = new System.Windows.Forms.CheckBox();
            this.chkIsApplyRowFilter = new System.Windows.Forms.CheckBox();
            this.chkIsAutoSelect = new System.Windows.Forms.CheckBox();
            this.chkIsExpandOnEdit = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDropdownEdit2 = new DropdownEdit.RepositoryItemDropdownEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dropdownEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropdownEdit1.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDropdownEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(655, 366);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dropdownEdit3);
            this.tabPage1.Controls.Add(this.dropdownEdit1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtSelectedValue);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(647, 340);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DropdownEdit";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dropdownEdit3
            // 
            this.dropdownEdit3.DataSource = null;
            this.dropdownEdit3.EditValue = "";
            this.dropdownEdit3.Location = new System.Drawing.Point(38, 122);
            this.dropdownEdit3.Name = "dropdownEdit3";
            this.dropdownEdit3.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.dropdownEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dropdownEdit3.Properties.RowFilter = "";
            this.dropdownEdit3.Size = new System.Drawing.Size(260, 20);
            this.dropdownEdit3.TabIndex = 12;
            this.dropdownEdit3.TextChanged += new System.EventHandler(this.dropdownEdit3_TextChanged);
            // 
            // dropdownEdit1
            // 
            this.dropdownEdit1.DataSource = null;
            this.dropdownEdit1.DisplayMember = null;
            this.dropdownEdit1.EditValue = "";
            this.dropdownEdit1.Location = new System.Drawing.Point(38, 54);
            this.dropdownEdit1.Name = "dropdownEdit1";
            this.dropdownEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dropdownEdit1.Properties.RowFilter = "";
            this.dropdownEdit1.Size = new System.Drawing.Size(260, 20);
            this.dropdownEdit1.TabIndex = 11;
            this.dropdownEdit1.SelectedRowChange += new DropdownEdit.SelectedRowChangeHandler(this.dropdownEdit1_SelectedRowChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "Static DataBind";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Dynamic DataBind";
            // 
            // txtSelectedValue
            // 
            this.txtSelectedValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedValue.Location = new System.Drawing.Point(12, 202);
            this.txtSelectedValue.Multiline = true;
            this.txtSelectedValue.Name = "txtSelectedValue";
            this.txtSelectedValue.Size = new System.Drawing.Size(345, 131);
            this.txtSelectedValue.TabIndex = 6;
            this.txtSelectedValue.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "Selected Value";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmbDisplayMember);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbTextEditStyles);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbKeyWordMatchMode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDropdownHeight);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDropdownWidth);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chkIsHighlightKeyword);
            this.groupBox1.Controls.Add(this.chkIsApplyRowFilter);
            this.groupBox1.Controls.Add(this.chkIsAutoSelect);
            this.groupBox1.Controls.Add(this.chkIsExpandOnEdit);
            this.groupBox1.Location = new System.Drawing.Point(363, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 326);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Propertys";
            // 
            // cmbDisplayMember
            // 
            this.cmbDisplayMember.FormattingEnabled = true;
            this.cmbDisplayMember.Location = new System.Drawing.Point(144, 240);
            this.cmbDisplayMember.Name = "cmbDisplayMember";
            this.cmbDisplayMember.Size = new System.Drawing.Size(100, 20);
            this.cmbDisplayMember.TabIndex = 13;
            this.cmbDisplayMember.SelectedIndexChanged += new System.EventHandler(this.cmbDisplayMember_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "DisplayMember";
            // 
            // cmbTextEditStyles
            // 
            this.cmbTextEditStyles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTextEditStyles.FormattingEnabled = true;
            this.cmbTextEditStyles.Location = new System.Drawing.Point(144, 208);
            this.cmbTextEditStyles.Name = "cmbTextEditStyles";
            this.cmbTextEditStyles.Size = new System.Drawing.Size(100, 20);
            this.cmbTextEditStyles.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "TextEditStyles";
            // 
            // cmbKeyWordMatchMode
            // 
            this.cmbKeyWordMatchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKeyWordMatchMode.FormattingEnabled = true;
            this.cmbKeyWordMatchMode.Location = new System.Drawing.Point(144, 177);
            this.cmbKeyWordMatchMode.Name = "cmbKeyWordMatchMode";
            this.cmbKeyWordMatchMode.Size = new System.Drawing.Size(100, 20);
            this.cmbKeyWordMatchMode.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "KeyWordMatchMode";
            // 
            // txtDropdownHeight
            // 
            this.txtDropdownHeight.Location = new System.Drawing.Point(144, 149);
            this.txtDropdownHeight.Name = "txtDropdownHeight";
            this.txtDropdownHeight.Size = new System.Drawing.Size(100, 21);
            this.txtDropdownHeight.TabIndex = 7;
            this.txtDropdownHeight.Text = "200";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "DropdownHeight";
            // 
            // txtDropdownWidth
            // 
            this.txtDropdownWidth.Location = new System.Drawing.Point(144, 121);
            this.txtDropdownWidth.Name = "txtDropdownWidth";
            this.txtDropdownWidth.Size = new System.Drawing.Size(100, 21);
            this.txtDropdownWidth.TabIndex = 5;
            this.txtDropdownWidth.Text = "500";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "DropdownWidth";
            // 
            // chkIsHighlightKeyword
            // 
            this.chkIsHighlightKeyword.AutoSize = true;
            this.chkIsHighlightKeyword.Enabled = false;
            this.chkIsHighlightKeyword.Location = new System.Drawing.Point(21, 90);
            this.chkIsHighlightKeyword.Name = "chkIsHighlightKeyword";
            this.chkIsHighlightKeyword.Size = new System.Drawing.Size(132, 16);
            this.chkIsHighlightKeyword.TabIndex = 3;
            this.chkIsHighlightKeyword.Text = "IsHighlightKeyword";
            this.chkIsHighlightKeyword.UseVisualStyleBackColor = true;
            this.chkIsHighlightKeyword.CheckedChanged += new System.EventHandler(this.chkIsHighlightKeyword_CheckedChanged);
            // 
            // chkIsApplyRowFilter
            // 
            this.chkIsApplyRowFilter.AutoSize = true;
            this.chkIsApplyRowFilter.Checked = true;
            this.chkIsApplyRowFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsApplyRowFilter.Location = new System.Drawing.Point(21, 66);
            this.chkIsApplyRowFilter.Name = "chkIsApplyRowFilter";
            this.chkIsApplyRowFilter.Size = new System.Drawing.Size(120, 16);
            this.chkIsApplyRowFilter.TabIndex = 2;
            this.chkIsApplyRowFilter.Text = "IsApplyRowFilter";
            this.chkIsApplyRowFilter.UseVisualStyleBackColor = true;
            this.chkIsApplyRowFilter.CheckedChanged += new System.EventHandler(this.chkIsApplyRowFilter_CheckedChanged);
            // 
            // chkIsAutoSelect
            // 
            this.chkIsAutoSelect.AutoSize = true;
            this.chkIsAutoSelect.Enabled = false;
            this.chkIsAutoSelect.Location = new System.Drawing.Point(21, 44);
            this.chkIsAutoSelect.Name = "chkIsAutoSelect";
            this.chkIsAutoSelect.Size = new System.Drawing.Size(96, 16);
            this.chkIsAutoSelect.TabIndex = 1;
            this.chkIsAutoSelect.Text = "IsAutoSelect";
            this.chkIsAutoSelect.UseVisualStyleBackColor = true;
            this.chkIsAutoSelect.CheckedChanged += new System.EventHandler(this.chkIsAutoSelect_CheckedChanged);
            // 
            // chkIsExpandOnEdit
            // 
            this.chkIsExpandOnEdit.AutoSize = true;
            this.chkIsExpandOnEdit.Checked = true;
            this.chkIsExpandOnEdit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsExpandOnEdit.Location = new System.Drawing.Point(21, 22);
            this.chkIsExpandOnEdit.Name = "chkIsExpandOnEdit";
            this.chkIsExpandOnEdit.Size = new System.Drawing.Size(108, 16);
            this.chkIsExpandOnEdit.TabIndex = 0;
            this.chkIsExpandOnEdit.Text = "IsExpandOnEdit";
            this.chkIsExpandOnEdit.UseVisualStyleBackColor = true;
            this.chkIsExpandOnEdit.CheckedChanged += new System.EventHandler(this.chkIsExpandOnEdit_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(647, 340);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "In Place";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(6, 6);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDropdownEdit2});
            this.gridControl1.Size = new System.Drawing.Size(635, 328);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.ColumnEdit = this.repositoryItemDropdownEdit2;
            this.gridColumn1.FieldName = "ColunmOne";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // repositoryItemDropdownEdit2
            // 
            this.repositoryItemDropdownEdit2.AppearanceDisabled.Options.UseBackColor = true;
            this.repositoryItemDropdownEdit2.AutoHeight = false;
            this.repositoryItemDropdownEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDropdownEdit2.Name = "repositoryItemDropdownEdit2";
            this.repositoryItemDropdownEdit2.RowFilter = "";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "ColunmTwo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "gridColumn3";
            this.gridColumn3.FieldName = "ColunmThree";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 390);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "DemoLauncher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dropdownEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropdownEdit1.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDropdownEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DropdownEdit.DropdownEdit dropdownEdit1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSelectedValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTextEditStyles;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbKeyWordMatchMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDropdownHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDropdownWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsHighlightKeyword;
        private System.Windows.Forms.CheckBox chkIsApplyRowFilter;
        private System.Windows.Forms.CheckBox chkIsAutoSelect;
        private System.Windows.Forms.CheckBox chkIsExpandOnEdit;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDisplayMember;
        private DropdownEdit.DropdownEdit dropdownEdit3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DropdownEdit.RepositoryItemDropdownEdit repositoryItemDropdownEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;


    }
}

