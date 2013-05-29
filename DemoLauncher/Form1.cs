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
    }
}
