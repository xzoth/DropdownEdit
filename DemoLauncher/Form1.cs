using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dropdownEdit1.IsExpandOnEdit = chkIsExpandOnEdit.Checked;

            
            gridControl1.DataSource = MockData;

            dropdownEdit1.DataSource = MockData;
        }

        private void chkIsExpandOnEdit_CheckedChanged(object sender, EventArgs e)
        {
            dropdownEdit1.IsExpandOnEdit = chkIsExpandOnEdit.Checked;
        }

        private DataTable mockData = null;
        public DataTable MockData
        {
            get
            {
                if (mockData == null)
                {
                    mockData = new DataTable("MockData");

                    mockData.Columns.Add(new DataColumn("aa"));
                    mockData.Columns.Add(new DataColumn("bb"));
                    mockData.Columns.Add(new DataColumn("cc"));

                    var row1 = mockData.NewRow();
                    row1["aa"] = "很长很长很长的中文";
                    row1["bb"] = "contain";
                    row1["cc"] = "Colunm's";
                    mockData.Rows.Add(row1);

                    var row2 = mockData.NewRow();
                    row2["aa"] = "81";
                    row2["bb"] = "中山";
                    row2["cc"] = "Windows8";
                    mockData.Rows.Add(row2);

                    var row3 = mockData.NewRow();
                    row3["aa"] = "山泉水";
                    row3["bb"] = "8";
                    row3["cc"] = "window";
                    mockData.Rows.Add(row3);
                }

                return mockData;
            }
        }
    }
}
