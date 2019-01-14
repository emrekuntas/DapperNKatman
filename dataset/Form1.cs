using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataset
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.nORTHWND2DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.Firma' table. You can move, or remove it, as needed.
            this.firmaTableAdapter.Fill(this.testDataSet.Firma);
            // TODO: This line of code loads data into the 'nORTHWND2DataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.nORTHWND2DataSet.Employees);

        }
    }
}
