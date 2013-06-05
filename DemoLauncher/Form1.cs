using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DropdownEdit;

namespace DemoLauncher
{
    public partial class Form1 : Form
    {
        DropdownEdit.DropdownEdit dropdownEdit2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dropdownEdit1.IsExpandOnEdit = chkIsExpandOnEdit.Checked;
            dropdownEdit1.IsApplyRowFilter = chkIsApplyRowFilter.Checked;
            dropdownEdit1.IsAutoSelect = chkIsAutoSelect.Checked;
            dropdownEdit1.IsHighlightKeyword = chkIsHighlightKeyword.Checked;

            int width = Convert.ToInt32(txtDropdownWidth.Text.Trim());
            dropdownEdit1.DropdownWidth = width;
            int height = Convert.ToInt32(txtDropdownHeight.Text.Trim());
            dropdownEdit1.DropdownHeight = height;

            foreach (DataColumn col in MockData.Columns)
            {
                cmbDisplayMember.Items.Add(col.ColumnName);
            }
            cmbDisplayMember.SelectedIndex = 0;

            dropdownEdit1.DisplayMember = cmbDisplayMember.Text;
            dropdownEdit1.DataSource = MockData;
            dropdownEdit1.Focus();
        }

        private DataTable mockData = null;
        public DataTable MockData
        {
            get
            {
                if (mockData == null)
                {
                    mockData = new DataTable("MockData");

                    mockData.Columns.Add(new DataColumn("ColunmOne"));
                    mockData.Columns.Add(new DataColumn("ColunmTwo"));
                    mockData.Columns.Add(new DataColumn("ColunmThree"));

                    var row1 = mockData.NewRow();
                    row1["ColunmOne"] = "很长很长很长的中文";
                    row1["ColunmTwo"] = "contain";
                    row1["ColunmThree"] = "Colunm's";
                    mockData.Rows.Add(row1);

                    var row2 = mockData.NewRow();
                    row2["ColunmOne"] = "81";
                    row2["ColunmTwo"] = "中山";
                    row2["ColunmThree"] = "Windows8";
                    mockData.Rows.Add(row2);

                    var row3 = mockData.NewRow();
                    row3["ColunmOne"] = "山泉水";
                    row3["ColunmTwo"] = "8";
                    row3["ColunmThree"] = "window";
                    mockData.Rows.Add(row3);
                }

                return mockData;
            }
        }

        private void chkIsExpandOnEdit_CheckedChanged(object sender, EventArgs e)
        {
            dropdownEdit1.IsExpandOnEdit = chkIsExpandOnEdit.Checked;
        }

        private void dropdownEdit1_SelectedRowChange(object sender, DropdownEdit.SelectedRowChangeEventArg e)
        {
            StringBuilder returnValue = new StringBuilder();

            var table = e.SelectedRow.Table;
            foreach (DataColumn column in table.Columns)
            {
                returnValue.AppendFormat("{0}: {1}\r\n",
                                         column.ColumnName,
                                         e.SelectedRow[column.ColumnName].ToString());
            }
            txtSelectedValue.Text = returnValue.ToString();
        }

        private void chkIsApplyRowFilter_CheckedChanged(object sender, EventArgs e)
        {
            dropdownEdit1.IsApplyRowFilter = chkIsApplyRowFilter.Checked;
        }

        private void chkIsAutoSelect_CheckedChanged(object sender, EventArgs e)
        {
            dropdownEdit1.IsAutoSelect = chkIsAutoSelect.Checked;
        }

        private void chkIsHighlightKeyword_CheckedChanged(object sender, EventArgs e)
        {
            dropdownEdit1.IsHighlightKeyword = chkIsHighlightKeyword.Checked;
        }

        private void txtDropdownWidth_TextChanged(object sender, EventArgs e)
        {
            int width = Convert.ToInt32(txtDropdownWidth.Text.Trim());
            dropdownEdit1.DropdownWidth = width;
        }

        private void txtDropdownHeight_TextChanged(object sender, EventArgs e)
        {
            int height = Convert.ToInt32(txtDropdownHeight.Text.Trim());
            dropdownEdit1.DropdownHeight = height;
        }

        private void cmbDisplayMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropdownEdit1.DisplayMember = cmbDisplayMember.Text;
        }

        private void dropdownEdit3_TextChanged(object sender, EventArgs e)
        {
            string strText = dropdownEdit3.Text;
            if (!string.IsNullOrWhiteSpace(strText))
            {
                //string strFilter = string.Format("", strText);
                //dropdownEdit3.DataSource = MockData.Select(strFilter);
                dropdownEdit3.DataSource = MockData;
            }
        }
    }
}
